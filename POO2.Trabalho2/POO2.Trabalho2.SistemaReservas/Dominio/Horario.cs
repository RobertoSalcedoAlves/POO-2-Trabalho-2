using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Horario : ClasseBase<Horario, int>
    {
        public TimeSpan Inicio { get; set; }
        public TimeSpan Fim { get; set; }
        public TimeSpan DuracaoPrevista => Fim - Inicio;
        public override string Descricao {
            get {
                return string.Format(
                    $"{Inicio.Hours.ToString()}:{Inicio.Minutes.ToString()} " +
                    $"às {Fim.Hours.ToString()}:{Fim.Minutes.ToString()}");
            }
        }

        public Horario(TimeSpan horaInicio, TimeSpan horaFim)
        {
            Inicio = horaInicio;
            Fim = horaFim;
            Lista.Add(this);
        }

        public override Horario SelecionarPorId(int id) => Lista.Find(x => x.Id == id);

        public override bool Equals(object obj)
        {
            try
            {
                return ((Horario)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
