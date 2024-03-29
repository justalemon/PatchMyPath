﻿using NLog;
using PatchMyPath.Properties;
using PatchMyPath.Tools;
using System;
using System.Diagnostics;
using System.IO;

namespace PatchMyPath.Config
{
    /// <summary>
    /// Specifies the information for launching a GTA V install.
    /// </summary>
    public class Install : IEquatable<Install>
    {
        #region Fields

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Properties

        /// <summary>
        /// The path of the new game install.
        /// </summary>
        public string GamePath { get; set; }
        /// <summary>
        /// The game that this install contains.
        /// </summary>
        public Game Game
        {
            get
            {
                // If the respective game executables is present
                if (File.Exists(Path.Combine(GamePath, "RDR2.exe")))
                {
                    return Game.RedDeadRedemption2;
                }
                else if (File.Exists(Path.Combine(GamePath, "GTAIV.exe")) || File.Exists(Path.Combine(GamePath, "LaunchGTAIV.exe")))
                {
                    return Game.GrandTheftAutoIV;
                }
                else if (File.Exists(Path.Combine(GamePath, "GTA5.exe")))
                {
                    return Game.GrandTheftAutoV;
                }
                else if (File.Exists(Path.Combine(GamePath, "gta_sa.exe")) || File.Exists(Path.Combine(GamePath, "gta-sa.exe")))
                {
                    return Game.GrandTheftAutoSanAndreas;
                }
                else
                {
                    return Game.Invalid;
                }
            }
        }
        /// <summary>
        /// The type of game installation.
        /// </summary>
        public Launch Type
        {
            get
            {
                switch (Game)
                {
                    case Game.RedDeadRedemption2:
                        if (File.Exists(Path.Combine(GamePath, "RDR2.exe")))
                        {
                            return Launch.Normal;
                        }
                        break;
                    case Game.GrandTheftAutoIV:
                        if (File.Exists(Path.Combine(GamePath, "LaunchGTAIV.exe")) || File.Exists(Path.Combine(GamePath, "GTAIV.exe")))
                        {
                            return Launch.Normal;
                        }
                        break;
                    case Game.GrandTheftAutoV:
                        if (File.Exists(Path.Combine(GamePath, "RAGEPluginHook.exe")))
                        {
                            return Launch.RagePluginHook;
                        }
                        else if (File.Exists(Path.Combine(GamePath, "GTA5.exe")) && File.Exists(Path.Combine(GamePath, "GTAVLauncherBypass.asi")))
                        {
                            return Launch.LauncherBypass;
                        }
                        else if (File.Exists(Path.Combine(GamePath, "GTAVLauncher.exe")) || File.Exists(Path.Combine(GamePath, "PlayGTAV.exe")))
                        {
                            return Launch.Normal;
                        }
                        break;
                    case Game.GrandTheftAutoSanAndreas:
                        if (File.Exists(Path.Combine(GamePath, "gta_sa.exe")) || File.Exists(Path.Combine(GamePath, "gta-sa.exe")))
                        {
                            return Launch.Normal;
                        }
                        break;
                }
                return Launch.Invalid;
            }
        }
        /// <summary>
        /// If the game executables are tampered or not.
        /// </summary>
        public bool IsLegal
        {
            get
            {
                switch (Game)
                {
                    case Game.RedDeadRedemption2:
                        return Signatures.IsSignedByRockstar(Path.Combine(GamePath, "RDR2.exe"));
                    case Game.GrandTheftAutoIV:
                        return Signatures.IsSignedByRockstar(Path.Combine(GamePath, "GTAIV.exe")) || Signatures.IsSignedByRockstar(Path.Combine(GamePath, "gta4Browser.exe"));
                    case Game.GrandTheftAutoV:
                        return Signatures.IsSignedByRockstar(Path.Combine(GamePath, "GTA5.exe"));
                    case Game.GrandTheftAutoSanAndreas:
                        return true;  // HOODLUM's crack is required on Steam and RGL after downgrades
                    default:
                        return false;
                }
            }
        }
        /// <summary>
        /// The executable used to start the game.
        /// </summary>
        public string Executable
        {
            get
            {
                switch (Game)
                {
                    case Game.RedDeadRedemption2:
                        return Path.Combine(Program.Config.Destination.RDR2, "RDR2.exe");
                    case Game.GrandTheftAutoIV:
                        if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "PlayGTAIV.exe")))
                        {
                            return Path.Combine(Program.Config.Destination.GTAV, "PlayGTAIV.exe");
                        }
                        else if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "LaunchGTAIV.exe")))
                        {
                            return Path.Combine(Program.Config.Destination.GTAV, "LaunchGTAIV.exe");
                        }
                        break;
                    case Game.GrandTheftAutoV:

                        if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "GTAVLauncher.exe")))
                        {
                            return Path.Combine(Program.Config.Destination.GTAV, "GTAVLauncher.exe");
                        }
                        else if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "PlayGTAV.exe")))
                        {
                            return Path.Combine(Program.Config.Destination.GTAV, "PlayGTAV.exe");
                        }
                        break;
                    case Game.GrandTheftAutoSanAndreas:
                        if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "gta_sa.exe")))
                        {
                            return Path.Combine(Program.Config.Destination.GTAV, "gta_sa.exe");
                        }
                        else if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "gta-sa.exe")))
                        {
                            return Path.Combine(Program.Config.Destination.GTAV, "gta-sa.exe");
                        }
                        break;
                }

                return null;
            }
        }

        #endregion

        #region Constructors

        public Install(string path)
        {
            GamePath = Path.GetFullPath(path);
        }

        #endregion

        #region Functions

        /// <inheritdoc/>>
        public override string ToString() => $"{GamePath} [{Game.ToString().SpaceOnUpperCase()}] [{Type}]";
        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return GamePath.GetHashCode();
        }
        /// <inheritdoc/>
        public bool Equals(Install other) => other == this;

        #endregion

        #region Operators

        public static bool operator ==(Install left, Install right)
        {
            return left.GamePath == right.GamePath;
        }
        public static bool operator !=(Install left, Install right)
        {
            return left.GamePath != right.GamePath;
        }

        #endregion
    }
}
