using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;

namespace POO2.Trabalho2.SistemaReservas.Padroes.Composite
{
    public class Arquivo : ArquivoBase<IObjeto<IMenu<Arquivo>>>
    {
        public Arquivo(string nome, string conteudo = "") : base(nome, conteudo) { }
    }
}
