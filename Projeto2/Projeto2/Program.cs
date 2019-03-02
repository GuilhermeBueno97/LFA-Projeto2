using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projeto2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite as variáveis <separados por espaço>:\t");
            string v = Console.ReadLine();
            string[] variaveis = v.Split(' ');

            Console.Write("Digite o alfabeto <separados por espaço>:\t");
            string a = Console.ReadLine();
            string[] alfabeto = a.Split(' ');

            Console.WriteLine("Digite as regras de produção separados por espaço <Digite FIM para finalizar>:\t");
            List<string[]> regras = new List<string[]>();
            string op = "";
            do
            {
                op = Console.ReadLine();
                string[] arr = op.Split(' ');
                regras.Add(arr);
            } while(!op.Equals("FIM"));

            Console.Write("Digite a variável inicial:\t");
            string varInicial = Console.ReadLine();

            Console.Write("Digite a ordem das regras <separados por espaço>:\t");
            string o = Console.ReadLine();
            string[] ordem = o.Split(' ');

            int passo = 0;

            recursao(regras, varInicial, ordem, passo);
            Console.ReadKey();
        }

        static void recursao(List<string[]> regras, string resposta, string[] ordem, int passo)
        {
            if (passo < ordem.Length)
            {
                string str = regras[Convert.ToInt32(ordem[passo])][0];
                if (resposta.Contains(str))
                {
                    string strTrocar = regras[Convert.ToInt32(ordem[passo])][1];
                    resposta = aplicaRegra(resposta, str, strTrocar);
                    recursao(regras, resposta, ordem, passo + 1);
                }
            }
            else
            {
                Console.WriteLine(resposta);
            }
        }

        static string aplicaRegra(string resposta, string find, string swap)
        {
            Regex s = new Regex(find);
            return s.Replace(resposta, swap, 1);
        }
    }
}
