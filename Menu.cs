using System;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;

namespace Alien_vs_Depredador
{
	public class Menu
	{

        public int iniciar()
		{
            Console.WriteLine("Este es el juego Alien versus Depredador:");
            Console.WriteLine("Elige una opción:");
            Console.WriteLine("1. Partida Nueva \n2. Reanudar Partida");
            try
            {
                int ans = Convert.ToInt32(Console.ReadLine());
                if (ans == 1 || ans == 2)
                {
                    return ans;
                }
                else
                {
                    Console.WriteLine("No has ingresado una opción válida, inténtalo nuevamente.");
                    return -1;
                }
            }
            catch
            {
                Console.WriteLine("No has ingresado una opción válida, inténtalo nuevamente.");
                return -1;
            }
        }

        public string newGame()
        {
            Console.WriteLine("Escoge tu personaje:\n- Escribe 'A' para Alien \n- Escribe 'D' para Depredador");
            string personaje = Console.ReadLine();
            try
            {
                if (personaje == "A" || personaje == "D")
                {
                    return personaje;
                }
                else
                {
                    Console.WriteLine("No has ingresado una opción válida, inténtalo nuevamente.");
                    return "-1";
                }
            }
            catch
            {
                Console.WriteLine("No has ingresado una opción válida, inténtalo nuevamente.");
                return "-1";
            }
        }

        public int playerTurn()
        {
            Console.WriteLine("Es tu turno, qué deseas hacer?");
            Console.WriteLine("1. Mover personaje\n2. Usar habilidad especial\n0. Guardar Partida");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 0 || choice == 1 || choice == 2)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("No has ingresado una opción válida, inténtalo nuevamente.");
                    return -1;
                }
            }
            catch
            {
                Console.WriteLine("No has ingresado una opción válida, inténtalo nuevamente.");
                return -1;
            }
        }

        public void banner(int player_or_enemy)
        {
            if(player_or_enemy == 1)
            {
                Console.WriteLine();
                Console.WriteLine("======================TURNO DEL JUGADOR====================================");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("======================TURNO DEL ENEMIGO====================================");
                Console.WriteLine();
            }
        }

        public int move(object character)
        {
            if (character is Alien)
            {
                Console.WriteLine("Elige la dirección para moverte:\n1. Arriba\n2. Abajo\n3. Derecha\n4. Izquierda\n5. Arriba izquierda\n6. Arriba derecha" +
    "\n7. Abajo izquierda\n8. Abajo derecha");
                try
                {
                    int ans = Convert.ToInt32(Console.ReadLine());
                    if (ans == 1 || ans == 2 || ans == 3 || ans == 4 || ans == 5 || ans == 6 || ans == 7 || ans == 8)
                    {
                        return ans;
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch
                {
                    Console.WriteLine("No has ingresado una opción válida, inténtalo nuevamente.");
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("Elige la dirección para moverte:\n1. Arriba\n2. Abajo\n3. Derecha\n4. Izquierda");
                try
                {
                    int ans = Convert.ToInt32(Console.ReadLine());
                    if (ans == 1 || ans == 2 || ans == 3 || ans == 4)
                    {
                        return ans;
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch
                {
                    Console.WriteLine("No has ingresado una opción válida, inténtalo nuevamente.");
                    return -1;
                }
            }

        }
    }
}

