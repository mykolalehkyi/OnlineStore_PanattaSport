using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Data;
using OnlineStore.Data.Identity;

[assembly: HostingStartup(typeof(OnlineStoreAspCore.Areas.Identity.IdentityHostingStartup))]
namespace OnlineStoreAspCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StoreSportDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("OnlineStoreContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<StoreSportDbContext>();
            });
        }
    }
}