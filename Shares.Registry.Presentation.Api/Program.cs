using Shares.Registry.Presentation.App.Builder;

using System.Threading.Tasks;
using Shares.Registry.Presentation.App;

namespace Shares.Registry.Presentation.Api
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IAppBuilder appBuilder = new DefaultAppBuilder();    
            await appBuilder.Build<ApiApp>().RunAsync(args);
        }
    }
}
