using POO2.Trabalho2.SistemaReservas.ClassesBase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class RelatorioReservasConsole : RelatorioBase
    {
        public RelatorioReservasConsole(DateTime data, Sala sala) : base(data, sala) { }
        public RelatorioReservasConsole(DateTime data) : base(data) { }
        public RelatorioReservasConsole(Sala sala) : base(sala) { }
        public RelatorioReservasConsole() { }

        public override void MontarRelatorio(IEnumerable<Reserva> reservas)
        {
            foreach (var reserva in reservas)
                Console.WriteLine(reserva.ToString());
            Console.WriteLine("Relatório gerado com sucesso!");
        }

        public override void GerarRelatorio()
        {
            MontarRelatorio(Reserva.Reservas);
        }

        public override void GerarRelatorio(Sala sala)
        {
            MontarRelatorio(Reserva.Reservas.Where(x => x.Sala == sala));
        }

        public override void GerarRelatorio(DateTime data)
        {
            MontarRelatorio(Reserva.Reservas.Where(x => x.Data == data));
        }

        public override void GerarRelatorio(DateTime data, Sala sala)
        {
            MontarRelatorio(Reserva.Reservas.Where(x => x.Data == data && x.Sala == sala));
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

    }
}
