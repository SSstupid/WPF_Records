/* Move to PasswordBoxAttachedProperties and BaseAttachedProperty
 * using System.Windows;
using System.Windows.Controls;

namespace Fasetto.word.Framework
{
    public class PasswordBoxProperties
    {
        public static readonly DependencyProperty MonitorPasswordProperty =
           DependencyProperty.RegisterAttached("MonitorPassword",
               typeof(bool),
               typeof(PasswordBoxProperties),
               new PropertyMetadata(false, OnMonitorPasswordChanged));

        private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = (d as PasswordBox);

            if (passwordBox == null) 
                return;

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                SetHasText(passwordBox);

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetHasText((PasswordBox)sender);
        }

        public static void SetMonitorPassword(PasswordBox element, bool value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MonitorPasswordProperty);
        }


        /// <summary>
        /// public bool HasText { get; set; } = false
        /// </summary>
        public static readonly DependencyProperty HasTextProperty = 
            DependencyProperty.RegisterAttached("HasText",
                typeof(bool),
                typeof(PasswordBoxProperties),
                new PropertyMetadata(false));

        private static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }

        public static bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);
        }
    }
}
*/