using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Console
{
    /// <summary>
    /// Actors that do things based on the options from the command line.
    /// 
    /// todo: implement actors
    /// </summary>
    internal interface IActor
    {
        bool ShouldAct(Options options);
        Task Act(Options options, IConfiguration configuration);
    }
}