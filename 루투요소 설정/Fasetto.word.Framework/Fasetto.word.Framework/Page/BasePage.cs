using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.word.Framework
{
    /// <summary>
    /// A base for all pages to gain base funtionality
    /// </summary>
    public class BasePage : Page
    {
        #region Public Properties

        /// <summary>
        /// The animation the play when the page is first loded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation the play when the page is unloded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // If we are animation in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            // Listen out for the page loading
            this.Loaded += BasePage_Loaded;
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            AnimateIn();
        }

        /// <summary>
        /// Animates in this page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            // Make sure we have something th do
            if (this.PageLoadAnimation != PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    var sb = new Storyboard();
                    var slideAnimation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(this.SlideSeconds)),
                        From = new Thickness(this.WindowWidth, 0, -this.WindowWidth, 0),
                        To = new Thickness(0),
                        DecelerationRatio = 0.9f
                    };
                    Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                    sb.Children.Add(slideAnimation);

                    sb.Begin(this);

                    this.Visibility = Visibility.Visible;

                    await Task.Delay((int)(this.SlideSeconds * 1000));

                    break;
            }

        }

        #endregion

    }
}
