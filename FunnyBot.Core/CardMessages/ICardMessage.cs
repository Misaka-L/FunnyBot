﻿using Kook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyBot.Core.CardMessages {
    public interface ICardMessage {
        Card[] Build();
    }
}
