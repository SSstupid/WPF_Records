using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NewStartTreeViews
{
    /// <summary>
    /// A helper class to query information about directoies
    /// </summary>
    public class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetlogicalDrives()
        {
            // Get every logical drive on the mechine
            return Directory.GetLogicalDrives().Select(DriveInfo => new DirectoryItem { FullPath = DriveInfo, Type = DirectoryItemType.Drive }).ToList();
        }
    
        /// <summary>
        /// Gets the directory top-level content
        /// </summary>
        /// <param name="fullPath">The-full path to he directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            //Create empty list
            var items = new List<DirectoryItem>();
            #region Get folders

            // Try and get directories from the folder
            // Ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }
            #endregion

            #region Get Files

            // Try and get files from the folder
            // Ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }
            #endregion

            return items;
        }

        #region Helpers

        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // If we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');

            //Find the last backlash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If we don`t find a backslash, return the path itself
            if (lastIndex <= 0)
                return path;

            // Return the name after the last back slash
            return path.Substring(lastIndex + 1);
        }

        #endregion

    }
}
