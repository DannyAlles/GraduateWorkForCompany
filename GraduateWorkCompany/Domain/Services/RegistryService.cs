using GraduateWorkCompany.Data.Models;
using GraduateWorkCompany.Data.Repositories;
using GraduateWorkCompany.Domain.Exception;
using GraduateWorkCompany.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Domain.Services
{
    public class RegistryService
    {
        private readonly RegistryRepository _registryRepository;
        private readonly HashSevice _hashService;

        public RegistryService()
        {
            _registryRepository = new RegistryRepository();
            _hashService = new HashSevice();
        }

        public void CreateRegistry(Registry registry, string password, string rePassword)
        {
            if (password != rePassword) throw new PasswordNotEqualException();
            if (password == null || rePassword == null) throw new PasswordIsEmptyException();
            var existregistry = _registryRepository.GetRegistryByLogin(registry.Login);
            if (existregistry != null) throw new LoginIsAlreadyExistsException();
            existregistry = _registryRepository.GetRegistryByPhone(registry.Phone);
            if (existregistry != null) throw new PhoneIsAlreadyExistsException();

            registry.Id = Guid.NewGuid();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                registry.Password = _hashService.GetHash(sha256Hash, password);
            }
            _registryRepository.CreateRegistry(registry);
        }

        public void Authorize(Registry registry, string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                if (!_hashService.VerifyHash(sha256Hash, password, registry.Password)) throw new PasswordNotEqualException();

                Settings.Default.ClientId = registry.Id;
                Settings.Default.ClientFIO = registry.FIO;
                Settings.Default.IsRegistry = true;
                Settings.Default.Save();
            }
        }

        public Registry GetRegistryByLogin(string login) => _registryRepository.GetRegistryByLogin(login);
        public Registry GetRegistryById(Guid id) => _registryRepository.GetRegistryById(id);
    }
}
