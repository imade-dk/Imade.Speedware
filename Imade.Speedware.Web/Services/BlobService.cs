using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Cache;

namespace Imade.Speedware.Web.Services
{
    public class BlobService : SpeedwareServiceBase, IBlobService
    {
        private readonly string _webRootPath;
        private readonly ILogger<BlobService> _logger;

        public BlobService(
            ISpeedwareClient client,
            AppCaches appCaches,
            IOptions<SpeedwareConfig> config,
            IWebHostEnvironment env,
            ILogger<BlobService> logger)
            : base(client, appCaches, config)
        {
            _webRootPath = env.WebRootPath;
            _logger = logger;
        }

        public async Task<string> EnsureDownloadedAsync(Blob blob, CancellationToken cancellationToken = default)
        {
            var subfolder = FilesAndPath.FileTypeName(blob.MimeType);
            var relativePath = Path.Combine(_config.RootUploadFolder, subfolder, blob.Name);
            var physicalPath = Path.Combine(_webRootPath, relativePath);

            if (File.Exists(physicalPath))
                return ToVirtualPath(relativePath);

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(physicalPath)!);
                var bytes = await _client.GetBlobBytesAsync(ApiEndpoint.BlobById, blob.BlobId, cancellationToken);
                await File.WriteAllBytesAsync(physicalPath, bytes, cancellationToken);
                return ToVirtualPath(relativePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to download blob {BlobId} ({BlobName}).", blob.BlobId, blob.Name);
                throw;
            }
        }

        private static string ToVirtualPath(string relativePath)
            => "/" + relativePath.Replace('\\', '/');
    }
}
