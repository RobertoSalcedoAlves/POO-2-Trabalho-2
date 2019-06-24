using POO2.Trabalho2.SistemaReservas.ClassesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Sala : ClasseBase<Sala, int>
    {
        public string Nome { get; set; }
        public int NumeroLugares { get; set; }
        protected override int ProximoId { get { return Lista.Count + 1; } }
        public override string Descricao { get => string.Format($"Sala: {this.Nome.ToString()}"); }

        public Sala(string nome, int numeroLugares)
        {
            Id = ProximoId;
            Nome = nome;
            NumeroLugares = numeroLugares;
            Lista.Add(this);
        }

        public IEnumerable<Horario> HorariosOcupados(DateTime data)
        {
            List<Horario> horariosOcupados = new List<Horario>();
            foreach (var reserva in Reserva.Reservas)
                if (reserva.Sala == this && reserva.Data == data)
                    horariosOcupados.Add(reserva.Horario);
            return horariosOcupados;
        }

        public IEnumerable<Horario> HorariosDisponiveis(DateTime data)
        {
            TimeSpan pontoPartida = new TimeSpan(0, 0, 0);
            Horario horarioLivre;
            List<Horario> horariosLivres = new List<Horario>();
            foreach (var reserva in Reserva.Reservas)
                if (reserva.Sala == this && reserva.Data == data)
                {
                    if (pontoPartida < reserva.Horario.Inicio)
                    {
                        horarioLivre = new Horario(pontoPartida, reserva.Horario.Inicio);
                        pontoPartida = reserva.Horario.Fim;
                        horariosLivres.Add(horarioLivre);
                    }
                }
            if (pontoPartida < new TimeSpan(24, 0, 0))
            {
                horarioLivre = new Horario(pontoPartida, new TimeSpan(0, 0, 0));
                horariosLivres.Add(horarioLivre);
            }
            return horariosLivres;
        }

        public bool HorarioEstahDisponivel(DateTime data, Horario horarioDesejado)
        {
            return HorariosDisponiveis(data).Where(x => x.Inicio <= horarioDesejado.Inicio && x.Fim >= horarioDesejado.Fim).Count() > 0;
        }

        public override Sala SelecionarPorId(int id) => Lista.Find(x => x.Id == id);

        public override bool Equals(object obj)
        {
            try
            {
                return ((Sala)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
