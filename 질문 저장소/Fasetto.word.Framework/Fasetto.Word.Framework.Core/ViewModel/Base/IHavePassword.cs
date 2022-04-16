using System.Security;

namespace Fasetto.Word.Framework.Core
{
    /// <summary>
    /// An interface for a class that can provide a secure password
    /// </summary>
    public interface IHavePassword
    {
        /// <summary>
        /// The seccure password
        /// </summary>
        SecureString SecurePassword { get; }
    }
}
