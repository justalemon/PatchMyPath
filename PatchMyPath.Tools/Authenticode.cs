using System.IO;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;

namespace PatchMyPath.Tools
{
    /// <summary>
    /// Reader for Authenticode signatures.
    /// </summary>
    public static class Authenticode
    {
        /// <summary>
        /// Gets the identifier of the file that got signed by 
        /// </summary>
        /// <param name="file">The file to check against.</param>
        /// <returns></returns>
        public static X509Certificate2 GetCertificate(string file)
        {
            // If the file does not exists, return null
            if (!File.Exists(file))
            {
                return null;
            }

            // Create a new PowerShell instance
            using (PowerShell ps = PowerShell.Create())
            {
                // Set the command to Get-AuthenticodeSignature
                ps.AddCommand("Get-AuthenticodeSignature");
                // Add the file that we need the signature from
                ps.AddParameter("FilePath", Path.GetFullPath(file));
                
                // Then, invoke the command and iterate over the objects that we have
                foreach (PSObject psobject in ps.Invoke())
                {
                    // Cast the signature object to another object
                    Signature signature = (Signature)psobject.BaseObject;

                    // If the file signature is valid, return the certificate
                    if (signature.Status == SignatureStatus.Valid)
                    {
                        return signature.SignerCertificate;
                    }
                    // Otherwise, return null
                    else
                    {
                        return null;
                    }
                }

                // If we got here, there is no valid signature
                return null;
            }
        }
    }
}
