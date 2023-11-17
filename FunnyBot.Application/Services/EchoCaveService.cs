using FunnyBot.Database.DbContexts;
using FunnyBot.Entity.Entity.EchoCave;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyBot.Application.Services {
    public class EchoCaveService {
        private readonly DefaultDbContext _dbContext;
        private readonly DbSet<CaveEchoEntity> _caveEchoes;
        private ILogger<EchoCaveService> _logger;

        public EchoCaveService(DefaultDbContext dbContext, ILogger<EchoCaveService> logger) {
            _dbContext = dbContext;
            _caveEchoes = _dbContext.Set<CaveEchoEntity>();
            _logger = logger;
        }

        public async ValueTask<CaveEchoEntity?> GetCaveEchoAsync(long id) {
            return await _caveEchoes.FindAsync(id);
        }

        public async ValueTask<CaveEchoEntity> AddCaveEchoAsync(string message, ulong creator) {
            var entity = await _caveEchoes.AddAsync(new CaveEchoEntity { Message = message, CreatorId = creator });
            await _dbContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task RemoveCaveEchoAsync(long id) {
            if (await _caveEchoes.FindAsync(id) is CaveEchoEntity caveEcho) {
                _caveEchoes.Remove(caveEcho);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async ValueTask<CaveEchoEntity> PickCaveEchoAsync() {
            var result = await _caveEchoes.AsNoTracking()
                //.Where(b => !b.IsReviewd && !b.IsDeleted)
                .ToListAsync();

            var random = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));
            var num = random.Next(0, result.Count);

            if (result.ElementAt(num) is CaveEchoEntity echo) {
                return echo;
            } else {
                throw new Exception("Entity is null");
            }
        }
    }
}
