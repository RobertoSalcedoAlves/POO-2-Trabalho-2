using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.Util;
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
        protected override int ProximoId { get { return Lista.Count + 1; } }
        public override string Descricao {
            get {
                StringBuilder retorno = new StringBuilder();
                retorno.Append($"{this.Id.ToString()} | ");
                retorno.AppendLine($"{this.Sala.ToString()}");
                retorno.Append($"{this.Data.ToString("dd/MM/yy")} | ");
                retorno.AppendLine($"{this.Horario.ToString()}");
                retorno.AppendLine($"{this.Funcionario.ToString()}");
                return retorno.ToString();
            }
        }
        public Reserva(Funcionario funcionario, Sala sala, DateTime data, Horario horario)
        {
            Id = ProximoId;
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
        public override void SubMenu()
        {

        }
    }
}
