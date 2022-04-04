using System.Windows;
using System.Windows.Input;

namespace Fasetto.word.Framework
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region private member

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the whindow to allow for a drop shadown
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edge of the window
        /// </summary>
        private int mWindowRadius = 10;

        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public Properties

        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        public bool Borderless => (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);

        /// <summary>
        /// The size of resize border around the window
        /// </summary>
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        /// <summary>
        /// The size of resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize);} }

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);


        /// <summary>
        /// The margin around the whindow to allow for a drop shadown
        /// </summary>
        public int OuterMarginSize
        {
            get 
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize; 
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the whindow to allow for a drop shadown
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                { return new Thickness(OuterMarginSize); }
            }
        }

        /// <summary>
        /// The radius of the edge of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edge of the window
        /// </summary>
        public CornerRadius WindowCornerRadius
        {
            get
            {
                { return new CornerRadius(WindowRadius); }
            }
        }

        /// <summary>
        /// THe height of the title bar / caption of the winodw
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// THe height of the title bar / caption of the winodw
        /// </summary>
        public GridLength TitleHeightGridLenth 
        {
            get
            {
                { return new GridLength(TitleHeight); }
            }
        }

        /// <summary>
        /// The current page of te application 
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion

        #region Commands

        /// <summary>
        ///  The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        ///  The command to maxmize the window
        /// </summary>
        public ICommand MaxmizeCommand { get; set; }

        /// <summary>
        ///  The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }


        /// <summary>
        ///  The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //Listen out for the window reszing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties thar are effected by a resize 
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaxmizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // Fix window resize issue
            var resizer = new WindowResizer(mWindow);
        }


        #endregion

        #region Private Helpers

        /// <summary>
        /// Get the current  mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(mWindow);
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion

    }
}
