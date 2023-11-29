using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CardSoccer
{

    class Program
    {

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine(" BEM VINDO AO CARD SOCCER ");
                Console.WriteLine("--------------------------");
                Console.WriteLine();
                Console.WriteLine("ESCOLHA O MODO DO JOGO:");
                Console.WriteLine("1. Player VS Player");
                Console.WriteLine("2. Player VS PC");
                opcao = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (opcao)
                {
                    case 1:

                        Opcao1 op1 = new Opcao1();
                        op1.OP1();

                        break;

                    case 2:

                        Opcao2 op2 = new Opcao2();
                        op2.OP2();

                        break;

                    default:

                        Console.WriteLine("Escolha uma opção válida!");

                        break;
                }

                Console.WriteLine();
                Console.Write("Digite 0 para uma nova partida ou -1 para sair: ");
                opcao = int.Parse(Console.ReadLine());

            } while (opcao == 0);

            Console.WriteLine();
            Console.WriteLine("OBRIGADO POR JOGAR E ATÉ A PRÓXIMA");
            
        }
    }
}