using MyCars.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCars.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyCarsDbContext context;

        public UnitOfWork(MyCarsDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
