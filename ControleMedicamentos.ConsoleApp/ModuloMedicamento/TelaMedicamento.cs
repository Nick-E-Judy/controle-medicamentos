using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

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

            Console.WriteLine("Legenda: ");
            Console.WriteLine("Branco - Medicamento com estoque");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Amarelo - Medicamento com baixo estoque");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vermelho - Medicamento em falta");
            Console.ResetColor();

            Console.WriteLine();

            Console.WriteLine("| {0, -10} | {1, -20} | {2, -35} | {3, -10} |", 
                "Id", "Nome", "Descrição", "Quantidade");

            EntidadeBase[] medicamentosCadastrados = repositorio.SelecionarTodos();

            foreach (Medicamento medicamento in medicamentosCadastrados)
            {
                if (medicamento == null)
                    continue;

                ConsoleColor linhaCor = ConsoleColor.White;
                if (medicamento.Quantidade == 0)
                {
                    linhaCor = ConsoleColor.Red; 
                }
                else if (medicamento.Quantidade < 20 && medicamento.Quantidade > 0)
                {
                    linhaCor = ConsoleColor.Yellow;
                }

                Console.ResetColor();

                Console.ForegroundColor = linhaCor;

                Console.WriteLine("| {0, -10} | {1, -20} | {2, -35} | {3, -10} |",
                    medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.Quantidade);

                Console.ResetColor();
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

        public void CadastrarEntidadeTeste()
        {
            Medicamento medicamento = new Medicamento("Dorflex", "Remédio para dor muscular", 25, new DateTime(2025, 12, 3));
            Medicamento medicamento1 = new Medicamento("Buscopan", "Remédio para cólica", 5, new DateTime(2025, 12, 3));
            Medicamento medicamento2 = new Medicamento("Paracetamol", "Remédio para dor de cabeça", 0, new DateTime(2025, 12, 3));
            Medicamento medicamento3 = new Medicamento("Benegripe", "Remédio para gripe", 40, new DateTime(2025, 12, 3));

            repositorio.Cadastrar(medicamento);
            repositorio.Cadastrar(medicamento1);
            repositorio.Cadastrar(medicamento2);
            repositorio.Cadastrar(medicamento3);

        }
    }
}
