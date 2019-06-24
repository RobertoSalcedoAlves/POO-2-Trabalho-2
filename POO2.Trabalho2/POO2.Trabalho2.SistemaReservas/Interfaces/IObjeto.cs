using POO2.Trabalho2.SistemaReservas.Padroes.Composite;

namespace POO2.Trabalho2.SistemaReservas.Interfaces
{
    public interface IObjeto
    {
        string Nome { get; set; }
        int Nivel { get; set; }
        int Bytes { get; }
        string PathVirtual { get; set; }
        TipoObjeto Tipo { get; }
        void Adicionar(IObjeto o);
        void Estruturar();
    }
    public enum TipoObjeto { Arquivo, Pasta }
}
