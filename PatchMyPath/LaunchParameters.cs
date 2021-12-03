using CommandLine;

namespace PatchMyPath
{
    /// <summary>
    /// The launch parameters used to start a folder from the command line.
    /// </summary>
    public class LaunchParameters
    {
        [Option("launch", Required = true, HelpText = "The installation to launch. It needs to be added to the program before starting unless --add is set.")]
        public string Launch { get; set; }
        [Option("add", Required = false, HelpText = "Adds the installation to the list if is not present.")]
        public bool Add { get; set; }
    }
}
