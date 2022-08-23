using System;

namespace PJogo_Da_Velha
{
    internal class Program
    {
        static void AddPosicoes(char[,] Tabuleiro)
        {
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Tabuleiro[l, c] = 'L';
                }
            }
        }
        static void ImprimirTabuleiro(char[,] Tabuleiro)
        {
            for (int l = 0; l < 3; l++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Console.Write(Tabuleiro[l, c] + " | ");
                }
                Console.WriteLine();
            }

        }
        static char DefinirSimboloJog1()
        {
            char jogador1;
            Console.Write("\nInforme jogador 1 qual simbolo deseja utilizar ('X' ou 'O'): ");
            jogador1 = char.Parse(Console.ReadLine().ToUpper());
            return jogador1;
        }
        static char DefinirSimboloJog2(char jogador1)
        {
            char jogador2;
            if (jogador1 == 'X')
            {
                jogador2 = 'O';
            }
            else jogador2 = 'X';
            return jogador2;
        }
        static void ImprimirJogadores(char jogador1, char jogador2)
        {
            Console.WriteLine($"Jogador 1 = {jogador1}");
            Console.WriteLine($"Jogador 2 = {jogador2}");
        }
        static int SolicitarLinha(int jogador)
        {
            int linha = -1;
            do
            {
                Console.WriteLine($"\nJOGADOR {jogador}, informe a linha que deseja ocupar: ");
                try
                {
                    linha = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Informe um valor numérico de 0 a 2!");
                }
            } while (linha < 0 || linha > 2);
            return linha;
        }
        static int SolicitarColuna(int jogador)
        {
            int coluna = -1;
            do
            {
                Console.WriteLine($"JOGADOR {jogador}, informe a coluna que deseja ocupar: ");
                try
                {
                    coluna = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Informe um valor númerico de 0 a 2! ");
                }
            } while (coluna < 0 || coluna > 2);

            return coluna;
        }
        static bool VerificarGanhador(char[,] Tabuleiro, char jogador, int numJogador)
        {
            if (Tabuleiro[0, 0] == jogador && Tabuleiro[0, 1] == jogador && Tabuleiro[0, 2] == jogador)
            {
                Console.WriteLine($"\nJogador {numJogador} VENCEU!");
                return true;
            }
            else if (Tabuleiro[1, 0] == jogador && Tabuleiro[1, 1] == jogador && Tabuleiro[1, 2] == jogador)
            {
                Console.WriteLine($"\nJogador {numJogador} VENCEU!");
                return true;
            }
            else if (Tabuleiro[2, 0] == jogador && Tabuleiro[2, 1] == jogador && Tabuleiro[2, 2] == jogador)
            {
                Console.WriteLine($"\nJogador {numJogador} VENCEU!");
                return true;
            }
            else if (Tabuleiro[0, 0] == jogador && Tabuleiro[1, 0] == jogador && Tabuleiro[2, 0] == jogador)
            {
                Console.WriteLine($"\nJogador {numJogador} VENCEU!");
                return true;
            }
            else if (Tabuleiro[0, 1] == jogador && Tabuleiro[1, 1] == jogador && Tabuleiro[2, 1] == jogador)
            {
                Console.WriteLine($"\nJogador {numJogador} VENCEU!");
                return true;
            }
            else if (Tabuleiro[0, 2] == jogador && Tabuleiro[1, 2] == jogador && Tabuleiro[2, 2] == jogador)
            {
                Console.WriteLine($"\nJogador {numJogador} VENCEU!");
                return true;
            }
            else if (Tabuleiro[0, 0] == jogador && Tabuleiro[1, 1] == jogador && Tabuleiro[2, 2] == jogador)
            {
                Console.WriteLine($"\nJogador {numJogador} VENCEU!");
                return true;
            }
            else if (Tabuleiro[2, 0] == jogador && Tabuleiro[1, 1] == jogador && Tabuleiro[0, 2] == jogador)
            {
                Console.WriteLine($"\nJogador {numJogador} VENCEU!");
                return true;
            }
            return false;
        }
        static bool ContinueAJogar()
        {
            int continuar = 0;
            do
            {
                Console.WriteLine("\nDeseja continuar ? se SIM, digite 1, SENAO, digite 2: ");
                try
                {
                    continuar = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("O valor deve ser numérico !");
                }
                if (continuar != 1 && continuar != 2)
                {
                    Console.WriteLine("O valor deve ser 1 ou 2 !");
                }

            } while (continuar != 1 && continuar != 2);
            if (continuar == 1)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                char jogador1, jogador2;
                char[,] Tabuleiro = new char[3, 3];
                int linha, coluna;
                int jogada = 0;

                //add valores nas posições do tabuleiro
                AddPosicoes(Tabuleiro);

                //imprimindo o tabuleiro do jogo na tela pela 1° vez
                ImprimirTabuleiro(Tabuleiro);

                //pedindo ao jogador 1 para definir qual simbolo quer utilizar
                do
                {
                    jogador1 = DefinirSimboloJog1();
                    if (jogador1 != 'X' && jogador1 != 'O')
                    {
                        Console.WriteLine("Opção inválida! Informe ('X' ou 'O')");
                    }
                } while (jogador1 != 'X' && jogador1 != 'O');

                jogador2 = DefinirSimboloJog2(jogador1);

                //mostra na tela qual jogador irá utilizar 'X' e qual irá utilizar 'O'
                ImprimirJogadores(jogador1, jogador2);

                do
                {
                    // Vez do jogador 1 de ocupar linhas e colunas se ele não ocupar um espaço já preenchido
                    do
                    {
                        linha = SolicitarLinha(1);
                        coluna = SolicitarColuna(1);

                        if (Tabuleiro[linha, coluna] == 'X' || Tabuleiro[linha, coluna] == 'O')
                        {
                            Console.WriteLine("Posição já ocupada !");
                        }
                    } while (Tabuleiro[linha, coluna] == 'X' || Tabuleiro[linha, coluna] == 'O');
                    jogada++; //conto 1 jogada

                    //atribuo o simbolo que o jogador 1 for nas linhas e colunas ex: [0,0] = X
                    Tabuleiro[linha, coluna] = jogador1;

                    Console.Clear();

                    //mostro na tela o tabuleiro do jogo com as posições que o jogador 1 escolheu
                    ImprimirTabuleiro(Tabuleiro);

                    //Chamando a função que verifica se o jogador 1 ganhou...
                    if (VerificarGanhador(Tabuleiro, jogador1, 1) == true)
                    {
                        break;

                    }
                    else if (jogada > 7)
                    {
                        Console.WriteLine("\n DEU VELHA !!!!");
                        break;
                    }

                    // Vez do jogador 2 de ocupar linhas e colunas se ele não ocupar um espaço já preenchido
                    do
                    {
                        linha = SolicitarLinha(2);
                        coluna = SolicitarColuna(2);
                        if (Tabuleiro[linha, coluna] == 'X' || Tabuleiro[linha, coluna] == 'O')
                        {
                            Console.WriteLine("Posição já ocupada !");
                        }
                    } while (Tabuleiro[linha, coluna] == 'X' || Tabuleiro[linha, coluna] == 'O');
                    jogada++; //conto 1 jogada

                    //atribuo o simbolo que o jogador 2 for nas linhas e colunas ex: [0,0] = X
                    Tabuleiro[linha, coluna] = jogador2;

                    Console.Clear();

                    //mostro na tela  o tabuleiro do jogo com as posições que o jogador 2 escolheu
                    ImprimirTabuleiro(Tabuleiro);

                    //Chamando a função que verifica se o jogador 2 ganhou...
                    if (VerificarGanhador(Tabuleiro, jogador2, 2) == true)
                    {
                        break;
                    }
                    else if (jogada > 7)
                    {
                        Console.WriteLine("\n DEU VELHA !!!");
                        break;
                    }

                } while (true);

            } while (ContinueAJogar() == true);
        }
    }
}
