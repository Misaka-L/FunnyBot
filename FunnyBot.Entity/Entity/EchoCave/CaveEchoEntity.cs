using FunnyBot.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyBot.Entity.Entity.EchoCave {
    public class CaveEchoEntity : BaseEntity {
        public string Message { get; set; }
        public ulong CreatorId { get; set; }
        public bool IsReviewd { get; set; }

        public static void Configure(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CaveEchoEntity>();
        }
    }
}
