using GraduateWorkCompany.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Data.Repositories
{
    public class RegistryRepository
    {
        public async Task<Registry> GetRegistryByLogin(string login)
        {
            using (var _context = new MedContext())
            {
                return await _context.Registries.FirstOrDefaultAsync(x => x.Login.ToLower() == login.ToLower()).ConfigureAwait(false);
            }
        }
        public async Task<Registry> GetRegistryByPhone(string phone)
        {
            using (var _context = new MedContext())
            {
                return await _context.Registries.FirstOrDefaultAsync(x => x.Phone == phone).ConfigureAwait(false);
            }
        }

        public async Task CreateRegistry(Registry registry)
        {
            using (var _context = new MedContext())
            {
                _context.Registries.Add(registry);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
