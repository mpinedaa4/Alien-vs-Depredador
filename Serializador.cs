using System;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alien_vs_Depredador
{
    public class Serializador
    {
        public void serializar(object p1, object p2, object p3)
        {
            if (p1 is Character player && p2 is Character enemy && p3 is Map map)
            {
                string jugador = JsonConvert.SerializeObject(player);
                File.WriteAllText("Player.json", jugador);
                string enemigo = JsonConvert.SerializeObject(enemy);
                File.WriteAllText("Enemy.json", enemigo);
                string mapa = JsonConvert.SerializeObject(map);
                File.WriteAllText("Map.json", mapa);
            }
        }

        public List<object> deserializar()
        {
            List<object> game = new List<object>();
            string clase1 = File.ReadAllText("Player.json");
            int index = clase1.IndexOf("Alien");
            if (index != -1)
            {
                Alien jugador = JsonConvert.DeserializeObject<Alien>(clase1);
                game.Add(jugador);
            }
            else
            {
                Predator jugador = JsonConvert.DeserializeObject<Predator>(clase1);
                game.Add(jugador);
            }
            string clase2 = File.ReadAllText("Enemy.json");
            index = clase2.IndexOf("Alien");
            if (index != -1)
            {
                Alien enemigo = JsonConvert.DeserializeObject<Alien>(clase2);
                game.Add(enemigo);
            }
            else
            {
                Predator enemigo = JsonConvert.DeserializeObject<Predator>(clase2);
                game.Add(enemigo);
            }
            string clase3 = File.ReadAllText("Map.json");
            Map mapa = JsonConvert.DeserializeObject<Map>(clase3);



            for (int row = 0; row < mapa.map.GetLength(0); row++)
            {
                for (int col = 0; col < mapa.map.GetLength(1); col++)
                {
                    List<object> element = mapa.map[row, col];
                    if (element.Count() == 1 && element[0] is JObject elemento)
                    {
                        string texto = elemento.ToString();
                        if (texto.Contains("Alien"))
                        {
                            mapa.removeElement(row, col, element[0]);
                            if (game[0] is Alien)
                            {
                                mapa.addElement(row, col, game[0]);
                            }
                            else
                            {
                                mapa.addElement(row, col, game[1]);
                            }

                        }
                        else if (texto.Contains("Depredador"))
                        {
                            mapa.removeElement(row, col, element[0]);
                            if (game[0] is Predator)
                            {
                                mapa.addElement(row, col, game[0]);
                            }
                            else
                            {
                                mapa.addElement(row, col, game[1]);
                            }
                        }
                        else if (texto.Contains("Bear Trap"))
                        {
                            mapa.removeElement(row, col, element[0]);
                            mapa.addElement(row, col, new BearTrap());
                        }
                        else if (texto.Contains("Poison Plant"))
                        {
                            mapa.removeElement(row, col, element[0]);
                            mapa.addElement(row, col, new PoisonPlant());
                        }
                        else if (texto.Contains("Health"))
                        {
                            mapa.removeElement(row, col, element[0]);
                            mapa.addElement(row, col, new Health());
                        }
                        else if (texto.Contains("Power"))
                        {
                            mapa.removeElement(row, col, element[0]);
                            mapa.addElement(row, col, new Power());
                        }
                    }
                    else if (element.Count() == 2 && element[0] is JObject elemento2 && element[1] is JObject elemento3)
                    {
                        string texto = elemento2.ToString();
                        string texto2 = elemento3.ToString();
                        if (texto.Contains("Alien") || texto2.Contains("Alien"))
                        {
                            mapa.removeElement(row, col, element[0]);
                            if (game[0] is Alien)
                            {
                                mapa.addElement(row, col, game[0]);
                            }
                            else
                            {
                                mapa.addElement(row, col, game[1]);
                            }

                        }
                        if (texto.Contains("Depredador") || texto2.Contains("Depredador"))
                        {
                            mapa.removeElement(row, col, element[0]);
                            if (game[0] is Predator)
                            {
                                mapa.addElement(row, col, game[0]);
                            }
                            else
                            {
                                mapa.addElement(row, col, game[1]);
                            }
                        }
                    }
                }
            }
            game.Add(mapa);
            return game;
        }
    }
}

