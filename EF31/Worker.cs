using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NodaTime;

namespace EF3
{
    public class Worker : BackgroundService
    {
        readonly IHostApplicationLifetime _hostApplicationLifetime;
        private TestContext _dbContext;

        public Worker(IHostApplicationLifetime hostApplicationLifetime, TestContext context)
        {
            _dbContext = context;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _dbContext.Database.Migrate();
                await _dbContext.TestObjects.AddAsync(new TestObject
                {
                    Key = Guid.NewGuid(),
                    ADate = new LocalDate(2020, 10, 01)
                }, stoppingToken);
                await _dbContext.SaveChangesAsync(stoppingToken);
                var test = await _dbContext.TestObjects
                    .FirstOrDefaultAsync(cancellationToken: stoppingToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            _hostApplicationLifetime.StopApplication();
        }
    }
}
