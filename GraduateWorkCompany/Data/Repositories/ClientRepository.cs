using System;
using System.Data.Entity;
using System.Threading.Tasks;
using GraduateWorkCompany.Data.Models;

namespace GraduateWorkCompany.Data.Repositories
{
    public class ClientRepository
    {
        public async Task<Client> GetClilentById(Guid id)
        {
            using (var _context = new MedContext())
            {
                return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            }
        }

        public async Task<Client> CreateClient(Client client)
        {
            using (var _context = new MedContext())
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return client;
            }
        }

        public async Task<Client> GetClientByLogin(string login)
        {
            using (var _context = new MedContext())
            {
                return await _context.Clients.FirstOrDefaultAsync(x => x.Login.ToLower() == login.ToLower()).ConfigureAwait(false);
            }
        }

        public async Task<Client> GetClientByPhone(string phone)
        {
            using (var _context = new MedContext())
            {
                return await _context.Clients.FirstOrDefaultAsync(x => x.Phone == phone).ConfigureAwait(false);
            }
        }
    }
}
