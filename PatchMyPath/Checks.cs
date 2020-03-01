using System.ComponentModel;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace PatchMyPath
{
    /// <summary>
    /// A set of checks to ensure the integrity of game installs.
    /// </summary>
    public static class Checks
    {
        /// <summary>
        /// Checks that the specified file was signed by Rockstar Games.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>true if the file exists and has a valid signature, false otherwise.</returns>
        public static bool IsFileSignedByRockstar(string file)
        {
            // This is the basic information of the Rockstar Games certificate:
            // Issued to: Rockstar Games, Inc.
            // Issues by: Entrust Code Signing CA - OVCS1
            // Serial number: 00e49e47111fec98cd0000000055662b3e
            // Algorithm: sha256RSA
            // Valid from: ‎Thursday, ‎March ‎9, ‎2017 7:04:49 PM
            // Valid to: ‎Friday, ‎March ‎20, ‎2020 7:34:46 PM
            // Thumbprint/Hash: aa0d31a9c8c1ebd9e18ec1d8d3f98b3523178ad8

            // If the file does not exists, return
            if (!File.Exists(file))
            {
                return false;
            }

            // The file might be a symbolic or hard link, so try to get the real path
            string realPath;
            try
            {
                realPath = Links.GetRealPath(file);
            }
            // If we failed to get the file location, return
            catch (Win32Exception)
            {
                return false;
            }

            // Now that we have the real path, get the certificate that signed the file
            X509Certificate certificate = X509Certificate.CreateFromSignedFile(realPath);

            // If the file is not signed, return
            if (certificate == null)
            {
                return false;
            }

            // Then finally, check if the file is signed by Rockstar Games
            return certificate.GetCertHashString() == "AA0D31A9C8C1EBD9E18EC1D8D3F98B3523178AD8";
        }
    }
}
