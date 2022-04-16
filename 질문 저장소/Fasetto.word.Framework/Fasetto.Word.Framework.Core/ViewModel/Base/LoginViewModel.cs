using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Framework.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indictation if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        ///  The command to login 
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        ///  The command to register for a new account
        /// </summary>
        public ICommand RegisterCommand { get; set; }


        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="window"></param>
        public LoginViewModel()
        {
            // Create commands
            LoginCommand = new RelayParameterizedCommand(async(parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async() => await Register());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        private async Task LoginAsync(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            { 
                await Task.Delay(3000);

                var email = this.Email;

                // IMPORTANT : Never store unsecure password in variable like this
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });

        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        private async Task Register()
        {
            IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;

            // Go to register page
            if(IoC.Get<ApplicationViewModel>().CurrentPage == ApplicationPage.Login)
            {
                IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;
            }
            else
            {
                IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Login;
            }
            // It was this => ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = ApplicationPage.Register;
            // (Used Ninject(Kernel) then Set the Location to CurrentPage)
            return;

            await Task.Delay(1);
        }

    }
}
