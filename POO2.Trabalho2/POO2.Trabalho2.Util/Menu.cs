using System;
using System.Collections.Generic;

namespace POO2.Trabalho2.Util
{
    public class Menu
    {
        public string Titulo { get; set; }
        public IEnumerable<string> Opcoes { get; set; }
        public Menu(string titulo, IEnumerable<string> opcoes = null)
        {
            Titulo = titulo;
            Opcoes = Opcoes ?? new List<string> { "Selecionar","Excluir"  };
        }
    }
}
