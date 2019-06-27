using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class RelatorioReservasArquivo : RelatorioBase
    {


        const string NOME_ARQUIVO = @"\Relatório.txt";

        public RelatorioReservasArquivo(DateTime data, Sala sala) { Id = ProximoId; }
        public RelatorioReservasArquivo(DateTime data) { Id = ProximoId; }
        public RelatorioReservasArquivo(Sala sala) { Id = ProximoId; }
        public RelatorioReservasArquivo() { Id = ProximoId; }
        public string Path { get; set; }  
        public override void MontarRelatorio(IEnumerable<Reserva> reservas)
        {
            Console.Write("informe o diretório: ");
            Path = string.Format(@"{0}\{1}", Console.ReadLine().Replace('/', '\\'), NOME_ARQUIVO);
            Stream stream = File.Create(Path);
            try
            {
                using (StreamWriter escritor = new StreamWriter(stream))
                {
                    foreach (var reserva in reservas)
                        escritor.WriteLine(reserva.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível gerar o relatório.\t\nErro: " + e.Message);
                return;
            }
            Console.WriteLine("Relatório gerado em: " + Path.ToString());
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
