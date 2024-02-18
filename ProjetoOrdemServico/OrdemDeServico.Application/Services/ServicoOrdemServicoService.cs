using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;
using ResTIConnect.Infrastructure.Persistence;

namespace OrdemDeServico.Application.Services
{
    public class ServicoOrdemServicoService : IServicoOrdemServicoService
    {
        private readonly OrdemDeServicoContext _context;
        private readonly IEnderecoService _enderecoService;

        public ServicoOrdemServicoService(OrdemDeServicoContext context, IEnderecoService enderecoService)
        {
            _context = context;
            _enderecoService = enderecoService;
        }

        public int Create(NewServicoOrdemServicoInputModel servicoOrdemServico)
        {
            var _endereco = new Endereco
            {
                Logradouro = servicoOrdemServico.Endereco.Logradouro,
                Bairro = servicoOrdemServico.Endereco.Bairro,
                Numero = servicoOrdemServico.Endereco.Numero,
                Complemento = servicoOrdemServico.Endereco.Complemento,
                Cidade = servicoOrdemServico.Endereco.Cidade,
                Estado = servicoOrdemServico.Endereco.Estado,
                Pais = servicoOrdemServico.Endereco.Pais,
                Cep = servicoOrdemServico.Endereco.Cep,
            };

            _context.Add(_endereco);

            var _servicoOrdemServico = new ServicoOrdemServico
            {
                ServicoId = servicoOrdemServico.ServicoId,
                OrdemServicoId = servicoOrdemServico.OrdemServicoId,
                EnderecoId = _endereco.EnderecoId,

            };

            _context.ServicosOrdensServico.Add(_servicoOrdemServico);
            _context.SaveChanges();

            return _servicoOrdemServico.ServicoOrdemServicoId;
        }
        public void Delete(int id)
        {
            var _ServicoOrdemServicoDb = _context.ServicosOrdensServico.Find(id);

            if (_ServicoOrdemServicoDb is not null)
            {
                _context.ServicosOrdensServico.Remove(_ServicoOrdemServicoDb);
                _context.SaveChanges();
            }
        }
        public void Update(int id, NewServicoOrdemServicoInputModel servicoOrdemServico)
        {
            var _servicoOrdemServicoDb = _context.ServicosOrdensServico.Find(id);

            if (_servicoOrdemServicoDb is null)
            {
                return;
            }

            _enderecoService.Update(_servicoOrdemServicoDb.EnderecoId, servicoOrdemServico.Endereco);

            _servicoOrdemServicoDb.ServicoId = servicoOrdemServico.ServicoId;
            _servicoOrdemServicoDb.OrdemServicoId = servicoOrdemServico.OrdemServicoId;

            _context.ServicosOrdensServico.Update(_servicoOrdemServicoDb);
            _context.SaveChanges();
        }
        public ICollection<ServicoOrdemServicoViewModel> GetAll()
        {
            var _servicoOrdemServico = _context.ServicosOrdensServico.Select(servicoOrdemServico => new ServicoOrdemServicoViewModel
            {
                ServicoId = servicoOrdemServico.ServicoId,
                OrdemServicoId = servicoOrdemServico.OrdemServicoId,
                EnderecoId = servicoOrdemServico.EnderecoId,

            }).ToArray();

            return _servicoOrdemServico;
        }

        public ServicoOrdemServicoViewModel? GetById(int id)
        {
            var _servicoOrdemServicoDb = _context.ServicosOrdensServico.Find(id);

            if (_servicoOrdemServicoDb is null)
            {
                return null;
            }


            var _servicoOrdemServico = new ServicoOrdemServicoViewModel
            {
                ServicoOrdemServicoId = _servicoOrdemServicoDb.ServicoOrdemServicoId,
                ServicoId = _servicoOrdemServicoDb.ServicoId,
                OrdemServicoId = _servicoOrdemServicoDb.OrdemServicoId,
                EnderecoId = _servicoOrdemServicoDb.EnderecoId

            };


            return _servicoOrdemServico;
        }
    }

}
