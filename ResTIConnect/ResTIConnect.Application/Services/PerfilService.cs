using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infrastructure.Context;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly ResTIConnectDbContext _context;

        public PerfilService(ResTIConnectDbContext context)
        {
            _context = context;
        }
        public int Create(NewPerfilInputModel perfil)
        {   
            // CREATE / UPDATE
            // Depois de implementar usuario substituir por:
            // var _usuario = _usuariosService.GetByDbId(perfil.UsuarioId);
            var _usuario = _context.Usuarios.Find(perfil.UsuarioId);
            
            if(_usuario is null) {
                throw new UsuarioNotFoundException();
            }

            var _perfil = new Perfil
            {
                Descricao = perfil.Descricao,
                Permissoes = perfil.Permissoes,
                Usuario = _usuario
            };

            _context.Perfis.Add(_perfil);
            _context.SaveChanges();

            return _perfil.PerfilId;
        }

        public List<PerfilViewModel> GetAll()
        {
            var perfis = _context.Perfis
                .Select(p => new PerfilViewModel
                {
                    PerfilId = p.PerfilId,
                    Descricao = p.Descricao ?? "",
                    Permissoes = p.Permissoes
                })
                .ToList();

            return perfis;
        }

        private Perfil GetByDbId(int id)
        {
            var _perfil = _context.Perfis.Find(id);

            if (_perfil is null)
                throw new PerfilNotFoundException();

            return _perfil;
        }
        public void Update(int id, NewPerfilInputModel perfil)
        {
            var _perfil = GetByDbId(id);

            _perfil.Descricao = perfil.Descricao;
            _perfil.Permissoes = perfil.Permissoes;

            // Depois de implementar usuario substituir por:
            // var _usuario = _usuariosService.GetByDbId(perfil.UsuarioId);
            var _usuario = _context.Usuarios.Find(perfil.UsuarioId);
            if(_usuario is not null) {
                _perfil.Usuario = _usuario;
            }

            _context.Perfis.Update(_perfil);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Perfis.Remove(GetByDbId(id));
            _context.SaveChanges();
        }
        public PerfilViewModel? GetById(int id)
        {
            var perfil = GetByDbId(id);

            var perfilViewModel = new PerfilViewModel
            {
                PerfilId = perfil.PerfilId,
                Descricao = perfil.Descricao ?? "",
                Permissoes = perfil.Permissoes
            };
            return perfilViewModel;
        }

        public List<PerfilViewModel> GetByUserId(int userId)
        {   
            var perfis = _context.Perfis
               .Where(p => p.UsuarioId == userId)
               .Select(p => new PerfilViewModel
               {
                   PerfilId = p.PerfilId,
                   Descricao = p.Descricao ?? "",
                   Permissoes = p.Permissoes
               })
               .ToList();

            return perfis;
        }
    }
}

