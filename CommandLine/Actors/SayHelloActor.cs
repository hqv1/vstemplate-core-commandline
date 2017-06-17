using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Configuration;

namespace Console.Actors
{
    internal class SayHelloActor : IActor
    {
        private readonly SayHelloService _service;

        public SayHelloActor(SayHelloService service)
        {
            _service = service;
        }

        public bool ShouldAct(Options options)
        {
            return options.ShouldSayHello;
        }

        public Task Act(Options options, IConfiguration configuration)
        {
            System.Console.WriteLine(_service.SayHello());
            return Task.CompletedTask;
        }
    }
}
