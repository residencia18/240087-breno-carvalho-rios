using System.Text.RegularExpressions;
using FluentValidation;
using TechMed.Application.InputModels;

namespace TechMed.Application.Validators;
public class NewPacienteValidator : AbstractValidator<NewPacienteInputModel>
{
    public NewPacienteValidator(){
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome não pode estar vazio");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("Email não pode estar vazio")
            .EmailAddress().WithMessage("Email inválido");

        RuleFor(p => p.Cpf)
            .NotEmpty().WithMessage("CPF não pode estar vazio")
            .Must(ValidateCpf).WithMessage("CPF não está no formato XXX.XXX.XXX-XX");
    }

    public bool ValidateCpf(string _cpf){
        return Regex.IsMatch(_cpf, "[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}");
    }
}
