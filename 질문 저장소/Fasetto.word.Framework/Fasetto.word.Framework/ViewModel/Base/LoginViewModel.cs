﻿using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.word.Framework
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

        #endregion

        #region Contructor

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="window"></param>
        public LoginViewModel()
        {
            // Create commands
            LoginCommand = new RelayParameterizedCommand(async(parameter) => await Login(parameter));
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        private async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () =>
            { 
                await Task.Delay(3000);

                var email = this.Email;

                // IMPORTANT : Never store unsecure password in variable like this
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });

        }
    }
}
