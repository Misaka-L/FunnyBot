using FunnyBot.Application.Services;
using FunnyBot.Bot.CardMessages;
using Kook.Commands;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyBot.Bot.Modules {
    public class FunnyModule : ModuleBase<SocketCommandContext> {
        private readonly WhatIAmService _whatIAmService;
        private readonly ILogger<FunnyModule> _logger;

        public FunnyModule(WhatIAmService whatIAmService, ILogger<FunnyModule> logger) {
            _whatIAmService = whatIAmService;
            _logger = logger;
        }

        [Command("我是什么少女")]
        public async Task WhatIAm() {
            var result = _whatIAmService.WhatIAm();
            _logger.LogInformation(
                "{author} 在 {guild} 的 {channel} ({channel_id}) 问她是什么少女，结果是:\n{result}",
                Context.User, Context.Guild, Context.Channel.Name, Context.Channel.Id, JsonConvert.SerializeObject(result, Formatting.Indented));
            await ReplyCardsAsync(new WhoIAmCardMessage(Context.User, result).Build(), true);
        }

        [Command("贴贴")]
        public async Task TapTap() {
            _logger.LogInformation("{author} 在 {guild} 的 {channel} ({channel_id}) 贴了个贴", Context.User, Context.Guild, Context.Channel.Name, Context.Channel.Id);
            await ReplyTextAsync("贴贴", true);
        }
    }
}
