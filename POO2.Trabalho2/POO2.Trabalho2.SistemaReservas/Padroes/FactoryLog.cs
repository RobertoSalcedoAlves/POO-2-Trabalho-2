using POO2.Trabalho2.SistemaReservas.Dominio;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using System;

namespace POO2.Trabalho2.SistemaReservas
{
    public class FactoryLog
    {
        public IRelatorio getRelatorio(TipoRelatorio tipoRelatorio, DateTime data, Sala sala)
        {
            return MontarRelatorio(tipoRelatorio);
        }

        public IRelatorio getRelatorio(TipoRelatorio tipoRelatorio, DateTime data)
        {
            return MontarRelatorio(tipoRelatorio);
        }

        public IRelatorio getRelatorio(TipoRelatorio tipoRelatorio, Sala sala)
        {
            return MontarRelatorio(tipoRelatorio);
        }

        public IRelatorio getRelatorio(TipoRelatorio tipoRelatorio)
        {
            return MontarRelatorio(tipoRelatorio);
        }

        private IRelatorio MontarRelatorio(TipoRelatorio tipoRelatorio, DateTime data = new DateTime(), Sala sala = null)
        {
            SubTipoRelatorio subTipoRelatorio = DefinirConstrutor(data, sala);

            if (tipoRelatorio == TipoRelatorio.Arquivo)
                switch (subTipoRelatorio)
                {
                    case SubTipoRelatorio.Completo: return new RelatorioReservasArquivo();
                    case SubTipoRelatorio.DataSala: return new RelatorioReservasArquivo(data, sala);
                    case SubTipoRelatorio.Data: return new RelatorioReservasArquivo(data);
                    case SubTipoRelatorio.Sala: return new RelatorioReservasArquivo(sala);
                }
            else
                switch (subTipoRelatorio)
                {
                    case SubTipoRelatorio.Completo: return new RelatorioReservasConsole();
                    case SubTipoRelatorio.DataSala: return new RelatorioReservasArquivo(data, sala);
                    case SubTipoRelatorio.Data: return new RelatorioReservasArquivo(data);
                    case SubTipoRelatorio.Sala: return new RelatorioReservasArquivo(sala);
                }
            return new RelatorioReservasConsole();
        }

        private SubTipoRelatorio DefinirConstrutor(DateTime data = new DateTime(), Sala sala = null)
        {
            if (data.Date != DateTime.MinValue && sala != null) { return SubTipoRelatorio.DataSala; }
            if (data.Date == DateTime.MinValue && sala != null) { return SubTipoRelatorio.Sala; }
            if (data.Date != DateTime.MinValue && sala == null) { return SubTipoRelatorio.Data; }
            return SubTipoRelatorio.Completo;
        }

        private enum SubTipoRelatorio
        {
            Completo,
            DataSala,
            Data,
            Sala
        }
        public enum TipoRelatorio
        {
            Arquivo,
            Console
        }
    }
}
