using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardSoccer
{
    public class Opcao2
    {
        public void OP2()
        {
            Console.Write("Insira o nome do jogador: ");
            string jogador = Console.ReadLine();
            int energia = 10;
            int energiaElonMusk = 10;
            int pontos = 0;
            int pontosElonMusk = 0;
            int Gols = 0;
            int GolsElonMusk = 0;

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

            string[] jogadores = { jogador, "Elon Musk" };
            int jogadorAtual = resultado.Next(2);
            Console.WriteLine("O jogador que vai começar é: " + jogadores[jogadorAtual]);

            do
            {
                Console.WriteLine($"Energia de {jogador}: {energia}");
                Console.WriteLine($"Energia de Elon Musk: {energiaElonMusk}");
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

                if (jogadores[jogadorAtual] == jogador)
                {

                    if (cartas[0] == cartasSorteadas[0] && cartas[0] == cartasSorteadas[1] && cartas[0] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} ganhou 1 ponto!");
                        pontos++;
                        Gols++;
                        Console.WriteLine("Pontos:" + pontos);
                        energia--;
                    }
                    else if (cartas[1] == cartasSorteadas[0] && cartas[1] == cartasSorteadas[1] && cartas[1] == cartasSorteadas[2])
                    {
                        Console.WriteLine("--------------- É PÊNALTI ---------------");
                        Console.WriteLine();
                        Console.WriteLine($"Jogador {jogadores[jogadorAtual]} você deverá escolher uma das seguintes opções:");
                        Console.WriteLine("1 - DIREITA, 2 - ESQUERDA ou 3 - CENTRO");
                        int opcaoPenalti;
                        int opcaoDefesa;

                        if (jogadores[jogadorAtual] == jogador)
                        {
                            opcaoPenalti = int.Parse(Console.ReadLine());
                            while (opcaoPenalti < 1 || opcaoPenalti > 3)
                            {
                                Console.WriteLine("digite uma opção válida!");
                                opcaoPenalti = int.Parse(Console.ReadLine());
                            }
                        }
                        else
                        {
                            Random rand = new Random();
                            opcaoPenalti = rand.Next(1, 4);
                            Console.WriteLine($"O jogador ElonMusk escolheu a opção {opcaoPenalti}");
                        }

                        if (jogadores[jogadorAtual] == jogador)
                        {
                            Console.Write($"Jogador {jogadores[jogadorAtual]}, escolha a opção de defesa:");
                            Console.WriteLine("1 - DIREITA, 2 - ESQUERDA ou 3 - CENTRO");
                            opcaoDefesa = int.Parse(Console.ReadLine());
                            Console.Clear();
                            while (opcaoDefesa < 1 || opcaoDefesa > 3)
                            {
                                Console.WriteLine("digite uma opção válida!");
                                opcaoPenalti = int.Parse(Console.ReadLine());
                            }
                        }
                        else
                        {
                            Random rand = new Random();
                            opcaoDefesa = rand.Next(1, 4);
                            Console.WriteLine($"O jogador ElonMusk escolheu a opção {opcaoDefesa} para a defesa.");
                        }

                        if (opcaoPenalti != opcaoDefesa)
                        {
                            Console.WriteLine("GOOOOOOOOOOL!!!");
                            Console.WriteLine($"O jogador {jogadores[jogadorAtual]} marcou um gol!");
                            Gols++;
                        }
                        else
                        {
                            Console.WriteLine("DEFENDEU!!!");
                            Console.WriteLine($"O jogador {jogadores[(jogadorAtual + 1) % 2]} defendeu o pênalti!");
                        }

                        energia--;
                
                    }
                    else if (cartas[2] == cartasSorteadas[0] && cartas[2] == cartasSorteadas[1] && cartas[2] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} cometeu uma falta e passou a vez!");
                        energia--;
                    }
                    else if (cartas[3] == cartasSorteadas[0] && cartas[3] == cartasSorteadas[1] && cartas[3] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} recebeu um cartão amarelo e perderá 1 energia! No próximo cartão amarelo ele perderá 2 energias.");
                        energia -= 2;
                    }
                    else if (cartas[4] == cartasSorteadas[0] && cartas[4] == cartasSorteadas[1] && cartas[4] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} perdeu DUAS energias e passou a vez!");
                        energia -= 3;
                    }
                    else if (cartas[5] == cartasSorteadas[0] && cartas[5] == cartasSorteadas[1] && cartas[5] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} ganhou 1 energia e passou a vez!");
                        energia++;
                    }
                    else
                    {
                        pontos = somaValoresSorteados + pontos;

                        Console.WriteLine("Valores das cartas:");
                        Console.WriteLine("Gol = 3 pontos");
                        Console.WriteLine("Pênalti = 2 pontos");
                        Console.WriteLine("Falta = 1 ponto");
                        Console.WriteLine("Cartão Amarelo = 1 ponto");
                        Console.WriteLine("Cartão Vermelho = 0 pontos");
                        Console.WriteLine("Energia = 2 pontos");
                        Console.WriteLine();
                        Console.WriteLine("Soma dos pontos: " + somaValoresSorteados);
                        Console.WriteLine("Quantidade total de pontos: " + pontos);
                        Console.WriteLine("Quantidade de Gols: " + Gols);

                        energia--;
                    }

                }
                else
                {
                    if (cartas[0] == cartasSorteadas[0] && cartas[0] == cartasSorteadas[1] && cartas[0] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} ganhou 1 ponto!");
                        pontos++;
                        GolsElonMusk++;
                        Console.WriteLine("Pontos:" + pontos);
                        energiaElonMusk--;
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
                            GolsElonMusk++;
                        }
                        else
                        {
                            Console.WriteLine("DEFENDEU!!!");
                            Console.WriteLine($"O jogador {jogadores[(jogadorAtual + 1) % 2]} defendeu o pênalti!");
                        }

                        energiaElonMusk--;
                    }
                    else if (cartas[2] == cartasSorteadas[0] && cartas[2] == cartasSorteadas[1] && cartas[2] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} cometeu uma falta e passou a vez!");
                        energiaElonMusk--;
                    }
                    else if (cartas[3] == cartasSorteadas[0] && cartas[3] == cartasSorteadas[1] && cartas[3] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} recebeu um cartão amarelo e perderá 1 energia! No próximo cartão amarelo ele perderá 2 energias.");
                        energiaElonMusk -= 2;
                    }
                    else if (cartas[4] == cartasSorteadas[0] && cartas[4] == cartasSorteadas[1] && cartas[4] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} perdeu DUAS energias e passou a vez!");
                        energiaElonMusk -= 3;
                    }
                    else if (cartas[5] == cartasSorteadas[0] && cartas[5] == cartasSorteadas[1] && cartas[5] == cartasSorteadas[2])
                    {
                        Console.WriteLine($"O jogador {jogadores[jogadorAtual]} ganhou 1 energia e passou a vez!");
                        energiaElonMusk++;
                    }
                    else
                    {
                        pontosElonMusk = somaValoresSorteados + pontosElonMusk;

                        Console.WriteLine("Valores das cartas:");
                        Console.WriteLine("Gol = 3 pontos");
                        Console.WriteLine("Pênalti = 2 pontos");
                        Console.WriteLine("Falta = 1 ponto");
                        Console.WriteLine("Cartão Amarelo = 1 ponto");
                        Console.WriteLine("Cartão Vermelho = 0 pontos");
                        Console.WriteLine("Energia = 2 pontos");
                        Console.WriteLine();
                        Console.WriteLine("Soma dos pontos: " + somaValoresSorteados);
                        Console.WriteLine("Quantidade total de pontos: " + pontosElonMusk);
                        Console.WriteLine("Quantidade de Gols: " + GolsElonMusk);

                        energiaElonMusk--;
                    }
                }

                jogadorAtual = (jogadorAtual + 1) % 2;

            } while (energia >= 0 && energiaElonMusk >= 0);


            if (Gols > GolsElonMusk)
            {
                Console.WriteLine();
                Console.WriteLine($"PARABÉNS JOGADOR(A) {jogador}");
                Console.WriteLine($"VOCÊ VENCEU COM {Gols} GOLS E {pontos} PONTOS");
                Console.WriteLine($"O SEU ADVERSÁRIO FEZ {GolsElonMusk} GOLS E {pontosElonMusk} PONTOS");
            }
            else if (Gols < GolsElonMusk)
            {
                Console.WriteLine();
                Console.WriteLine($"PARABÉNS JOGADOR ELON MUSK");
                Console.WriteLine($"VOCÊ VENCEU COM {GolsElonMusk} GOLS E {pontosElonMusk} PONTOS");
                Console.WriteLine($"O SEU ADVERSÁRIO FEZ {Gols} GOLS E {pontos} PONTOS");
            }
            else if (Gols == GolsElonMusk && pontos > pontosElonMusk)
            {
                Console.WriteLine();
                Console.WriteLine($"PARABÉNS JOGADOR(A) {jogador}");
                Console.WriteLine($"VOCÊ VENCEU COM {Gols} GOLS E {pontos} PONTOS");
                Console.WriteLine($"O SEU ADVERSÁRIO FEZ {GolsElonMusk} GOLS E {pontosElonMusk} PONTOS");
            }
            else if (Gols == GolsElonMusk && pontos < pontosElonMusk)
            {
                Console.WriteLine();
                Console.WriteLine($"PARABÉNS JOGADOR ELON MUSK");
                Console.WriteLine($"VOCÊ VENCEU COM {GolsElonMusk} GOLS E {pontosElonMusk} PONTOS");
                Console.WriteLine($"O SEU ADVERSÁRIO FEZ {Gols} GOLS E {pontos} PONTOS");
            }
            else if (Gols == GolsElonMusk && pontos == pontosElonMusk)
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