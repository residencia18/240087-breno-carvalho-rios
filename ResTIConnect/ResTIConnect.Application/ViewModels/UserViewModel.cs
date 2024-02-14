

using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Application.ViewModels
{
   public class UserViewModel
    {
        public int UserId { get; set; }
        public required string Nome { get; set; }
        public required string Apelido{ get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Telefone { get; set; }
        
    }
}
