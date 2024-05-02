using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    internal class RequisicaoEntrada : EntidadeBase
    {
        public RequisicaoEntrada(Medicamento medicamento, Fornecedor fornecedor, Funcionario funcionario, int quantidadeRequisitada)
        {
            DataRequisicao = DateTime.Now;
            Medicamento = medicamento;
            Fornecedor = fornecedor;
            Funcionario = funcionario;
            QuantidadeRequisitada = quantidadeRequisitada;
        }

        public DateTime DataRequisicao { get; set; }
        public Medicamento Medicamento { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Funcionario Funcionario { get; set; }
        public int QuantidadeRequisitada { get; set; }
        public override string[] Validar()
        {

            string[] erros = new string[3];
            int contadorErros = 0;

            if (DataRequisicao == null)
                erros[contadorErros++] = "A data precisa ser preenchida";

            if (Medicamento == null)
                erros[contadorErros++] = "O medicamento precisa ser preenchido";

            if (Fornecedor == null)
                erros[contadorErros++] = "O fornecedor precisa ser informado";

            if (Funcionario == null)
                erros[contadorErros++] = "O funcionário precisa ser informado";

            if (QuantidadeRequisitada <= 0)
                erros[contadorErros++] = "Por favor informe uma quantidade válida";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
        public bool AcrescentarMedicamento()
        {
            Medicamento.Quantidade += QuantidadeRequisitada;
            return true;
        }
    }
}
