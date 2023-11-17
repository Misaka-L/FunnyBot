using Kook.Commands;
using Kook.WebSocket;
using FunnyBot.Core.Options;
using FunnyBot.Core.Services;
using FunnyBot.Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FunnyBot.Core.Extensions {
    public static class HostExtensions {
        public static IHostBuilder AddBotCraft(this IHostBuilder builder) {

            return builder.UseContentRoot(AppContext.BaseDirectory)
                .ConfigureServices(ConfigureServices)
                .ConfigureLogging(builder => {
                    builder.AddSimpleConsole(options => {
                        options.IncludeScopes = true;
                        options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
                    }).AddFile();
                });
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services) {
            services.AddSingleton(new KookSocketClient(new KookSocketConfig {
                    ConnectionTimeout = 60000
            }))
                .AddSingleton(_ => new CommandService(new CommandServiceConfig {
                }))
                .AddHostedService<BotHostService>()
                .AddHostedService<CommandHandleService>()
                .AddHostedService<BotMarketStatusService>()
                .AddDbContext<DefaultDbContext>(option => option.UseSqlite(context.Configuration.GetConnectionString("DefaultDbContext")));

            services.AddOptions<KookSettings>().Bind(context.Configuration.GetSection("Kook"));
            services.AddOptions<BotMarketSettings>().Bind(context.Configuration.GetSection("BotMarket"));
        }
    }
}
