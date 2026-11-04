using System;
using System.Collections.Generic;
using System.Text;
using Imade.Speedware.Api.Core;
using Imade.Speedware.Api.Interfaces;
using Imade.Speedware.Api.Models;
using Imade.Speedware.Web.Core;

namespace Imade.Speedware.Web.Helpers
{
    public static class Paths
    {


        public static string ClientFilePath(Blob? blob, Core.FileFolder parentFolder, int parentId, string fileRoot, string slashPrefix = "/")
        {
            if (blob == null)
            {
                return string.Empty;
            }

            return string.Format("{0}/{1}/{2}/{3}/{4}-{5}", slashPrefix + fileRoot, parentFolder.ToString(), parentId, FileTypeName(blob.MimeType!), blob.UniqueId, FileNameWithExtention(blob.Name!, blob.MimeType!).NormalizeFileName());
        }

        public static string ServerFilePath(Blob? blob, Core.FileFolder parentFolder, int parentId, string baseUploadPath)
        {
            return ClientFilePath(blob, parentFolder, parentId, baseUploadPath, string.Empty);
        }



        public static bool EnsureBaseUploadFolderExcist(string baseUploadPath)
        {

            try
            {
                if (!Directory.Exists(baseUploadPath))
                {
                    Directory.CreateDirectory(baseUploadPath);
                }
                return true;
            }
            catch //(Exception exp)
            {
                throw;
            }
        }

        public static bool EnsureFolders(string fileNamePath)
        {
            var dirName = Path.GetDirectoryName(fileNamePath);
            try
            {
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
                return true;
            }
            catch //(Exception exp)
            {
                throw;
            }
        }

        public static bool IsImage(string mimetype)
        {
            bool retval = mimetype switch
            {
                "image/bmp" or "image/gif" or "image/jpeg" or "image/jpg" or "image/png" or "image/tif" or "image/tiff" => true,
                _ => false,
            };
            return retval;
        }
        private static string FileNameWithExtention(string name, string mimetype)
        {
            string retval = mimetype switch
            {
                // Images
                "image/bmp" => name + ".bmp",
                "image/gif" => name + ".gif",
                "image/jpeg" => name + ".jpeg",
                "image/jpg" => name + ".jpg",
                "image/png" => name + ".png",
                "image/tif" => name + ".tif",
                "image/tiff" => name + ".tiff",
                // Documents
                "application/msword" => name + ".doc",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document" => name + ".docx",
                "application/pdf" => name + ".pdf",
                "application/vnd.ms-powerpoint" => name + ".ppt",
                "application/vnd.openxmlformats-officedocument.presentationml.presentation" => name + ".pptx",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" => name + ".xlsx",
                "application/vnd.ms-excel" => name + ".xls",
                "text/csv" => name + ".csv",
                "text/xml" => name + ".xml",
                "text/plain" => name + ".txt",
                // Audio
                "application/ogg" => name + ".ogg",
                "audio/mpeg" => name + ".mp3",
                "audio/x-ms-wma" => name + ".wma",
                "audio/x-wav" => name + ".wav",
                "audio/x-ms-wmv" => name + ".wmv",
                // Video
                //https://discussions.apple.com/thread/951061
                //case "video/quicktime":
                //    retval = name + ".qt";
                //    break;
                "video/quicktime" => name + ".mov",
                "video/avi" => name + ".avi",
                "video/mp4" => name + ".mp4",
                //http://www.differencebetween.info/difference-between-mpeg-and-mpg
                "video/mpeg" => name + ".mpeg",
                //case "video/mpeg":
                //    retval = name + ".mpg";
                //    break;
                "application/x-shockwave-flash" => name + ".swf",
                // Others
                "application/zip" => name + ".zip",
                _ => name + ".dat",
            };
            return retval;
        }

        private static string FileTypeName(string mimetype)
        {
            string retval = mimetype switch
            {
                // Images
                "image/bmp" or "image/gif" or "image/jpeg" or "image/jpg" or "image/png" or "image/tif" or "image/tiff" => "Images",
                // Documents
                "application/msword" or "application/vnd.openxmlformats-officedocument.wordprocessingml.document" or "application/pdf" or "application/vnd.ms-powerpoint" or "application/vnd.openxmlformats-officedocument.presentationml.presentation" or "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" or "application/vnd.ms-excel" or "text/csv" or "text/xml" or "text/plain" => "Files",
                // Audio
                "application/ogg" or "audio/mpeg" or "audio/x-ms-wma" or "audio/x-wav" or "audio/x-ms-wmv" => "Audio",
                // Video
                //"video/quicktime":
                "video/quicktime" or "video/avi" or "video/mp4" or "video/mpeg" or "application/x-shockwave-flash" => "Video",
                // Others
                "application/zip" => "Files",
                _ => "Files",
            };
            return retval;
        }
    }
}
