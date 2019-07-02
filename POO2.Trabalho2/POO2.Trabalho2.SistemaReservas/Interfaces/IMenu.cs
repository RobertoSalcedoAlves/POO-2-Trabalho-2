using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POO2.Trabalho2.Util.FormataConsole;

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
        bool Ler { get; set; }
        Cor Cor { get; set; }
        void SubMenu();
        void Escolher(bool ler = true);
        void Navegar(ConsoleKeyInfo acao, IIterator objetoTipo);               
        void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando);
        void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando);
        void Resultado(bool acao, string sucesso = "Operação realizada com sucesso!", string inSucesso = "Operação não realizada!");
        void TopoMenu(IIterator objetoTipo, string subTitulo, string instrucao, List<string> Opcoes, ref bool explorando);
    }
}
