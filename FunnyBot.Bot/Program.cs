using FunnyBot.Application.Services;
using FunnyBot.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FunnyBot.Bot {
    internal class Program {
        static Task Main(string[] args) => new Program().MainAsync(args);

        public async Task MainAsync(string[] args) {
            var host = Host.CreateDefaultBuilder(args)
                .AddBotCraft()
                .ConfigureServices(ConfigureServices);

            await host.RunConsoleAsync();
        }

        public void ConfigureServices(HostBuilderContext context, IServiceCollection services) {
            services.AddTransient<WhatIAmService>();
        }
    }
}