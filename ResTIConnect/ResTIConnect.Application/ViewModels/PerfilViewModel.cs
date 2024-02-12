namespace ResTIConnect.Application.ViewModels
{
    public class PerfilViewModel
    {
        public int PerfilId { get; set; }
        public required string Descricao { get; set; }
        public required string Permissoes { get; set; }

        public List<UserViewModel>? Users { get; set; } = new List<UserViewModel>();
    }
}
