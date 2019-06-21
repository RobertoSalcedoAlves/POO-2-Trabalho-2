using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Sala : ClasseBase<Sala, int>
    {
        public string Nome { get; set; }
        public int NumeroLugares { get; set; }

        public Sala(string nome, int numeroLugares)
        {
            Nome = nome;
            NumeroLugares = numeroLugares;
            Lista.Add(this);
        }

        public override Sala SelecionarPorId(int id) => Lista.Find(x => x.Id == id);
    }
}
