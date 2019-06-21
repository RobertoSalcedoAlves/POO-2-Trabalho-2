using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Reserva : ClasseBase<Reserva, int>
    {
        public Funcionario Funcionario { get; set; }
        public Sala Sala { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan DuracaoPrevista { get; set; }
        public TimeSpan HoraFim => HoraInicio.Add(DuracaoPrevista.Add(TimeSpan.FromMinutes(30)));

        public Reserva(Funcionario funcionario, Sala sala, DateTime data, TimeSpan horaInicio, TimeSpan duracao)
        {
            Funcionario = funcionario;
            Sala = sala;
            Data = data;
            HoraInicio = horaInicio;
            DuracaoPrevista = duracao;
        }

        public override Reserva SelecionarPorId(int id) => Lista.Find(x => x.Id == id);
    }
}
