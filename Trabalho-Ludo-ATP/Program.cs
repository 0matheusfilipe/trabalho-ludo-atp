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
            string[] cores = {"1", "2" , "3", "4"};
            bool vencedor = false;

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

            if(numeroJogadores == 2)
                Tabuleiro.posicionarPeao2Jogador(tabuleiro);
            else
                Tabuleiro.posicionarPeao4Jogador(tabuleiro);

            Console.WriteLine("");

            while (!vencedor)
            {
                Movimentos.moverPeoesJogador1(tabuleiro);
                Movimentos.moverPeoesJogador2(tabuleiro);
                Movimentos.moverPeoesJogador3(tabuleiro);
                Movimentos.moverPeoesJogador4(tabuleiro);
            }

            Console.ReadKey();
        }
    }

    class Movimentos
    {
        public static string[,] moverPeoesJogador1(string[,] tabuleiro)
        {

            //Funciona como o tabuleiro do jogador
            int[] percursoJogador1lin = { 6, 6, 6, 6, 6, 5, 4, 3, 2, 1, 0, 0, 0, 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7, 8, 8, 8, 8, 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 13, 12, 11, 10, 8, 8, 8, 8, 8, 8, 8, 8, 7, 7, 7, 7, 7, 7 };
            int[] percursoJogador1col = { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7, 8, 8, 8, 8, 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8, 8, 8, 8, 8, 7, 6, 6, 6, 6, 6, 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6 };

            //Criar o dado
            Random r = new Random();
            int dado = 0;

            //A posição do jogador inicialmente é 0, então é inicializado no vetor 0
            int colunaAtual = 0, linhaatual = 0;

            //Para alterar o tabuleiro e não deixar o peão marcado nas casas que já passou
            int casaAnterior = 0;

            bool verificacaoTirarPeao = true;
            bool verificacaoMoverPeao = true;

                Console.WriteLine("\t\t\tVez do Jogador 1 \n");
                Console.WriteLine("Pressione enter para girar o dado \n");
                Console.ReadKey(true);
                dado = r.Next(1, 7);
                Console.WriteLine("Você tirou " + dado);

                //Se o dado for igual a 6 o jogador pode retirar um peão, se não passa sua vez
                if (dado == 6)
                {

                    //Retira o peão da "casinha" e coloca na primeira posição do tabuleiro
                    //Como o vetor de linhas e colunas está zerado, ele irá para a primeira posição delimitada
                    tabuleiro[percursoJogador1lin[linhaatual], percursoJogador1col[colunaAtual]] = "T";
                    for (int l = 0; l < tabuleiro.GetLength(0); l++)
                    {
                        for (int m = 0; m < tabuleiro.GetLength(1); m++)
                        {
                            Console.Write(tabuleiro[l, m] + " ");
                        }
                        Console.WriteLine();
                    }

                    verificacaoTirarPeao = false; //Tem que ser melhor pensado

                    while (verificacaoMoverPeao)
                    {
                        Console.WriteLine("\t\t\tVez do Jogador 2 \n");
                        Console.WriteLine("Pressione enter para girar o dado");
                        //O dado sorá irá rolar caso o jogador pressione alguma tecla
                        Console.ReadKey(true);
                        dado = r.Next(1, 7);
                        Console.WriteLine("Você tirou " + dado);
                        Console.WriteLine();

                        //Será aumentado no vetor de linhas e colunas o número que foi tirado no dado
                        colunaAtual += dado;
                        linhaatual += dado;
                        //O peão será deslocado para essa nova casa
                        tabuleiro[percursoJogador1lin[linhaatual], percursoJogador1col[colunaAtual]] = "P";
                        //A casa que ele estava antes de realizar o movimento voltará a ser um traço
                        tabuleiro[percursoJogador1lin[casaAnterior], percursoJogador1col[casaAnterior]] = "-";
                        //A casa atual do peão se torna a "casaAnterior" para que na próxima rodada se repita o processo
                        casaAnterior += dado;

                        //Imprimi a nova posição do peão
                        for (int l = 0; l < tabuleiro.GetLength(0); l++)
                        {
                            for (int m = 0; m < tabuleiro.GetLength(1); m++)
                            {
                                Console.Write(tabuleiro[l, m] + " ");
                            }
                            Console.WriteLine();
                        }
                        //Se o dado for 6 o jogador jogará de novo - precisa fazer a verificação se foram 3 dados com número 6
                        if (dado != 6)
                            verificacaoMoverPeao = false;
                        Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("Não foi possível retirar um peão");
                Console.WriteLine();
            
            Console.WriteLine();


            return tabuleiro;
        }


        public static string[,] moverPeoesJogador2(string[,] tabuleiro)
        {

            //Funciona como o tabuleiro do jogador
            int[] percursoJogador2lin = { 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7, 8, 8, 8, 8, 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8, 8, 8, 8, 8, 7, 6, 6, 6, 6, 6, 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6 };
            int[] percursoJogador2col = { 8, 8, 8, 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8, 8, 8, 8, 8, 7, 6, 6, 6, 6, 6, 6, 5, 4, 3, 2, 1, 0, 0, 0, 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7 };

            //Criar o dado
            Random r = new Random();
            int dado = 0;

            //A posição do jogador inicialmente é 0, então é inicializado no vetor 0
            int colunaAtual = 0, linhaatual = 0;

            //Para alterar o tabuleiro e não deixar o peão marcado nas casas que já passou
            int casaAnterior = 0;

            bool verificacaoTirarPeao = true;
            bool verificacaoMoverPeao = true;

                Console.WriteLine("\t\t\tVez do Jogador 2 \n");
                Console.WriteLine("Pressione enter para girar o dado \n");
                Console.ReadKey(true);
                dado = r.Next(1, 7);
                Console.WriteLine("Você tirou " + dado);

                //Se o dado for igual a 6 o jogador pode retirar um peão, se não passa sua vez
                if (dado == 6)
                {
                    //Retira o peão da "casinha" e coloca na primeira posição do tabuleiro
                    //Como o vetor de linhas e colunas está zerado, ele irá para a primeira posição delimitada
                    tabuleiro[percursoJogador2lin[linhaatual], percursoJogador2col[colunaAtual]] = "P";
                    for (int l = 0; l < tabuleiro.GetLength(0); l++)
                    {
                        for (int m = 0; m < tabuleiro.GetLength(1); m++)
                        {
                            Console.Write(tabuleiro[l, m] + " ");
                        }
                        Console.WriteLine();
                    }
                    verificacaoTirarPeao = false; //Tem que ser melhor pensado

                    //Agora que o peão está livre, o jogador irá movê-lo
                    while (verificacaoMoverPeao)
                    {
                        Console.WriteLine("\t\t\tVez do Jogador 2 \n");
                        Console.WriteLine("Pressione enter para girar o dado");
                        //O dado sorá irá rolar caso o jogador pressione alguma tecla
                        Console.ReadKey(true);
                        dado = r.Next(1, 7);
                        Console.WriteLine("Você tirou " + dado);
                        Console.WriteLine();

                        //Será aumentado no vetor de linhas e colunas o número que foi tirado no dado
                        colunaAtual += dado;
                        linhaatual += dado;
                        //O peão será deslocado para essa nova casa
                        tabuleiro[percursoJogador2lin[linhaatual], percursoJogador2col[colunaAtual]] = "P";
                        //A casa que ele estava antes de realizar o movimento voltará a ser um traço
                        tabuleiro[percursoJogador2lin[casaAnterior], percursoJogador2col[casaAnterior]] = "-";
                         //A casa atual do peão se torna a "casaAnterior" para que na próxima rodada se repita o processo
                        casaAnterior += dado;

                        //Imprimi a nova posição do peão
                        for (int l = 0; l < tabuleiro.GetLength(0); l++)
                        {
                            for (int m = 0; m < tabuleiro.GetLength(1); m++)
                            {
                                Console.Write(tabuleiro[l, m] + " ");
                            }
                            Console.WriteLine();
                        }
                        //Se o dado for 6 o jogador jogará de novo - precisa fazer a verificação se foram 3 dados com número 6
                        if (dado != 6)
                            verificacaoMoverPeao = false;
                        Console.WriteLine();
                    }
                }
                else
                    Console.WriteLine("Não foi possível retirar um peão");
                Console.WriteLine();
            
            Console.WriteLine();


            return tabuleiro;
        }
        public static string[,] moverPeoesJogador3(string[,] tabuleiro)
        {

            //Funciona como o tabuleiro do jogador
            int[] percursoJogador3lin = { 8, 8, 8, 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8, 8, 8, 8, 8, 7, 6, 6, 6, 6, 6, 6, 5, 4, 3, 2, 1, 0, 0, 0, 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7 };
            int[] percursoJogador3col = { 13, 12, 11, 10, 9, 8, 8, 8, 8, 8, 8, 7, 6, 6, 6, 6, 6, 6, 5, 4, 3, 2, 1, 0, 0, 0, 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7, 8, 8, 8, 8, 8, 8, 9, 10, 11, 12, 13, 14, 14, 13, 12, 11, 10, 9 };

            //Criar o dado
            Random r = new Random();
            int dado = 0;

            //A posição do jogador inicialmente é 0, então é inicializado no vetor 0
            int colunaAtual = 0, linhaatual = 0;

            //Para alterar o tabuleiro e não deixar o peão marcado nas casas que já passou
            int casaAnterior = 0;
            bool verificacaoTirarPeao = true;
            bool verificacaoMoverPeao = true;

                Console.WriteLine("\t\t\tVez do Jogador 3 \n");
                Console.WriteLine("Pressione enter para girar o dado \n");
                Console.ReadKey(true);
                dado = r.Next(1, 7);
                Console.WriteLine("Você tirou " + dado);

                //Se o dado for igual a 6 o jogador pode retirar um peão, se não passa sua vez
                if (dado == 6)
                {
                    //Retira o peão da "casinha" e coloca na primeira posição do tabuleiro
                    //Como o vetor de linhas e colunas está zerado, ele irá para a primeira posição delimitada
                    tabuleiro[percursoJogador3lin[linhaatual], percursoJogador3col[colunaAtual]] = "Y";
                    for (int l = 0; l < tabuleiro.GetLength(0); l++)
                    {
                        for (int m = 0; m < tabuleiro.GetLength(1); m++)
                        {
                            Console.Write(tabuleiro[l, m] + " ");
                        }
                        Console.WriteLine();
                    }
                    verificacaoTirarPeao = false; //Tem que ser melhor pensado

                    //Agora que o peão está livre, o jogador irá movê-lo
                    while (verificacaoMoverPeao)
                    {
                        Console.WriteLine("\t\t\tVez do Jogador 3 \n");
                        Console.WriteLine("Pressione enter para girar o dado");
                        //O dado sorá irá rolar caso o jogador pressione alguma tecla
                        Console.ReadKey(true);
                        dado = r.Next(1, 7);
                        Console.WriteLine("Você tirou " + dado);
                        Console.WriteLine();

                        //Será aumentado no vetor de linhas e colunas o número que foi tirado no dado
                        colunaAtual += dado;
                        linhaatual += dado;
                        //O peão será deslocado para essa nova casa
                        tabuleiro[percursoJogador3lin[linhaatual], percursoJogador3col[colunaAtual]] = "Y";
                        //A casa que ele estava antes de realizar o movimento voltará a ser um traço
                        tabuleiro[percursoJogador3lin[casaAnterior], percursoJogador3col[casaAnterior]] = "-";
                        //A casa atual do peão se torna a "casaAnterior" para que na próxima rodada se repita o processo
                        casaAnterior += dado;

                        //Imprimi a nova posição do peão
                        for (int l = 0; l < tabuleiro.GetLength(0); l++)
                        {
                            for (int m = 0; m < tabuleiro.GetLength(1); m++)
                            {
                                Console.Write(tabuleiro[l, m] + " ");
                            }
                            Console.WriteLine();
                        }

                    //Se o dado for 6 o jogador jogará de novo - precisa fazer a verificação se foram 3 dados com número 6
                    if (dado != 6)
                            verificacaoMoverPeao = false;
                        Console.WriteLine();

                    }

                }
                else
                    Console.WriteLine("Não foi possível retirar um peão");
                Console.WriteLine();
            
            Console.WriteLine();

            Console.WriteLine();


            return tabuleiro;
        }

        public static string[,] moverPeoesJogador4(string[,] tabuleiro)
        {

            //Funciona como o tabuleiro do jogador
            int[] percursoJogador4lin = { 13, 12, 11, 10, 9, 8, 8, 8, 8, 8, 8, 7, 6, 6, 6, 6, 6, 6, 5, 4, 3, 2, 1, 0, 0, 0, 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7, 8, 8, 8, 8, 8, 8, 9, 10, 11, 12, 13, 14, 14, 13, 12, 11, 10, 9 };
            int[] percursoJogador4col = { 6, 6, 6, 6, 6, 5, 4, 3, 2, 1, 0, 0, 0, 1, 2, 3, 4, 5, 6, 6, 6, 6, 6, 6, 7, 8, 8, 8, 8, 8, 8, 9, 10, 11, 12, 13, 14, 14, 14, 13, 12, 11, 10, 9, 8, 8, 8, 8, 8, 8, 7, 7, 7, 7, 7, 7, 7 };

            //Criar o dado
            Random r = new Random();
            int dado = 0;

            //A posição do jogador inicialmente é 0, então é inicializado no vetor 0
            int colunaAtual = 0, linhaatual = 0;

            //Para alterar o tabuleiro e não deixar o peão marcado nas casas que já passou
            int casaAnterior = 0;
            bool verificacaoTirarPeao = true;
            bool verificacaoMoverPeao = true;

                Console.WriteLine("\t\t\tVez do Jogador 4 \n");
                Console.WriteLine("Pressione enter para girar o dado \n");
                Console.ReadKey(true);
                dado = r.Next(1, 7);
                Console.WriteLine("Você tirou " + dado);

                //Se o dado for igual a 6 o jogador pode retirar um peão, se não passa sua vez
                if (dado == 6)
                {
                    //Retira o peão da "casinha" e coloca na primeira posição do tabuleiro
                    //Como o vetor de linhas e colunas está zerado, ele irá para a primeira posição delimitada
                    tabuleiro[percursoJogador4lin[linhaatual], percursoJogador4col[colunaAtual]] = "L";
                    for (int l = 0; l < tabuleiro.GetLength(0); l++)
                    {
                        for (int m = 0; m < tabuleiro.GetLength(1); m++)
                        {
                            Console.Write(tabuleiro[l, m] + " ");
                        }
                        Console.WriteLine();
                    }
                    verificacaoTirarPeao = false; //Tem que ser melhor pensado

                    //Agora que o peão está livre, o jogador irá movê-lo
                    while (verificacaoMoverPeao)
                    {
                        Console.WriteLine("\t\t\tVez do Jogador 4 \n");
                        Console.WriteLine("Pressione enter para girar o dado");
                        //O dado sorá irá rolar caso o jogador pressione alguma tecla
                        Console.ReadKey(true);
                        dado = r.Next(1, 7);
                        Console.WriteLine("Você tirou " + dado);
                        Console.WriteLine();
                        
                        //Será aumentado no vetor de linhas e colunas o número que foi tirado no dado
                        colunaAtual += dado;
                        linhaatual += dado;
                        //O peão será deslocado para essa nova casa
                        tabuleiro[percursoJogador4lin[linhaatual], percursoJogador4col[colunaAtual]] = "L";
                        //A casa que ele estava antes de realizar o movimento voltará a ser um traço
                        tabuleiro[percursoJogador4lin[casaAnterior], percursoJogador4col[casaAnterior]] = "-";
                        //A casa atual do peão se torna a "casaAnterior" para que na próxima rodada se repita o processo
                        casaAnterior += dado;

                        //Imprimi a nova posição do peão
                        for (int l = 0; l < tabuleiro.GetLength(0); l++)
                        {
                            for (int m = 0; m < tabuleiro.GetLength(1); m++)
                            {
                                Console.Write(tabuleiro[l, m] + " ");
                            }
                            Console.WriteLine();
                        }
                        //Se o dado for 6 o jogador jogará de novo - precisa fazer a verificação se foram 3 dados com número 6
                        if (dado != 6)
                            verificacaoMoverPeao = false;
                        Console.WriteLine();

                    }
                }
                else
                    Console.WriteLine("Não foi possível retirar um peão");
                Console.WriteLine();
  
            Console.WriteLine();
            Console.WriteLine();


            return tabuleiro;
        }
    }






    class Tabuleiro
    {

        public static string[,] preencherTabuleiro(string [,]tabuleiroPreenchido)
        {    
            // cria um tabuleiro quadrado
            for (int i = 0; i < tabuleiroPreenchido.GetLongLength(0); i++)
            {
                for (int j = 0; j < tabuleiroPreenchido.GetLongLength(1); j++)
                {
                    tabuleiroPreenchido[i, j] = "-";
                }
            }

            // retira o meio e deixa só o caminho a ser percorrido
            for (int a = 6; a < 9; a++)
            {
                for (int b = 6; b < 9; b++)
                {
                    tabuleiroPreenchido[a, b] = " ";
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
            string[] peaoJogador1 = {"T", "T", "T", "T" };
            string[] peaoJogador2 = { "L", "L", "L", "L" };

            //posiciona os peões do primeiro jogador
            for (int i = 2; i <= 4; i+= 2)
                for(int j = 2; j <= 4; j+= 2)
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
                for (int j = 2; j <= 4 ; j += 2)
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
