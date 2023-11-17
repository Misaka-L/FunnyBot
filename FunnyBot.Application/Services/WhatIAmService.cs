using FunnyBot.Application.Models;
using Kook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyBot.Application.Services {
    public class WhatIAmService {
        public string[] Cups = new string[] {
            "null", "AAA", "AA", "A", "B", "C", "D", "E", "F", "G????", "G Pro Plus Max Ulatr", "OutOfMemoryException", "不可直视，不可观察，不可描述"
        };

        public string[] Jobs = new string[] {
            "JK", "魔法烧酒", "码农", "neet", "女装大佬", "键盘侠", "进近管制", "地勤", "民航机长", "机务", "女仆咖啡馆服务员", "女仆", "RBQ", "无业游民", "丐帮帮主"
        };

        public string[] Races = new string[] {
            "吸血鬼", "正常人类", "猫娘", "马娘", "安冬星人", "狐娘", "萝卜娘", "武装直升机", "史莱姆", "不可直视，不可观察，不可描述"
        };

        public string[] HairColor = new string[] {
            "rgb(0,0,0)", "红发", "绿发", "蓝发", "黄发", "紫发", "白发", "黄橘发", "灰发", "黑白发", "rgba(0,0,0,0)"
        };

        public string[] HairTypes = new string[] {
            "双马尾", "单马尾", "中分", "散发", "狼尾", "强者的发型", "不可直视，不可观察，不可描述"
        };

        public string[] EyeTypes = new string[] {
            "黑瞳", "蓝绿异瞳", "红瞳", "灰瞳", "绿瞳", "蓝瞳", "黄瞳", "紫瞳", "橙瞳", "白瞳", "真的就是纯爱心", "rgba(0,0,0,0)"
        };

        public string[] Weapons = new string[] {
            "赤手空拳", "菜刀", "热水壶", "物理学神剑", "键盘", "五仁月饼", "髮棍", "平底锅", "侧杆", "@Overwrite", "OptiFine", "Mixin"
        };

        public WhatIAmResult WhatIAm() {
            var random = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));
            var height = random.Next(138, 194);

            return new WhatIAmResult {
                Cup = getRadomValue(Cups),
                Job = getRadomValue(Jobs),
                Race = getRadomValue(Races),
                HairColor = getRadomValue(HairColor),
                HairType = getRadomValue(HairTypes),
                EyeType = getRadomValue(EyeTypes),
                Weapon = getRadomValue(Weapons),
                Height = height.ToString()
            };
        }

        private string getRadomValue(string[] strings) {
            var random = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));
            var num = random.Next(0, strings.Length - 1);

            return strings[num];
        }
    }
}
