using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.ClassesBase
{
    public abstract class RelatorioBase : ClasseBase<RelatorioBase, int>, IRelatorio
    {
        public static Reserva Reserva { get; set; }
        public abstract void GerarRelatorio();

        public override RelatorioBase SelecionarPorId(int id) => Lista.Find(x => x.Id == id);
        
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            foreach (var reserva in Reserva.Lista)
            {

            }
            return retorno.ToString();
        }
    }
}
