using POO2.Trabalho2.SistemaReservas.Padroes.Composite;
using System.Collections.Generic;

namespace POO2.Trabalho2.SistemaReservas.Interfaces
{
    public interface IObjeto
    {
        int Id { get; }
        string Nome { get; set; }
        int Nivel { get; set; }
        int Bytes { get; }
        string PathVirtual { get; set; }
        TipoObjeto Tipo { get; }
        object Pai { get; set; }
        void Adicionar(object filho);
        bool OrdenarItens(Pasta pasta);
        string DefinirPath(IObjeto objeto, string pathVirtual);
        LinkedList<object> listaReordenada { get; set; }
        void Arvore(ref bool explorando, object nohPai = null);
        void AbrirArquivo(object objeto);
        bool SelecionarArquivoPorPath(string path);
        bool SelecionarArquivoPorNome(string nomeArquivo);
        bool RemoverArquivoPorNome(string nomeArquivo);
        bool RemoverArquivoPorCaminho(string pathVirtual);
        bool LocalizarArquivoPorCaminho(string pathVirtual);
        void EstruturarItens(object nohPai);        
    }
    public enum TipoObjeto { Arquivo, Pasta }
}
