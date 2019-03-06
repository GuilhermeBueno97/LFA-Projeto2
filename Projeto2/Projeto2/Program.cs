using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Projeto2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite as variáveis <separadas por espaço>:\t");
            string[] variaveis = Console.ReadLine().Split(' ');

            Console.Write("Digite o alfabeto <separados por espaço>:\t");
            string[] alfabeto = Console.ReadLine().Split(' ');

            Console.WriteLine("Digite as regras de produção separadas por espaço <Digite FIM para finalizar>:\t");
            List<string[]> regras = new List<string[]>();
            string op = "";
            do
            {
                op = Console.ReadLine();

                if (!op.Equals("FIM"))
                {
                    string[] arr = op.Split(' ');
                    regras.Add(arr);
                }
            } while (!op.Equals("FIM"));

            string varInicial = "";
            do
            {
                Console.Write("Digite uma variável inicial válida:\t");
                varInicial = Console.ReadLine();
            } while (!variaveis.Contains(varInicial));

            //Console.Write("Digite a ordem das regras <separados por espaço>:\t");
            //string[] ordem = Console.ReadLine().Split(' ');

            string[] ordem;
            bool flag;
            do
            {
                flag = false;
                Console.Write("Digite a ordem das regras <separados por espaço>:\t");
                ordem = Console.ReadLine().Split(' ');

                foreach (string s in ordem)
                {
                    if (Convert.ToInt32(s) > regras.Count - 1 || Convert.ToInt32(s) < 0)
                    {
                        flag = true;
                        break;
                    }
                }
            } while (flag);

            int passo = 0;

            BuscaOrdens(regras, varInicial, ordem, passo, alfabeto);

            Console.ReadKey();
        }

        static void BuscaOrdens(List<string[]> regras, string resposta, string[] ordem, int passo, string[] alfabeto)
        {
            if (passo < ordem.Length)
            {
                string str = regras[Convert.ToInt32(ordem[passo])][0];
                if (resposta.Contains(str))
                {
                    string strTrocar = regras[Convert.ToInt32(ordem[passo])][1];
                    resposta = AplicaRegra(resposta, str, strTrocar);
                }
                BuscaOrdens(regras, resposta, ordem, passo + 1, alfabeto);
            }
            else
            {
                if (VerificaPalavraValida(resposta, alfabeto))
                {
                    Console.WriteLine("Palavra: " + resposta);
                }
                else
                {
                    Console.WriteLine("A palavra não é valida: " + resposta);
                }
            }

        }

        static string AplicaRegra(string resposta, string find, string swap)
        {
            Regex s = new Regex(find);
            return s.Replace(resposta, swap, 1);
        }

        static bool VerificaPalavraValida(string palavra, string[] alfabeto)
        {
            foreach (char c in palavra)
            {
                if (!alfabeto.Contains(c.ToString()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
