using System;
using System.Collections.Generic;
using System.Text;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Reserva : ClasseBase<Reserva, int>
    {
        public static List<Reserva> Reservas = new List<Reserva>();

        public Funcionario Funcionario { get; set; }
        public Sala Sala { get; set; }
        public DateTime Data { get; set; }
        public Horario Horario { get; set; }
        public override string Descricao {
            get {
                StringBuilder retorno = new StringBuilder();
                retorno.AppendLine($"Nº: {this.Id.ToString()} | ");
                retorno.AppendLine($"{this.Sala.ToString()}\t\n");
                retorno.AppendLine($"{this.Funcionario.ToString()}\t\n");
                retorno.AppendLine($"{this.Data.ToString("dd/mm/aaa")} | ");
                retorno.AppendLine($"{this.Horario.ToString()}");
                return retorno.ToString();
            }
        }

        public Reserva(Funcionario funcionario, Sala sala, DateTime data, Horario horario)
        {
            Funcionario = funcionario;
            Sala = sala;
            Data = data;
            Horario = horario;
            Lista.Add(this);
            Reservas.Add(this);
        }

        public override Reserva SelecionarPorId(int id) => Lista.Find(x => x.Id == id);

        public override bool Equals(object obj)
        {
            try
            {
                return ((Reserva)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
