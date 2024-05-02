using ControleMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class Funcionario : EntidadeBase
    {
        public Funcionario(string nome, string telefonte, string cpf)
        {
            Nome = nome;
            Telefonte = telefonte;
            Cpf = cpf;
        }

        public string Nome { get; set; }
        public string Telefonte { get; set; }
        public string Cpf { get; set; }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros[contadorErros++] = ("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Telefonte.Trim()))
                erros[contadorErros++] = ("O campo \"Telefone\" é obrigatório");

            if (string.IsNullOrEmpty(Cpf.Trim()))
                erros[contadorErros++] = ("O campo \"CPF\" é obrigatório");

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
