using System.Collections.Generic;
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
        /// The hashes of the certificates used by Rockstar to sign the game files.
        /// </summary>
        private static readonly List<string> hashes = new List<string>
        {
            // Issued to: None
            // Issues by: None
            // Serial number: 0c56410e7a8cf26e7f1f306ffce670cc
            // Algorith: sha1RSA
            // Valid from: ‎Sunday, ‎September ‎21, ‎2008 8:00:00 PM
            // Valid to: ‎Tuesday, ‎September ‎22, ‎2009 7:59:59 PM
            // Thumbprint/Hash: f50405ad2d00444c13eb132fd8f00a6493e76521
            // Found in: GTA IV Day 1 Release
            "F50405AD2D00444C13EB132FD8F00A6493E76521",
            // Issued to: Rockstar Games, Inc.
            // Issues by: Entrust Code Signing CA - OVCS1
            // Serial number: 5057286e4033fcb0000000005565f5ac
            // Algorithm: sha256RSA
            // Valid from: ‎Friday, ‎March ‎4, ‎2016 5:46:15 PM
            // Valid to: ‎Monday, ‎March ‎20, ‎2017 6:16:13 PM
            // Thumbprint/Hash: c9793f4a2e629d88f2213622d7a0c170d9c7cbc6
            "C9793F4A2E629D88F2213622D7A0C170D9C7CBC6",
            // Issued to: Rockstar Games, Inc.
            // Issues by: Entrust Code Signing CA - OVCS1
            // Serial number: 00e49e47111fec98cd0000000055662b3e
            // Algorithm: sha256RSA
            // Valid from: ‎Thursday, ‎March ‎9, ‎2017 7:04:49 PM
            // Valid to: ‎Friday, ‎March ‎20, ‎2020 7:34:46 PM
            // Thumbprint/Hash: aa0d31a9c8c1ebd9e18ec1d8d3f98b3523178ad8
            "AA0D31A9C8C1EBD9E18EC1D8D3F98B3523178AD8",
            // Issued to: Rockstar Games, Inc.
            // Issues by: DigiCert SHA2 Assured ID Code Signing CA
            // Serial number: 0f65f4572517cbccaa8b3776580a8d3d
            // Algorithm: sha256RSA
            // Valid from: ‎Thursday, ‎February ‎6, ‎2020 8:00:00 PM
            // Valid to: ‎Friday, ‎February ‎17, ‎2023 8:00:00 AM
            // Thumbprint/Hash: 0ebf58d74ccabca4fce1ab83adba62b40dfc014a
            "0EBF58D74CCABCA4FCE1AB83ADBA62B40DFC014A"
        };

        /// <summary>
        /// Checks that the specified file was signed by Rockstar Games.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <returns>true if the file exists and has a valid signature, false otherwise.</returns>
        public static bool IsFileSignedByRockstar(string file)
        {
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
            string hash = certificate.GetCertHashString();
            return hashes.Contains(hash);
        }
    }
}
