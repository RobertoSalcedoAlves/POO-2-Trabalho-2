using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Sala : ClasseBase<Sala, int>
    {
        public Sala(string nome, int numeroLugares, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            Nome = nome;
            NumeroLugares = numeroLugares;
            Lista.AddLast(this);
            itens.AddLast(this);
        }
        public string Nome { get; set; }
        public int NumeroLugares { get; set; }
        public override string Descricao { get => string.Format($"Sala: {this.Nome.ToString()}"); }
        public IEnumerable<Horario> HorariosOcupados(DateTime data)
        {
            List<Horario> horariosOcupados = new List<Horario>();
            foreach (var reserva in MenuHelper.Reservas)
                if (((Reserva)reserva).Sala == this && ((Reserva)reserva).Data == data)
                    horariosOcupados.Add(((Reserva)reserva).Horario);
            return horariosOcupados;
        }
        public IEnumerable<Horario> HorariosDisponiveis(DateTime data)
        {
            TimeSpan pontoPartida = new TimeSpan(0, 0, 0);
            Horario horarioLivre;
            List<Horario> horariosLivres = new List<Horario>();
            foreach (var reserva in MenuHelper.Reservas)
            {
                if (((Reserva)reserva).Sala == this && ((Reserva)reserva).Data == data)
                {
                    if (pontoPartida < ((Reserva)reserva).Horario.Inicio)
                    {
                        horarioLivre = new Horario(pontoPartida, ((Reserva)reserva).Horario.Inicio, MenuHelper.Horarios);
                        pontoPartida = ((Reserva)reserva).Horario.Fim;
                        horariosLivres.Add(horarioLivre);
                    }
                }
            }
            if (pontoPartida < new TimeSpan(24, 0, 0))
            {
                horarioLivre = new Horario(pontoPartida, new TimeSpan(0, 0, 0), MenuHelper.Horarios);
                horariosLivres.Add(horarioLivre);
            }
            return horariosLivres;
        }
        public bool HorarioEstahDisponivel(DateTime data, Horario horarioDesejado)
        {
            return HorariosDisponiveis(data).Where(x => x.Inicio <= horarioDesejado.Inicio && x.Fim >= horarioDesejado.Fim).Count() > 0;
        }
        public override Sala SelecionarPorId(int id) => Lista.FirstOrDefault(x => x.Id == id);
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
        public override void SubMenu()
        {

        }

        public override void TopoMenu(string subTitulo, string instrucao, List<string> Opcoes, ref bool explorando)
        {
            throw new NotImplementedException();
        }

        public override void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }

        public override void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
    }
}
