using FunnyBot.Application.Models;
using FunnyBot.Core.CardMessages;
using Kook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyBot.Bot.CardMessages {
    public class WhoIAmCardMessage : ICardMessage {
        public IUser User { get; }
        public WhatIAmResult Data { get; }

        public WhoIAmCardMessage(IUser user, WhatIAmResult data) {
            User = user;
            Data = data;
        }

        public Card[] Build() {
            return new Card[] {
                new CardBuilder().WithTheme(CardTheme.Info).WithSize(CardSize.Large)
                .AddModule(new SectionModuleBuilder()
                .WithAccessory(new ImageElementBuilder().WithSource(User.Avatar).WithSize(ImageSize.Small).WithCircle(false))
                .WithText(new KMarkdownElementBuilder().WithContent($"> **(met){User.Id}(met)\n今天是这样的少女**")))
                .AddModule(new DividerModuleBuilder())
                .AddModule(new SectionModuleBuilder().WithText(new ParagraphStructBuilder().WithColumnCount(3)
                .AddField(new KMarkdownElementBuilder().WithContent($"> **种族**\n{Data.Race}"))
                .AddField(new KMarkdownElementBuilder().WithContent($"> **Cup**\n{Data.Cup}"))
                .AddField(new KMarkdownElementBuilder().WithContent($"> **身高**\n{Data.Height}cm"))
                .AddField(new KMarkdownElementBuilder().WithContent($"> **发型**\n{Data.HairType}"))
                .AddField(new KMarkdownElementBuilder().WithContent($"> **发色**\n{Data.HairColor}"))
                .AddField(new KMarkdownElementBuilder().WithContent($"> **瞳色**\n{Data.EyeType}"))))
                .AddModule(new DividerModuleBuilder())
                .AddModule(new SectionModuleBuilder().WithText(new ParagraphStructBuilder().WithColumnCount(3)
                .AddField(new KMarkdownElementBuilder().WithContent($"> **职业**\n{Data.Job}"))
                .AddField(new KMarkdownElementBuilder().WithContent($"> **武器**\n{Data.Weapon}"))))
                .Build()
            };
        }
    }
}
