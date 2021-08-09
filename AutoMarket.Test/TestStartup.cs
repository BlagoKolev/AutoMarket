using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoMarket.Test
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
             : base(configuration)
        {
        }
        public void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            // Replace only your own custom services. The ASP.NET Core ones 
            // are already replaced by MyTested.AspNetCore.Mvc. 
            //services.Replace<IService, MockedService>();
        }
    }
}
