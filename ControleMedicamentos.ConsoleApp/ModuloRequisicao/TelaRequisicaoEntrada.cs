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
    internal class TelaRequisicaoEntrada : TelaBase
    {
        public TelaMedicamento telaMedicamento = null;
        public TelaFornecedor telaFornecedor = null;
        public TelaFuncionario telaFuncionario = null;

        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioFuncionario repositorioFuncionario = null;

        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            RequisicaoEntrada entidade = (RequisicaoEntrada)ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"A {tipoEntidade} foi cadastrada com sucesso!", ConsoleColor.Green);
        }


        public override void VisualizarRegistros(bool exibirTitulo)
        {
            throw new NotImplementedException();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite o ID do medicamento requisitado: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());

            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            telaFornecedor.VisualizarRegistros(false);

            Console.Write("Digite o ID do fornecedor requisitante: ");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());

            Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);

            telaFuncionario.VisualizarRegistros(false);

            Console.Write("Digite o ID do funcionário requisitante: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());

            Funcionario funcionarioSelecionado = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            Console.Write("Digite a quantidade do medicamente que deseja acrescentar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            RequisicaoEntrada novaRequisicao = new RequisicaoEntrada(medicamentoSelecionado, fornecedorSelecionado, funcionarioSelecionado, quantidade);

            return novaRequisicao;
        }
    }
}
