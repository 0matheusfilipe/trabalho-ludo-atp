using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ludo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] tabuleiro = new string[15, 15];
            int numeroJogadores, dado1 = 0, dado2 = 0;
            string jogador1 = "a", jogador2 = "b", jogador3 = "c", jogador4 = "d";
            string[] cores = { "1", "2", "3", "4" };

            Console.WriteLine("LUDO\n\n");
            Console.Write("Escolha o número de jogadores: ");
            numeroJogadores = int.Parse(Console.ReadLine());

            while (numeroJogadores != 2 && numeroJogadores != 4)
            {
                Console.WriteLine("Número de jogadores inválido, tente novamente!\n");
                Console.Write("Escolha o número de jogadores: ");
                numeroJogadores = int.Parse(Console.ReadLine());
            }


            if (numeroJogadores == 2)
            {
                Console.Write($" \n{cores[0]} - Verde \n{cores[1]} - Amarelo \n{cores[2]} - Azul \n{cores[3]} - Vermelho \n\nJogador 1, escolha sua de cor: ");
                jogador1 = Console.ReadLine();
                Console.Write($" \n{cores[0]} - Verde \n{cores[1]} - Amarelo \n{cores[2]} - Azul \n{cores[3]} - Vermelho \n\nJogador 2, escolha sua de cor: ");
                jogador2 = Console.ReadLine();
            }
            else if (numeroJogadores == 4)
            {
                Console.Write($" \n{cores[0]} - Verde \n{cores[1]} - Amarelo \n{cores[2]} - Azul \n{cores[3]} - Vermelho \n\nJogador 1, escolha sua de cor: ");
                jogador1 = Console.ReadLine();
                Console.Write($"Jogador 2, escolha sua de cor: \n{cores[0]} - Verde \n{cores[1]} - Amarelo \n{cores[2]} - Azul \n{cores[3]} - Vermelho \n\n");
                jogador2 = Console.ReadLine();
                Console.Write($"Jogador 1, escolha sua de cor: \n{cores[0]} - Verde \n{cores[1]} - Amarelo \n{cores[2]} - Azul \n{cores[3]} - Vermelho \n\n");
                jogador3 = Console.ReadLine();
                Console.Write($"Jogador 2, escolha sua de cor: \n{cores[0]} - Verde \n{cores[1]} - Amarelo \n{cores[2]} - Azul \n{cores[3]} - Vermelho \n\n");
                jogador4 = Console.ReadLine();
            }
            Console.Write("\n\n");
            Console.WriteLine("Carregando Tabuleiro... ");
            Console.WriteLine("Iniciando Jogo: \n\n");

            Tabuleiro.preencherTabuleiro(tabuleiro);

            if (numeroJogadores == 2)
                Tabuleiro.posicionarPeao2Jogador(tabuleiro);
            else
                Tabuleiro.posicionarPeao4Jogador(tabuleiro);

            Dados.rolarDados(dado1, dado2);

            Console.ReadKey();
        }
    }

    class Dados
    {
        public static int rolarDados(int out dado1, int out dado2)
        {
            Random num1 = new Random();
            Random num2 = new Random();

            dado1 =
        }



    }

    class Tabuleiro
    {

        public static string[,] preencherTabuleiro(string[,] tabuleiroPreenchido)
        {
            // cria um tabuleiro quadrado
            for (int i = 0; i < tabuleiroPreenchido.GetLongLength(0); i++)
            {
                for (int j = 0; j < tabuleiroPreenchido.GetLongLength(1); j++)
                {
                    tabuleiroPreenchido[i, j] = "-";
                }
            }

            // cria o "grande quadrado colorido" do primeiro jogador
            for (int k = 0; k < 6; k++)
            {
                for (int l = 0; l < 6; l++)
                {
                    tabuleiroPreenchido[k, l] = " ";
                }
            }

            // cria o "grande quadrado colorido" do segundo jogador
            for (int m = tabuleiroPreenchido.GetLength(0) - 6; m < tabuleiroPreenchido.GetLength(0); m++)
            {
                for (int n = tabuleiroPreenchido.GetLength(1) - 6; n < tabuleiroPreenchido.GetLength(1); n++)
                {
                    tabuleiroPreenchido[m, n] = " ";
                }
            }

            // cria o "grande quadrado colorido" do terceiro jogador
            for (int m = tabuleiroPreenchido.GetLength(0) - 6; m < tabuleiroPreenchido.GetLength(0); m++)
            {
                for (int n = 0; n < 6; n++)
                {
                    tabuleiroPreenchido[m, n] = " ";
                }
            }

            // cria o "grande quadrado colorido" do quarto jogador
            for (int m = 0; m < 6; m++)
            {
                for (int n = tabuleiroPreenchido.GetLength(1) - 6; n < tabuleiroPreenchido.GetLength(1); n++)
                {
                    tabuleiroPreenchido[m, n] = " ";
                }
            }

            // retorna o tabuleiro já editado
            return tabuleiroPreenchido;
        }

        public static string[,] posicionarPeao2Jogador(string[,] tabuleiroPosicionado)
        {
            string[] peaoJogador1 = { "T", "T", "T", "T" };
            string[] peaoJogador2 = { "L", "L", "L", "L" };

            //posiciona os peões do primeiro jogador
            for (int i = 2; i <= 4; i += 2)
                for (int j = 2; j <= 4; j += 2)
                {
                    tabuleiroPosicionado[i, j] = peaoJogador1[1];
                }

            //posiciona os peões do segundo jogador
            for (int i = tabuleiroPosicionado.GetLength(0) - 3; i > tabuleiroPosicionado.GetLength(0) - 6; i -= 2)
                for (int j = tabuleiroPosicionado.GetLength(1) - 3; j > tabuleiroPosicionado.GetLength(0) - 6; j -= 2)
                {
                    tabuleiroPosicionado[i, j] = peaoJogador2[2];
                }

            //imprime o tabuleiro preenchido
            for (int i = 0; i < tabuleiroPosicionado.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiroPosicionado.GetLength(1); j++)
                {
                    Console.Write(tabuleiroPosicionado[i, j] + " ");
                }
                Console.WriteLine();
            }

            //retorna o tabuleiro preenchido para dois jogadores
            return tabuleiroPosicionado;
        }

        public static string[,] posicionarPeao4Jogador(string[,] tabuleiroPosicionado)
        {
            string[] peaoJogador1 = { "T", "T", "T", "T" };
            string[] peaoJogador2 = { "L", "L", "L", "L" };
            string[] peaoJogador3 = { "P", "P", "P", "P" };
            string[] peaoJogador4 = { "Y", "Y", "Y", "Y" };

            //posiciona os peões do primeiro jogador
            for (int i = 2; i <= 4; i += 2)
                for (int j = 2; j <= 4; j += 2)
                {
                    tabuleiroPosicionado[i, j] = peaoJogador1[1];
                }

            //posiciona os peões do segundo jogador
            for (int i = tabuleiroPosicionado.GetLength(0) - 3; i > tabuleiroPosicionado.GetLength(0) - 6; i -= 2)
                for (int j = 2; j <= 4; j += 2)
                {
                    tabuleiroPosicionado[i, j] = peaoJogador2[2];
                }

            //posiciona os peões do terceiro jogador
            for (int i = 2; i <= 4; i += 2)
                for (int j = tabuleiroPosicionado.GetLength(1) - 3; j > tabuleiroPosicionado.GetLength(0) - 6; j -= 2)
                {
                    tabuleiroPosicionado[i, j] = peaoJogador3[2];
                }

            //posiciona os peões do quarto jogador
            for (int i = tabuleiroPosicionado.GetLength(0) - 3; i > tabuleiroPosicionado.GetLength(0) - 6; i -= 2)
                for (int j = tabuleiroPosicionado.GetLength(1) - 3; j > tabuleiroPosicionado.GetLength(0) - 6; j -= 2)
                {
                    tabuleiroPosicionado[i, j] = peaoJogador4[2];
                }

            //imprime o tabuleiro preenchido
            for (int i = 0; i < tabuleiroPosicionado.GetLength(0); i++)
            {
                for (int j = 0; j < tabuleiroPosicionado.GetLength(1); j++)
                {
                    Console.Write(tabuleiroPosicionado[i, j] + " ");
                }
                Console.WriteLine();
            }

            //retorna o tabuleiro preenchido para quatro jogadores
            return tabuleiroPosicionado;
        }
    }
}
