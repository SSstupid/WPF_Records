using System.Security;

namespace Fasetto.word.Framework
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
