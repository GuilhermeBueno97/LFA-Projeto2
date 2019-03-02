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
            string[] variaveis = { "S", "X", "Y", "A", "B", "F" };
            string[] alfabeto = { "a", "b" };
            string[,] regras = {
                                { "S", "XY" },
                                { "X",  "XaA" },
                                { "X",  "XbB" },
                                { "X", "F" },
                                { "Aa", "aA" },
                                { "Ab", "bA" },
                                { "AY", "Ya" },
                                { "Ba", "aB" },
                                { "Bb", "bB" },
                                { "BY", "Yb" },
                                { "Fa", "aF" },
                                { "Fb", "bF" },
                                { "FY", "" },
            };
            string varInicial = "S";
            string[] ordem = { "0", "1", "6", "2", "7", "9", "3", "11", "10", "12" };
            int passo = 0;

            recursao(regras, varInicial, ordem, passo);
            Console.ReadKey();
        }

        static void recursao(string[,] regras, string resposta, string[] ordem, int passo)
        {
            if (passo < ordem.Length)
            {
                string str = regras[Convert.ToInt32(ordem[passo]), 0];
                if (resposta.Contains(str))
                {
                    string strTrocar = regras[Convert.ToInt32(ordem[passo]), 1];
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
            //return resposta.Replace(find,swap);
            return s.Replace(resposta, swap, 1);
        }
    }
}
