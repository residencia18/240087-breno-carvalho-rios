using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace AvaliacaoDotNet
{
    public class Cliente : Pessoa
    {
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        
        public Cliente(){
        
        }
        public Cliente(string nome, string cpf, DateTime dataNascimento, string estadoCivil = "Não informado", string profissao = "Não informado")
        : base(nome, dataNascimento, cpf, idade: 0)
        {
            this.EstadoCivil = estadoCivil;
            this.Profissao = profissao;
            // Calcular a idade ao criar o objeto
            this.Idade = Pessoa.CalcularIdade(this.DataNascimento);
        }

        public static int LerNumeroInteiro(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);

                string input = Console.ReadLine()!;

                if (string.IsNullOrEmpty(input))
                {
                    App.LimparTela();
                    Console.WriteLine("\n\tEntrada inválida. Por favor, insira um valor numérico.");
                    continue;
                }

                if (int.TryParse(input, out int valor))
                {
                    return valor;
                }
                else
                {
                    App.LimparTela();
                    Console.WriteLine("\n\tEntrada inválida. Por favor, insira um valor numérico válido.");
                }
                App.Pause();
            }
        }

        public static bool IsCpfUnico(string cpf, List<Cliente> clientes)
        {
            // Verifica se o CPF é válido antes de proceder
            if (!Pessoa.IsValidCPF(cpf))
            {
                throw new ArgumentException("\n\tOps, CPF inválido!...");
            }

            // Verifica se o CPF já existe na lista de pacientes
            return !clientes.Any(paciente => paciente.Cpf == cpf);
        }

        public static bool estadoCivil(String estadoCivil)
        {

            if (estadoCivil == "Solteiro" || estadoCivil == "Casado" || estadoCivil == "Divorciado" || estadoCivil == "Viúvo")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}