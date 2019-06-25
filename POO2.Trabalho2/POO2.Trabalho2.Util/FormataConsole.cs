using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO2.Trabalho2.Util
{
    public static class FormataConsole
    {
        private const int ln = 80;

        public static void Imprimir(string conteudo, Cor texto = Cor.Bc, Cor fundo = Cor.Pt)
        {
            Console.BackgroundColor = Txt(fundo);
            Console.ForegroundColor = Txt(texto);
            Console.WriteLine(conteudo);
            Console.ResetColor();
        }

        public static void Linha(char caractere) => Imprimir(new String(caractere, ln));
        public static string Centralizado(string conteudo)
        {
            int margem = (int)((ln - conteudo.Length) / 2);
            return (new String(' ', margem) + string.Format($" {conteudo} ") + new String(' ', margem));
        }
        public static string Justificado(List<string> conteudo)
        {
            string saida = "";
            int divisoes = conteudo.Count - 1;
            int espaco = (int)((ln - conteudo.Sum(x => x.Length)) / divisoes);
            for (int i = 0; i <= divisoes; i++)
            {
                saida += conteudo[i] + new String(' ', EspacoInterno(conteudo));
            }
            return saida;
        }

        private static int EspacoInterno(List<string> conteudo)
        {
            int divisoes = conteudo.Count - 1;
            return (int)((ln - conteudo.Sum(x => x.Length)) / divisoes); ;
        }

        public static void Numeracao(List<string> itens, Dir direcao = Dir.V)
        {
            int i = 1, espacamento;
            List<string> lstHorizontal = new List<string>();

            if (direcao == Dir.H)
                foreach (var item in itens)
                    lstHorizontal.Add(string.Format($"{(i++).ToString()}.{item}"));
            espacamento = EspacoInterno(lstHorizontal);

            i = 1;
            foreach (var item in itens)
            {
                Console.ForegroundColor = Txt(Cor.Am);
                switch (direcao)
                {
                    case Dir.V:
                        Console.Write(string.Format($"{(i++).ToString()}."));
                        Imprimir(item.ToUpper());
                        break;
                    case Dir.H:
                        Console.Write(string.Format($"{(i++).ToString()}."));
                        Console.ResetColor();
                        if (i <= itens.Count)
                            Console.Write(string.Format($"{item.ToUpper()}{new String(' ', espacamento)}"));
                        else if (i <= itens.Count + 1)
                            Console.WriteLine(string.Format($"{item.ToUpper()}{new String(' ', espacamento)}"));
                        break;
                }
            }
        }

        public static void Selecionar(string conteudo) => Imprimir(conteudo, Cor.Az, Cor.Am);
        public static void Aviso(string conteudo) => Imprimir(conteudo, Cor.Vm);
        public static void Destaque(string conteudo, Cor cor) => Imprimir(conteudo, cor);

        public static void Titulo1(string conteudo) => Destaque(Centralizado(conteudo), Cor.Vd);
        public static void Titulo2(string conteudo) => Destaque(Centralizado(conteudo), Cor.Am);

        private static ConsoleColor Txt(Cor cor)
        {
            switch (cor)
            {
                case Cor.Am: return ConsoleColor.Yellow;
                case Cor.Az: return ConsoleColor.Blue;
                case Cor.Bc: return ConsoleColor.White;
                case Cor.Cz: return ConsoleColor.Gray;
                case Cor.Rs: return ConsoleColor.Magenta;
                case Cor.Pt: return ConsoleColor.Black;
                case Cor.Vm: return ConsoleColor.Red;
                case Cor.Vd: return ConsoleColor.Green;
                case Cor.PdFnd: return ConsoleColor.Black;
                case Cor.PdTxt: return ConsoleColor.White;
                default: return ConsoleColor.White;
            }
        }

        public enum Cor { Am, Az, Bc, Cz, Pt, Rs, Vd, Vm, PdFnd, PdTxt }
        public enum Dir { H, V }
    }
}
