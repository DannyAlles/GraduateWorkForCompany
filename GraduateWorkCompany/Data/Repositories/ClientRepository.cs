using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GraduateWorkCompany.Data.Models;

namespace GraduateWorkCompany.Data.Repositories
{
    public class ClientRepository
    {
        public Client GetClilentById(Guid id)
        {
            using (var _context = new MedContext())
            {
                return _context.Clients.FirstOrDefault(x => x.Id == id);
            }
        }

        public Client CreateClient(Client client)
        {
            using (var _context = new MedContext())
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return client;
            }
        }

        public Client GetClientByLogin(string login)
        {
            using (var _context = new MedContext())
            {
                return _context.Clients.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
            }
        }

        public Client GetClientByPhone(string phone)
        {
            using (var _context = new MedContext())
            {
                return _context.Clients.FirstOrDefault(x => x.Phone == phone);
            }
        }
    }
}
