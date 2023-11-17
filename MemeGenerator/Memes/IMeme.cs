using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meme.Generator.Memes {
    public interface IMeme {
        static string Name { get; }
        Stream Create();
    }
}
