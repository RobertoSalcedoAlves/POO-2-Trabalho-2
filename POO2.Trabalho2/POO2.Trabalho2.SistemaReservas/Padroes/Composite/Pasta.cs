using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;

namespace POO2.Trabalho2.SistemaReservas.Padroes.Composite
{
    public class Pasta : PastaBase<IObjeto<IMenu<Pasta>>>
    {
        public Pasta(string nome) : base(nome) { }
        
    }
}
