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
    public class Horario : ClasseBase<Horario, int>
    {
        public Horario(TimeSpan horaInicio, TimeSpan horaFim, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            Inicio = horaInicio;
            Fim = horaFim;
            itens.AddLast(this);
            //Lista.Add(this);
        }
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
        public override Horario SelecionarPorId(int id) => Lista.FirstOrDefault(x => x.Id == id);
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
