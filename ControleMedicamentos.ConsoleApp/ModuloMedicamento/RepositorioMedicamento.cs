using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    internal class RepositorioMedicamento : RepositorioBase
    {
        public override void RegistrarItem(EntidadeBase novoRegistro)
        {
            Medicamento novoMedicamento = ((Medicamento)novoRegistro);
            for (int i = 0; i < registros.Length; i++)
            {
                Medicamento medicamentoAtual = (Medicamento)registros[i];
                if (registros[i] != null && medicamentoAtual.Nome == novoMedicamento.Nome)
                {
                    medicamentoAtual.Quantidade += novoMedicamento.Quantidade;
                    return;
                }

                for (int j = 0; j < registros.Length; j++)
                {
                    if (registros[j] == null)
                    {
                        registros[j] = novoMedicamento;
                        return;
                    }
                }
            }
        }

        public Medicamento[] MedicamentosPoucaQuantidade(int limite)
        {
            int contador = 0;

            foreach (Medicamento medicamento in registros)
            {
                if (medicamento != null && medicamento.Quantidade < limite && medicamento.Quantidade > 0)
                {
                    contador++;
                }
            }

            Medicamento[] medicamentosPoucaQuantidade = new Medicamento[contador];
            int index = 0;

            foreach (Medicamento medicamento in registros)
            {
                if (medicamento != null && medicamento.Quantidade < limite && medicamento.Quantidade > 0)
                {
                    medicamentosPoucaQuantidade[index] = medicamento;
                    index++;
                }
            }

            return medicamentosPoucaQuantidade;
        }

        public Medicamento[] MedicamentosEmFalta()
        {
            int contador = 0;

            foreach (Medicamento medicamento in registros)
            {
                if (medicamento != null && medicamento.Quantidade == 0)
                {
                    contador++;
                }
            }

            Medicamento[] medicamentosEmFalta = new Medicamento[contador];
            int index = 0;

            foreach (Medicamento medicamento in registros)
            {
                if (medicamento != null && medicamento.Quantidade == 0)
                {
                    medicamentosEmFalta[index] = medicamento;
                    index++;
                }
            }

            return medicamentosEmFalta;
        }

    }
}