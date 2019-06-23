using POO2.Trabalho2.SistemaReservas.ClassesBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class RelatorioReservasArquivo : RelatorioBase
    {
        const string path = @"C:\Relatório de Reservas.txt";

        public RelatorioReservasArquivo(DateTime data, Sala sala) : base(data, sala) { }
        public RelatorioReservasArquivo(DateTime data) : base(data) { }
        public RelatorioReservasArquivo(Sala sala) : base(sala) { }
        public RelatorioReservasArquivo() { }

        public override void MontarRelatorio(IEnumerable<Reserva> reservas)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(path))
                {
                    foreach (var reserva in reservas)
                        escritor.WriteLine(reserva.ToString() + "\t\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível gerar o relatório.\t\nErro: " + e.Message);
            }
            Console.WriteLine("Relatório gerado em: " + path.ToString());
        }

        public override void GerarRelatorio()
        {
            MontarRelatorio(Reserva.Reservas); ;
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
                return ((RelatorioReservasArquivo)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
