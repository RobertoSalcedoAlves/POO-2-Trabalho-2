using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Funcao : ClasseBase<Funcao, int>
    {
        public string Nome { get; set; }
        protected override int ProximoId { get { return Lista.Count + 1; } }
        public override string Descricao {
            get { return string.Format($"Funcão: {this.Nome}"); }
        }

        public Funcao(string nome)
        {
            Id = ProximoId;
            Nome = nome; Lista.Add(this);
            Lista.Add(this);
        }

        public override Funcao SelecionarPorId(int id) => Lista.Find(x => x.Id == id);

        public override bool Equals(object obj)
        {
            try
            {
                return ((Funcao)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
