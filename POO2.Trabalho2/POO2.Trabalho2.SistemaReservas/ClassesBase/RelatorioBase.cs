using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class RelatorioBase : ClasseBase<RelatorioBase, int>, IRelatorio
    {
        public RelatorioBase(DateTime data, Sala sala, LinkedList<object> itens) : base(itens)
        {
            GerarRelatorio(data, sala);
            itens.AddLast(this);
        }
        public RelatorioBase(DateTime data, LinkedList<object> itens) : base(itens)
        {
            GerarRelatorio(data);
            itens.AddLast(this);
        }
        public RelatorioBase(Sala sala, LinkedList<object> itens) : base(itens)
        {
            GerarRelatorio( sala);
            itens.AddLast(this);
        }
        public RelatorioBase(LinkedList<object> itens) : base(itens)
        {
            GerarRelatorio();
            itens.AddLast(this);
        }
        public override string Descricao {
            get {
                StringBuilder retorno = new StringBuilder();

                foreach (var reserva in MenuHelper.Reservas)
                {
                    retorno.AppendLine(retorno.ToString());
                }
                return retorno.ToString();
            }
        }
        public override RelatorioBase SelecionarPorId(int id) => Lista.FirstOrDefault(x => x.Id == id);
        public abstract void MontarRelatorio(LinkedList<object> reservas);
        public void GerarRelatorio()
        {
            MontarRelatorio(MenuHelper.Reservas);
        }
        public void GerarRelatorio(Sala sala)
        {
            LinkedList<object> lista = new LinkedList<object>();
            foreach (var reserva in MenuHelper.Reservas.Where(x => ((Reserva)x).Sala == sala))
                lista.AddLast(reserva);
            MontarRelatorio(lista);
        }
        public void GerarRelatorio(DateTime data)
        {
            LinkedList<object> lista = new LinkedList<object>();
            foreach (var reserva in MenuHelper.Reservas.Where(x => ((Reserva)x).Data == data))
                lista.AddLast(reserva);
            MontarRelatorio(lista);
        }
        public void GerarRelatorio(DateTime data, Sala sala)
        {
            LinkedList<object> lista = new LinkedList<object>();
            foreach (var reserva in MenuHelper.Reservas.Where(x => ((Reserva)x).Data == data && ((Reserva)x).Sala == sala))
                lista.AddLast(reserva);
            MontarRelatorio(lista);
        }
        public override void TopoMenu(string subTitulo, string instrucao, List<string> Opcoes, ref bool explorando)
        {
            Console.Clear();
            Titulo1();
            Titulo2(subTitulo);
            Numeracao(Opcoes, Dir.H);
            Instrucao(instrucao);
            Linha('-');
            Escolher();
        }
        public override void SubMenu()
        {
            string subTitulo = "Relatório de Reservas";
            string instrucao = "onde deseja salvar o relatório? | Seta <-<- Menu Anterior";
            string informado = string.Empty;
            bool navegando = true;
            Ler = false;
            do
            {
                TopoMenu(subTitulo, instrucao, new List<string> { "Computador", "Pasta Virtual" }, ref navegando);
                if (Voltou) { break; }///SETA ESQUERDA
                if (Opcao1) { SalvarRelatorioComputador(); }///COMPUTADOR
                if (Opcao2) { SalvarRelatorioVirtual(ref navegando); }///VIRTUAL
                Acao = Console.ReadKey(false);
            }
            while (!Saiu);
        }

        private void SalvarRelatorioVirtual(ref bool navegando)
        {
            RelatorioReservasConsole relatorio = new RelatorioReservasConsole(MenuHelper.RelatoriosArquivo);
            relatorio.MontarRelatorio(MenuHelper.Reservas);
        }

        private void SalvarRelatorioComputador()
        {
            RelatorioReservasArquivo relatorio = new RelatorioReservasArquivo(MenuHelper.RelatoriosArquivo);
            relatorio.MontarRelatorio(MenuHelper.Reservas);
        }
    }
}
