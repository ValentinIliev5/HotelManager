using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelManagerReservationsPt3.Startup))]
namespace HotelManagerReservationsPt3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
