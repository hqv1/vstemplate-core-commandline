using CommandLine;

namespace $safeprojectname$
{
    /// <summary>
    /// Used by command line library (https://github.com/gsscoder/commandline).
    /// 
    /// todo: add options
    /// </summary>
    internal class Options
    {
        [Option('h', "say-hello", Required = false, HelpText = "Say Hello")]
        public bool ShouldSayHello { get; set; }
    }
}