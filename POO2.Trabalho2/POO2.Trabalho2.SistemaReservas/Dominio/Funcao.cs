using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class Funcao : ClasseBase<Funcao, int>
    {
        public string Descricao { get; set; }

        public Funcao(string descricao) { Descricao = descricao; }

        public override Funcao SelecionarPorId(int id) => Lista.Find(x => x.Id == id);
    }
}
