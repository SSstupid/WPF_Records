using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;

namespace NewStartTreeViews
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        #region constrctor

        /// <summary>
        /// Default constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new Class1(); // Test for Binding Image

            this.DataContext = new DirectoryStructureViewModel();


        }

        #endregion constrctor

        #region it moved to DirectoryStructure
        // On Loaded is moved to DirectoryStructure
        #region On Loaded

        /// <summary>
        /// When the application first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get every logical drive on the mechine
            foreach(var drive in Directory.GetLogicalDrives())
            {
                // Create a new item for it
                var item = new TreeViewItem()
                {
                    // Set header and path
                    Header = drive,
                    Tag = drive
                };
 

                // Add a dommy item
                item.Items.Add(null);

                // Listen out of item being expanded
                item.Expanded += Folder_Expanded;

                // Add it to the main tree-view
                FolderView.Items.Add(item);
            }
        }
        */
        #endregion // it moved to class // it moved
        //On Loaded is moved to DirectoryStructure

        // Folder expande is moved to DirectoryStructure
        #region Folder expanded
        /*
        /// <summary>
        /// When a folder is expanded, find the sub folders/files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial Checks

            var item = (TreeViewItem)sender;

            //if the item olny contains the dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return; 

            // Clear dummy data
            item.Items.Clear();

            // Get full path
            var fullpath = (string)item.Tag;

            #endregion

            #region Get folders

            // Create a black list for directories
            var directories = new List<string>();

            // Try and get directories from the folder
            // Ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullpath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }

            // for each directory..
            directories.ForEach(directoryPath =>
            {
                // Create directory item
                var subItem = new TreeViewItem()
                {
                    // Set header as folder name
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath
                };

                // Add dummy item so we can expand folder
                subItem.Items.Add(null);

                // Handle expanding
                subItem.Expanded += Folder_Expanded;

                // Add this item to the parent
                item.Items.Add(subItem);
            });
            #endregion

            #region Get Files

            // Create a black list for files
            var files = new List<string>();

            // Try and get files from the folder
            // Ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullpath);

                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }

            // for each file..
            files.ForEach(filePath =>
            {
                // Create file item
                var subItem = new TreeViewItem()
                {
                    // Set header as file name
                    Header = GetFileFolderName(filePath),
                    Tag = filePath
                };

                // Add this item to the parent
                item.Items.Add(subItem);
            });

            #endregion
        }
        */
        #endregion
        // Folder expande is moved to DirectoryStructure
        #endregion
    }
}
