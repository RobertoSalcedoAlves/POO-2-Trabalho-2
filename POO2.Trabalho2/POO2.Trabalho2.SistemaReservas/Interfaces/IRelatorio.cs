using POO2.Trabalho2.SistemaReservas.Dominio;
using System;
using System.Collections.Generic;

namespace POO2.Trabalho2.SistemaReservas.Interfaces
{
    public interface IRelatorio
    {
        void MontarRelatorio(IEnumerable<Reserva> reservas);
        void GerarRelatorio();
        void GerarRelatorio(Sala sala);
        void GerarRelatorio(DateTime data);
        void GerarRelatorio(DateTime data, Sala sala);
    }
}
