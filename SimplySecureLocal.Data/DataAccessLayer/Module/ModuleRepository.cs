using Microsoft.EntityFrameworkCore;
using SimplySecureLocal.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplySecureLocal.Data.DataAccessLayer.Module
{
    public class ModuleRepository : BaseRepository, IModuleRepository
    {
        public async Task<List<Models.Module>> GetModules()
        {
            using (DataContext = new SimplySecureDataContext())
            {
                var modules = await DataContext.Modules.ToListAsync();

                return modules;
            }
        }

        public async Task UpdateModuleHeartbeat(Models.Module module)
        {
            using (DataContext = new SimplySecureDataContext())
            {
                var dbModule
                    = await DataContext.Modules.Where
                        (m => m.Id == module.Id).SingleOrDefaultAsync();

                if (dbModule == null)
                {
                    DataContext.Modules.Add(module);
                    await DataContext.SaveChangesAsync();
                    return;
                }

                dbModule.LastHeartBeat = DateTime.UtcNow;
                dbModule.State = module.State;

                DataContext.Modules.Update(dbModule);
                await DataContext.SaveChangesAsync();
            }
        }
    }
}