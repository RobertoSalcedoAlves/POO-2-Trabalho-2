using POO2.Trabalho2.SistemaReservas.ClassesBase;
using POO2.Trabalho2.SistemaReservas.Interfaces;
using POO2.Trabalho2.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static POO2.Trabalho2.Util.FormataConsole;

namespace POO2.Trabalho2.SistemaReservas.Dominio
{
    public class RelatorioReservasArquivo : RelatorioBase
    {
        const string NOME_ARQUIVO = @"\Relatório.txt";
        public RelatorioReservasArquivo(DateTime data, Sala sala, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            itens.AddLast(this);
        }
        public RelatorioReservasArquivo(DateTime data, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            itens.AddLast(this);
        }
        public RelatorioReservasArquivo(Sala sala, LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            itens.AddLast(this);
        }
        public RelatorioReservasArquivo(LinkedList<object> itens) : base(itens)
        {
            Id = ProximoId;
            itens.AddLast(this);
        }
        public string Path { get; set; }
        public override void MontarRelatorio(LinkedList<object> reservas)
        {
            Console.Write("informe o diretório: ");
            Path = string.Format(@"{0}\{1}", Console.ReadLine().Replace('/', '\\'), NOME_ARQUIVO);
            Stream stream = File.Create(Path);
            try
            {
                using (StreamWriter escritor = new StreamWriter(stream))
                {
                    foreach (var reserva in reservas)
                        escritor.WriteLine(reserva.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Não foi possível gerar o relatório.\t\nErro: " + e.Message);
                return;
            }
            Console.WriteLine("Relatório gerado em: " + Path.ToString());
        }        
        public override bool Equals(object obj)
        {
            try
            {
                return ((RelatorioReservasArquivo)obj).Id == this.Id;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public override void LocalizarSubMenu(string subTitulo, string instrucao2, ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
        public override void ExcluirOpcoesSubMenu(ref string informado, ref bool explorando)
        {
            throw new NotImplementedException();
        }
    }
}
