using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infrastructure.Context;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
namespace ResTIConnect.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ResTIConnectContext _context;

        public UserService(ResTIConnectContext context)
        {
            _context = context;
        }

        public int Create(NewUserInputModel user)
        {
            var _User = new User
            {
                Nome = user.Nome,
                Apelido = user.Apelido,                
                Email = user.Email,
                Senha = user.Senha,
                Telefone = user.Telefone,                            
                Perfis = new List<Perfis>(),
                Sistemas = new List<Sistema>()
            
            };

            _context.Users.Add(_User);
            _context.SaveChanges();

            return _User.UserId;
        }

        public List<UserViewModel> GetAll()
        {
            var user = _context.Users
                .Select(u => new UserViewModel
                {
                    UserId = u.UserId,
                    Nome = u.Nome,
                    Apelido = u.Apelido,
                    Email = u.Email,
                    Senha = u.Senha,
                    Telefone = u.Telefone
                })
                .ToList();

            return user;
        }

        private User GetByDbId(int id)
        {
            var user = _context.Users.Find(id);

            if (user is null)
                throw new UserNotFoundException();

            return user;
        }

        public void Update(int id, NewUserInputModel user)
        {
            var existingUser = GetByDbId(id);
            existingUser.Nome = user.Nome;
            existingUser.Apelido = user.Apelido;
            existingUser.Email = user.Email;
            existingUser.Senha = user.Senha;
            existingUser.Telefone = user.Telefone;

            _context.Users.Update(existingUser);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public UserViewModel? GetById(int id)
        {
            var user = GetByDbId(id);

            var userViewModel = new UserViewModel
            {
                UserId = user.UserId,
                Nome = user.Nome,
                Apelido = user.Apelido,
                Email = user.Email,
                Senha = user.Senha,
                Telefone = user.Telefone
            };

            return userViewModel;
        }

        public List<UserViewModel> GetByPerfilId(int userId)
        {
            var users = _context.Users
                .Where(u => u.Perfis.Any(p => p.PerfilId == userId))
                .Select(u => new UserViewModel
                {                
                    UserId = u.UserId,
                    Nome = u.Nome,
                    Apelido = u.Apelido,
                    Email = u.Email,
                    Senha = u.Senha,
                    Telefone = u.Telefone
                    
                })
                .ToList();

            return users;
        }
    }
}
