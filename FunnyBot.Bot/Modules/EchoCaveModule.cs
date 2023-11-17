using FunnyBot.Application.Services;
using FunnyBot.Entity.Entity.EchoCave;
using Kook;
using Kook.Commands;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyBot.Bot.Modules {
    [Group("echo")]
    public class EchoCaveModule : ModuleBase<SocketCommandContext> {
        private readonly EchoCaveService _echoCaveService;
        private readonly ILogger<EchoCaveModule> _logger;

        public EchoCaveModule(EchoCaveService echoCaveService, ILogger<EchoCaveModule> logger) {
            _echoCaveService = echoCaveService;
            _logger = logger;
        }

        [Command("add")]
        public async Task AddCaveEcho([Remainder] string message) {
            await ReplyTextAsync("由于回声洞服务被滥用，回声洞永久停止运行", true);
            //_logger.LogInformation("{author} 添加了一条回声 {content}", Context.User, message);
            //await _echoCaveService.AddCaveEchoAsync(message, Context.User.Id);
            //await ReplyKMarkdownAsync("success!", true);
        }

        [Command("pick")]
        public async Task GetCaveEcho() {
            await ReplyTextAsync("由于回声洞服务被滥用，回声洞永久停止运行", true);
            //_logger.LogInformation("{author} 捡了一条回声", Context.User);
            //var echo = await _echoCaveService.PickCaveEchoAsync();
            //if (echo is CaveEchoEntity caveEcho) {
            //    await ReplyCardsAsync(new CardBuilder().WithTheme(CardTheme.Primary).WithSize(CardSize.Large)
            //        .AddModule(new SectionModuleBuilder().WithText(new KMarkdownElementBuilder().WithContent($"> 有人说:")))
            //        .AddModule(new SectionModuleBuilder().WithText(new KMarkdownElementBuilder().WithContent(caveEcho.Message)))
            //        .Build(), true);
            //}
        }
    }
}
