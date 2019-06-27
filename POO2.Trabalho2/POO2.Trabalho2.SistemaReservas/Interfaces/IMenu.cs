using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Interfaces
{
    public interface IMenu
    {
        ConsoleKeyInfo Acao { get; set; }
        bool Navegou { get; set; }
        bool Abriu { get; set; }
        bool Voltou { get; set; }
        bool Removeu { get; set; }
        bool Saiu { get; set; }
        bool Opcao1 { get; set; }
        bool Opcao2 { get; set; }
        bool Opcao3 { get; set; }
        bool Opcao4 { get; set; }
        void SubMenu();
        void Escolher();
        void Navegar(ConsoleKeyInfo acao, Iterator<IObjeto> item);
    }
}
