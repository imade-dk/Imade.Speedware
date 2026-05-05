using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imade.Speedadmin.Api.Core
{
    internal static class FilesAndPath
    {
        public static string FileTypeName(string mimetype)
        {
            return mimetype switch
            {
                // Images
                "image/bmp" or "image/gif" or "image/jpeg" or "image/jpg" or "image/png" or "image/tif" or "image/tiff" => "Images",
                // Documents
                "application/msword" or "application/vnd.openxmlformats-officedocument.wordprocessingml.document" or "application/pdf" or "application/vnd.ms-powerpoint" or "application/vnd.openxmlformats-officedocument.presentationml.presentation" or "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" or "application/vnd.ms-excel" or "text/csv" or "text/xml" or "text/plain" => "Files",
                // Audio
                "application/ogg" or "audio/mpeg" or "audio/x-ms-wma" or "audio/x-wav" or "audio/x-ms-wmv" => "Audio",
                // Video
                //case "video/quicktime":
                "video/quicktime" or "video/avi" or "video/mp4" or "video/mpeg" or "application/x-shockwave-flash" => "Video",
                // Others
                "application/zip" => "Files",
                _ => "Files",
            };
            //return retval;
        }

    }
}
