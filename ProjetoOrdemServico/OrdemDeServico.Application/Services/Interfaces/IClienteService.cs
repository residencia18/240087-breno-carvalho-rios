﻿using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.ViewModels;
using OrdemDeServico.Domain.Entities;

namespace OrdemDeServico.Application.Services.Interfaces;

public interface IClienteService : IBaseService<NewClienteInputModel, ClienteViewModel>
{
    public Cliente MapClienteInputModelToCliente(NewClienteInputModel cliente);
    public ClienteViewModel MapClienteToClienteViewModel(Cliente cliente);
}
