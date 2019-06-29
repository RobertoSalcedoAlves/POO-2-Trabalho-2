using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class RelatorioReservasConsole : RelatorioBase
    {
        public RelatorioReservasConsole(DateTime data, Sala sala, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            itens.AddLast(this);
        }
        public RelatorioReservasConsole(DateTime data, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            itens.AddLast(this);
        }
        public RelatorioReservasConsole(Sala sala, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            itens.AddLast(this);
        }
        public RelatorioReservasConsole(LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            itens.AddLast(this);
        }
        public override void MontarRelatorio(LinkedList<object> reservas)
        {
            foreach (var reserva in reservas)
                Console.WriteLine(reserva.ToString());
            Console.WriteLine("Relatório gerado com sucesso!");
        }
        public override bool Equals(object obj)
        {
            try
            {
                return ((RelatorioReservasConsole)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }
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
