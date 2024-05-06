using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class TelaMedicamento : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Medicamentos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20}",
                "Id", "Nome", "Quantidade"
            );

            EntidadeBase[] medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach (Medicamento medicamento in medicamentosCadastrados)
            {
                if (medicamento == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -20}",
                    medicamento.Id, medicamento.Nome, medicamento.Quantidade
                );
            }

            Console.ReadLine();
        }

        public void MedicamentosPoucaQuantidade(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();
                Console.WriteLine("Visualizando medicamentos com baixa quantidade...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                "Id", "Nome", "Descrição", "Quantidade"
                );

            Medicamento[] medicamentosPoucaQuantidade = ((RepositorioMedicamento)repositorio).MedicamentosPoucaQuantidade(10);

            if (medicamentosPoucaQuantidade.Length == 0)
            {
                ExibirMensagem("Nenhum medicamento com pouca quantidade encontrado.", ConsoleColor.Red);
            }
            else
            {
                foreach (Medicamento m in medicamentosPoucaQuantidade)
                {
                    Console.WriteLine(
                        "| {0, -10} | {1, -15} | {2, -15} | {3, -10} |",
                        m.Id, m.Nome, m.Descricao, m.Quantidade
                        );
                }
            }

            Console.ReadLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data de validade: ");
            DateTime dataValidade = Convert.ToDateTime(Console.ReadLine());

            Medicamento medicamento = new Medicamento(nome, descricao, quantidade, dataValidade);

            return medicamento;
        }
    }
}
