using GraduateWorkCompany.Data.Models;
using GraduateWorkCompany.Data.Repositories;
using GraduateWorkCompany.Domain.Exception;
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

        public async Task<Client> GetClientById(Guid id)
        {
            return await _clientRepository.GetClilentById(id).ConfigureAwait(false);
        }

        public async Task CreateClient(Client client, string rePassword, string password)
        {
            if (password != rePassword) throw new PasswordNotEqualException();
            if (password == null || rePassword == null) throw new PasswordIsEmptyException();
            var existclient = await _clientRepository.GetClientByLogin(client.Login).ConfigureAwait(false);
            if (existclient != null) throw new LoginIsAlreadyExistsException();
            existclient = await _clientRepository.GetClientByPhone(client.Phone).ConfigureAwait(false);
            if (existclient != null) throw new PhoneIsAlreadyExistsException();

            client.Id = Guid.NewGuid();
            client.CreatedAt = DateTime.UtcNow;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                client.Password = _hashService.GetHash(sha256Hash, password);
            }
            await _clientRepository.CreateClient(client).ConfigureAwait(false);
        }
    }
}
