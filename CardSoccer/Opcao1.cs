using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardSoccer
{
    public class Opcao1
    {
        public void OP1()
        {
            Console.Write("Insira o nome do primeiro jogador: ");
            string jogador1 = Console.ReadLine();

            Console.Write("Insira o nome do segundo jogador: ");
            string jogador2 = Console.ReadLine();

            int energiaj1 = 10;
            int energiaj2 = 10;
            int pontosj1 = 0;
            int pontosj2 = 0;
            int Golsj1 = 0;
            int Golsj2 = 0;

            Console.WriteLine();

            string[] cartas = { "GOL", "PÊNALTI", "FALTA", "CARTÃO AMARELO", "CARTÃO VERMELHO", "ENERGIA" };
            Random resultado = new Random();

            Dictionary<string, int> valoresCartas = new Dictionary<string, int>
            {
                { "GOL", 3 },
                { "PÊNALTI", 2 },
                { "FALTA", 1 },
                { "CARTÃO AMARELO", 1 },
                { "CARTÃO VERMELHO", 0 },
                { "ENERGIA", 2 }
            };

            string[] jogadores = { jogador1, jogador2 };
            int jogadorAtual = resultado.Next(2);
            Console.WriteLine("O jogador que vai começar é: " + jogadores[jogadorAtual]);

            do
            {
                Console.WriteLine($"Energia de {jogador1}: {energiaj1}");
                Console.WriteLine($"Energia de {jogador2}: {energiaj2}");
                Console.WriteLine();
                Console.WriteLine(jogadores[jogadorAtual] + " pressione qualquer tecla para receber as cartas: ");
                Console.WriteLine();
                Console.ReadKey();
                Console.Clear();

                string[] cartasSorteadas = new string[3];
                int[] valoresSorteados = new int[3];

                for (int i = 0; i < 3; i++)
                {
                    int cartinhas = resultado.Next(cartas.Length);
                    cartasSorteadas[i] = cartas[cartinhas];
                    valoresSorteados[i] = valoresCartas[cartasSorteadas[i]];
                }

                Console.WriteLine($"1º carta: {cartasSorteadas[0]}");
                Console.ReadKey();
                Console.WriteLine($"2º carta: {cartasSorteadas[1]}");
                Console.ReadKey();
                Console.WriteLine($"3º carta: {cartasSorteadas[2]}");
                Console.ReadKey();
                Console.WriteLine();

                int somaValoresSorteados = valoresSorteados[0] + valoresSorteados[1] + valoresSorteados[2];

                if (jogadores[jogadorAtual] == jogador1)
                {

                    if (cartas[0] == cartasSorteadas[0] && cartas[0] == cartasSorteadas[1] && cartas[0] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você ganhou 1 ponto!");
                        pontosj1++;
                        Golsj1++;
                        Console.WriteLine("Pontos:" + pontosj1);
                        energiaj1--;
                    }
                    else if (cartas[1] == cartasSorteadas[0] && cartas[1] == cartasSorteadas[1] && cartas[1] == cartasSorteadas[2])
                    {

                        Console.WriteLine("--------------- É PÊNALTI ---------------");
                        Console.WriteLine();
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você deverá escolher uma das seguintes opções:");
                        Console.WriteLine("1 - DIREITA, 2 - ESQUERDA ou 3 - CENTRO");
                        int opcaoPenalti = int.Parse(Console.ReadLine());

                        while (opcaoPenalti < 1 || opcaoPenalti > 3)
                        {
                            Console.WriteLine("Digite uma opção válida!");
                            opcaoPenalti = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine();

                        Console.Write($"Jogador {jogadores[(jogadorAtual + 1) % 2]}, escolha a opção de defesa:");
                        Console.WriteLine("1 - DIREITA, 2 - ESQUERDA ou 3 - CENTRO");
                        int opcaoDefesa = int.Parse(Console.ReadLine());
                        Console.Clear();

                        while (opcaoDefesa < 1 || opcaoDefesa > 3)
                        {
                            Console.WriteLine("Digite uma opção válida!");
                            opcaoDefesa = int.Parse(Console.ReadLine());
                        }

                        if (opcaoPenalti != opcaoDefesa)
                        {
                            Console.WriteLine("GOOOOOOOOOOL!!!");
                            Console.WriteLine($"O jogador {jogadores[jogadorAtual]} marcou um gol!");
                            Golsj1++;
                        }
                        else
                        {
                            Console.WriteLine("DEFENDEU!!!");
                            Console.WriteLine($"O jogador {jogadores[(jogadorAtual + 1) % 2]} defendeu o pênalti!");
                        }

                        energiaj1--;
                        
                    }
                    else if (cartas[2] == cartasSorteadas[0] && cartas[2] == cartasSorteadas[1] && cartas[2] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você cometeu uma falta e passou a vez!");
                        energiaj1--;
                    }
                    else if (cartas[3] == cartasSorteadas[0] && cartas[3] == cartasSorteadas[1] && cartas[3] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você recebeu um cartão amarelo e perderá 1 energia! No próximo cartão amarelo você perderá 2 energias.");
                        energiaj1 -= 2;
                    }
                    else if (cartas[4] == cartasSorteadas[0] && cartas[4] == cartasSorteadas[1] && cartas[4] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você perdeu DUAS energias e passou a vez!");
                        energiaj1 -= 3;
                    }
                    else if (cartas[5] == cartasSorteadas[0] && cartas[5] == cartasSorteadas[1] && cartas[5] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você ganhou 1 energia e passou a vez!");
                        energiaj1++;
                    }
                    else
                    {
                        pontosj1 = somaValoresSorteados + pontosj1;

                        Console.WriteLine("Valores das cartas:");
                        Console.WriteLine("Gol = 3 pontos");
                        Console.WriteLine("Pênalti = 2 pontos");
                        Console.WriteLine("Falta = 1 ponto");
                        Console.WriteLine("Cartão Amarelo = 1 ponto");
                        Console.WriteLine("Cartão Vermelho = 0 pontos");
                        Console.WriteLine("Energia = 2 pontos");
                        Console.WriteLine();
                        Console.WriteLine("Soma dos pontos: " + somaValoresSorteados);
                        Console.WriteLine("Quantidade total de pontos: " + pontosj1);
                        Console.WriteLine("Quantidade de Gols: " + Golsj1);

                        energiaj1--;
                    }

                }
                else
                {
                    if (cartas[0] == cartasSorteadas[0] && cartas[0] == cartasSorteadas[1] && cartas[0] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você ganhou 1 ponto!");
                        pontosj2++;
                        Golsj2++;
                        Console.WriteLine("Pontos:" + pontosj2);
                        energiaj2--;
                    }
                    else if (cartas[1] == cartasSorteadas[0] && cartas[1] == cartasSorteadas[1] && cartas[1] == cartasSorteadas[2])
                    {
                        Console.WriteLine("--------------- É PÊNALTI ---------------");
                        Console.WriteLine();
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você deverá escolher uma das seguintes opções:");
                        Console.WriteLine("1 - DIREITA, 2 - ESQUERDA ou 3 - CENTRO");
                        int opcaoPenalti = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        Console.Write($"Jogador {jogadores[(jogadorAtual + 1) % 2]}, escolha a opção de defesa:");
                        Console.WriteLine("1 - DIREITA, 2 - ESQUERDA ou 3 - CENTRO");
                        int opcaoDefesa = int.Parse(Console.ReadLine());

                        if (opcaoPenalti != opcaoDefesa)
                        {
                            Console.WriteLine("GOOOOOOOOOOL!!!");
                            Console.WriteLine($"O jogador {jogadores[jogadorAtual]} marcou um gol!");
                            Golsj2++;
                        }
                        else
                        {
                            Console.WriteLine("DEFENDEU!!!");
                            Console.WriteLine($"O jogador {jogadores[(jogadorAtual + 1) % 2]} defendeu o pênalti!");
                        }

                        energiaj2--;
                    }
                    else if (cartas[2] == cartasSorteadas[0] && cartas[2] == cartasSorteadas[1] && cartas[2] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você cometeu uma falta e passou a vez!");
                        energiaj2--;
                    }
                    else if (cartas[3] == cartasSorteadas[0] && cartas[3] == cartasSorteadas[1] && cartas[3] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você recebeu um cartão amarelo e perderá 1 energia! No próximo cartão amarelo você perderá 2 energias.");
                        energiaj2 -= 2;
                    }
                    else if (cartas[4] == cartasSorteadas[0] && cartas[4] == cartasSorteadas[1] && cartas[4] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você perdeu DUAS energias e passou a vez!");
                        energiaj2 -= 3;
                    }
                    else if (cartas[5] == cartasSorteadas[0] && cartas[5] == cartasSorteadas[1] && cartas[5] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você ganhou 1 energia e passou a vez!");
                        energiaj2++;
                    }
                    else
                    {
                        pontosj2 = somaValoresSorteados + pontosj2;

                        Console.WriteLine("Valores das cartas:");
                        Console.WriteLine("Gol = 3 pontos");
                        Console.WriteLine("Pênalti = 2 pontos");
                        Console.WriteLine("Falta = 1 ponto");
                        Console.WriteLine("Cartão Amarelo = 1 ponto");
                        Console.WriteLine("Cartão Vermelho = 0 pontos");
                        Console.WriteLine("Energia = 2 pontos");
                        Console.WriteLine();
                        Console.WriteLine("Soma dos pontos: " + somaValoresSorteados);
                        Console.WriteLine("Quantidade total de pontos: " + pontosj2);
                        Console.WriteLine("Quantidade de Gols: " + Golsj2);

                        energiaj2--;
                    }
                }

                jogadorAtual = (jogadorAtual + 1) % 2;

            } while (energiaj1 >= 0 && energiaj2 >= 0);


            if (Golsj1 > Golsj2)
            {
                Console.WriteLine();
                Console.WriteLine($"PARABÉNS JOGADOR {jogador1}");
                Console.WriteLine($"VOCÊ VENCEU COM {Golsj1} GOLS E {pontosj1} PONTOS");
                Console.WriteLine($"O SEU ADVERSÁRIO FEZ {Golsj2} GOLS E {pontosj2} PONTOS");
            }
            else if (Golsj1 < Golsj2)
            {
                Console.WriteLine();
                Console.WriteLine($"PARABÉNS JOGADOR {jogador2}");
                Console.WriteLine($"VOCÊ VENCEU COM {Golsj2} GOLS E {pontosj2} PONTOS");
                Console.WriteLine($"O SEU ADVERSÁRIO FEZ {Golsj1} GOLS E {pontosj1} PONTOS");
            }
            else if (Golsj1 == Golsj2 && pontosj1 > pontosj2)
            {
                Console.WriteLine();
                Console.WriteLine($"PARABÉNS JOGADOR {jogador1}");
                Console.WriteLine($"VOCÊ VENCEU COM {Golsj1} GOLS E {pontosj1} PONTOS");
                Console.WriteLine($"O SEU ADVERSÁRIO FEZ {Golsj2} GOLS E {pontosj2} PONTOS");
            }
            else if (Golsj1 == Golsj2 && pontosj1 < pontosj2)
            {
                Console.WriteLine();
                Console.WriteLine($"PARABÉNS JOGADOR {jogador2}");
                Console.WriteLine($"VOCÊ VENCEU COM {Golsj2} GOLS E {pontosj2} PONTOS");
                Console.WriteLine($"O SEU ADVERSÁRIO FEZ {Golsj1} GOLS E {pontosj1} PONTOS");
            }
            else if (Golsj1 == Golsj2 && pontosj1 == pontosj2)
            {
                Console.WriteLine();
                Console.WriteLine("Deu empate!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("ERRO");
            }

        }
    }
}
