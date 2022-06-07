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
        public Registry GetRegistryByLogin(string login)
        {
            using (var _context = new MedContext())
            {
                return _context.Registries.FirstOrDefault(x => x.Login.ToLower() == login.ToLower());
            }
        }
        public Registry GetRegistryByPhone(string phone)
        {
            using (var _context = new MedContext())
            {
                return _context.Registries.FirstOrDefault(x => x.Phone == phone);
            }
        }

        public void CreateRegistry(Registry registry)
        {
            using (var _context = new MedContext())
            {
                _context.Registries.Add(registry);
                _context.SaveChanges();
            }
        }

        public Registry GetRegistryById(Guid id)
        {
            using (var _context = new MedContext())
            {
                return _context.Registries.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
