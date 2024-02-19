using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrdemDeServico.Application.Services
{
    public class ServicoService : IServicoService
    {
        private readonly OrdemDeServicoContext _context;

        public ServicoService(OrdemDeServicoContext context)
        {
            _context = context;
        }

        public int Create(NewServicoInputModel servico)
        {
            var novoServico = new Servico
            {
                Nome = servico.Nome,
                Descricao = servico.Descricao,
                Precos = servico.Precos
            };

            _context.Servicos.Add(novoServico);
            _context.SaveChanges();

            return novoServico.ServicoId;
        }

        public void Delete(int id)
        {
            var servico = _context.Servicos.Find(id);

            if (servico != null)
            {
                _context.Servicos.Remove(servico);
                _context.SaveChanges();
            }
        }

        public ICollection<ServicoViewModel> GetAll()
        {
            var servicos = _context.Servicos
                .Select(servico => new ServicoViewModel
                {
                    ServicoId = servico.ServicoId,
                    Nome = servico.Nome,
                    Descricao = servico.Descricao,
                    Precos = servico.Precos
                })
                .ToList();

            return servicos;
        }

        public ServicoViewModel? GetById(int id)
        {
            var servico = _context.Servicos.Find(id);

            if (servico == null)
                return null;

            var servicoViewModel = new ServicoViewModel
            {
                ServicoId = servico.ServicoId,
                Nome = servico.Nome,
                Descricao = servico.Descricao,
                Precos = servico.Precos
            };

            return servicoViewModel;
        }

        public void Update(int id, NewServicoInputModel servico)
        {
            var servicoToUpdate = _context.Servicos.Find(id);

            if (servicoToUpdate != null)
            {
                servicoToUpdate.Nome = servico.Nome;
                servicoToUpdate.Descricao = servico.Descricao;
                servicoToUpdate.Precos = servico.Precos;

                _context.Servicos.Update(servicoToUpdate);
                _context.SaveChanges();
            }
        }

        public List<ServicoViewModel> GetByNome(string nome)
        {
            var servicos = _context.Servicos
                .Where(servico => servico.Nome == nome)
                .Select(servico => new ServicoViewModel
                {
                    ServicoId = servico.ServicoId,
                    Nome = servico.Nome,
                    Descricao = servico.Descricao,
                    Precos = servico.Precos
                }).ToList();

            return servicos;
        }
    }
}
