using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Imade.Speedware.Web.Core;
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

        public async Task<string> EnsureDownloadedAsync(Blob blob, FileFolder subFolder, int parentId, CancellationToken cancellationToken = default)
        {


            var relativePath = Helpers.Paths.ClientFilePath(blob, subFolder, parentId, _config.RootUploadFolder);
            if (relativePath.StartsWith("/")) { 
                relativePath = relativePath.Substring(1);
            }
            var physicalPath = Path.Combine(_webRootPath, relativePath);

            if (File.Exists(physicalPath))
            {
                //_logger.LogInformation("Blob {BlobId} ({BlobName}) already exists at {PhysicalPath}.", blob.BlobId, blob.Name, physicalPath);
                return ToVirtualPath(relativePath);
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(physicalPath)!);
                var bytes = await _client.GetBlobBytesAsync(ApiEndpoint.BlobById, blob.BlobId!, cancellationToken);
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
