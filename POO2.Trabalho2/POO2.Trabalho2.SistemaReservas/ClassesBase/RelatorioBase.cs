using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class RelatorioBase : ClasseBase<RelatorioBase, int>, IRelatorio
    {
        public RelatorioBase(DateTime data, Sala sala) { GerarRelatorio(data, sala); }
        public RelatorioBase(DateTime data) { GerarRelatorio(data); }
        public RelatorioBase(Sala sala) { GerarRelatorio( sala); }
        public RelatorioBase( ){ GerarRelatorio(); }
        public override string Descricao {
            get {
                StringBuilder retorno = new StringBuilder();

                foreach (var reserva in Reserva.Reservas)
                {
                    retorno.AppendLine(reserva.ToString());
                }
                return retorno.ToString();
            }
        }
        public override RelatorioBase SelecionarPorId(int id) => Lista.Find(x => x.Id == id);
        public abstract void MontarRelatorio(IEnumerable<Reserva> reservas);
        public abstract void GerarRelatorio();
        public abstract void GerarRelatorio(Sala sala);
        public abstract void GerarRelatorio(DateTime data);
        public abstract void GerarRelatorio(DateTime data, Sala sala);

        public override void SubMenu()
        {

        }
    }
}
