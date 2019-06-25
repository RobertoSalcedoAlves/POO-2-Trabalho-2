using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Interfaces
{
    public interface IMenu<TTipo> where TTipo : class
    {
        Menu<TTipo> Menu { get; set; }
    }
}
