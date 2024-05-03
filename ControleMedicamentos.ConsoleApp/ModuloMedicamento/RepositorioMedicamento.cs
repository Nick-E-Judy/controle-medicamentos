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
    }
}