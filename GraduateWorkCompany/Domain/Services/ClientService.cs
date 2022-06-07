using GraduateWorkCompany.Data.Models;
using GraduateWorkCompany.Data.Repositories;
using GraduateWorkCompany.Domain.Exception;
using GraduateWorkCompany.Properties;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Domain.Services
{
    public class ClientService
    {
        private readonly ClientRepository _clientRepository;
        private readonly HashSevice _hashService;

        public ClientService()
        {
            _clientRepository = new ClientRepository();
            _hashService = new HashSevice();
        }

        public Client GetClientById(Guid id)
        {
            return _clientRepository.GetClilentById(id);
        }

        public void CreateClient(Client client, string rePassword, string password)
        {
            if (password != rePassword) throw new PasswordNotEqualException();
            if (password == null || rePassword == null) throw new PasswordIsEmptyException();
            var existclient = _clientRepository.GetClientByLogin(client.Login);
            if (existclient != null) throw new LoginIsAlreadyExistsException();
            existclient = _clientRepository.GetClientByPhone(client.Phone);
            if (existclient != null) throw new PhoneIsAlreadyExistsException();

            client.Id = Guid.NewGuid();
            client.CreatedAt = DateTime.UtcNow;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                client.Password = _hashService.GetHash(sha256Hash, password);
            }
            _clientRepository.CreateClient(client);
        }

        public void Authorize(Client client, string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                if(!_hashService.VerifyHash(sha256Hash, password, client.Password)) throw new PasswordNotEqualException();

                Settings.Default.ClientId = client.Id;
                Settings.Default.ClientFIO = client.FIO;
                Settings.Default.IsRegistry = false;
                Settings.Default.Save();
            }
        }

        public Client GetClientByLogin(string login)
        {
            return _clientRepository.GetClientByLogin(login);
        }
    }
}
