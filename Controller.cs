using System;
using System.Numerics;
using System.Xml.Linq;
using System.Text.Json;

namespace Alien_vs_Depredador
{
    public class Controller
    {
        private int row = 3;
        private int col = 3;
        private Random random = new Random();
        private List<object> game = new List<object>();
        private Menu menu = new Menu();
        private Serializador serializador = new Serializador();

        public void start()
        {
            Map map = new Map(row, col);
            int ans = menu.iniciar();
            while (ans == -1)
            {
                ans = menu.iniciar();
            }
            if (ans == 1)
            {
                string pj_elegido = menu.newGame();
                while (pj_elegido == "-1")
                {
                    pj_elegido = menu.newGame();
                }
                List<object> pj_temp = new List<object>();
                pj_temp = map.createChar(pj_elegido, row, col);
                game.Add(pj_temp[0]);
                game.Add(pj_temp[1]);
                game.Add(map);
                map.fillItems(row, col);

            }
            else if (ans == 2)
            {
                game = serializador.deserializar();
            }    
        }

        public void items_and_combat(object object1, object object2)
        {
            if(object1 is Character player && object2 is Map map)
            {
                //busca items en la nueva posicion para usarlos y removerlo del mapa y tambien busca si hay un enemigo para
                //entrar en combate
                foreach (object element in map.getCell(player.getPos()[0], player.getPos()[1]).ToList())
                {
                    if (element is Item item)
                    {
                        player.useItem(item);
                        map.removeElement(player.getPos()[0], player.getPos()[1], item);
                        if (player.getHp() <= 0)
                        {
                            player.status();
                            this.endgame(game[0], game[1]);
                        }
                    }
                    else if (element is Character personaje && personaje != player)
                    {
                        player.combat(personaje);
                        player.status();
                        personaje.status();
                        if (personaje.getHp() <= 0 || player.getHp() <= 0)
                        {
                            player.status();
                            personaje.status();
                            this.endgame(player, personaje);
                        }
                    }
                }
            }  
        }

        public void estado_actualizado()
        {
            Character player = (Character)game[0];
            Character enemy = (Character)game[1];
            Map map = (Map)game[2];

            player.status();
            enemy.status();
            map.show();
        }

        public void endgame(object parameter1, object parameter2)
        {
            if (parameter1 is Character player && parameter2 is Character enemy)
            {
                if (player.getHp() > enemy.getHp())
                {
                    Console.WriteLine("Fin del juego. El ganador es: " + player.getName());
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("Fin del juego. El ganador es: " + enemy.getName());
                    Environment.Exit(1);
                }
            }
        }

        public void turn(int player_or_enemy)
        {
            Character player = (Character)game[0];
            Character enemy = (Character)game[1];
            Map map = (Map)game[2];
            int choice;
            if(player_or_enemy == 1)
            {
                menu.banner(1);
                this.estado_actualizado();
                choice = menu.playerTurn();
            }
            else
            {
                menu.banner(2);
                this.estado_actualizado();
                choice = random.Next(1, 3);
            }
            while (choice == -1)
            {
                choice = menu.playerTurn();
            }
            if (choice == 1)
            {
                bool moved = false;
                while (!moved)
                {
                    int ans = -1;
                    if (player_or_enemy == 1)
                    {
                        ans = menu.move(player);
                        while (ans == -1)
                        {
                            ans = menu.move(player);
                        }
                        moved = player.move(player, this.row, this.col, map, ans);
                    }
                    else
                    {
                        if (enemy is Alien )
                        {
                            ans = random.Next(1, 9);
                        }
                        else
                        {
                            ans = random.Next(1, 5);
                        }
                        moved = enemy.move(enemy, this.row, this.col, map, ans);
                    }
                    
                    if (!moved && player_or_enemy == 1)
                    {
                        Console.WriteLine("No es posible moverte en esa dirección.");
                    }
                }
                if(player_or_enemy == 1)
                {
                    this.items_and_combat(player, map);
                    Console.WriteLine("Te has movido este turno.");
                }
                else
                {
                    this.items_and_combat(enemy, map);
                    Console.WriteLine("El enemigo se ha movido este turno.");
                }
                this.estado_actualizado();
                game[0] = player;
                game[1] = enemy;
                game[2] = map;
            }
            else if (choice == 2)
            {
                if (player_or_enemy == 1 && player.getName() == "Alien")
                {
                    player.useAbility(map);
                    Console.WriteLine("Has usado tu habilidad especial este turno.");
                }
                else if (player_or_enemy == 1 && player.getName() == "Depredador")
                {
                    player.useAbility(enemy);
                    int filaEnMapa = player.getPos()[0];
                    for (int i = 0; i < col; i++)
                    {
                        foreach (object element in map.getCell(filaEnMapa, i))
                        {
                            if (element is "#")
                            {
                                player.setHp(player.getHp() - 10);
                                Console.WriteLine("El Depredador usó su habilidad especial en un bloqueo. Pierde 10 puntos de vida.");
                            }
                        }

                    }
                    Console.WriteLine("Has usado tu habilidad especial este turno.");
                }
                else if (player_or_enemy == 2 && enemy.getName() == "Alien")
                {
                    enemy.useAbility(map);
                    Console.WriteLine("El enemigo ha usado su habilidad especial este turno.");
                }
                else
                {
                    enemy.useAbility(player);
                    int filaEnMapa = enemy.getPos()[0];
                    for (int i = 0; i < col; i++)
                    {
                        foreach (object element in map.getCell(filaEnMapa, i))
                        {
                            if (element is "#")
                            {
                                enemy.setHp(enemy.getHp() - 10);
                                Console.WriteLine("El Depredador usó su habilidad especial en un bloqueo. Pierde 10 puntos de vida.");
                            }
                        }

                    }
                    Console.WriteLine("El enemigo ha usado su habilidad especial este turno.");
                }
                game[0] = player;
                game[1] = enemy;
                game[2] = map;
            }
            else
            {
                serializador.serializar(player, enemy, map);
                Console.WriteLine("Partida guardada.");
                Environment.Exit(1);
            }
        }
    }
}
