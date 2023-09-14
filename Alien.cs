using System;
using System.Numerics;
using System.Text.Json;


namespace Alien_vs_Depredador
{
    class Alien : Character
    {

        public Alien()
        {
            name = "Alien";
            strength = 10;
            hp = 10;
        }

        public override bool move(Character personaje, int row, int col, Map map, int choice)
        {
            //1 es arriba, 2 es abajo, 3 es derecha, 4 es izquierda
            if (choice == 1 && personaje.getPos()[0] != 0)
            {
                foreach (object element in map.getCell(personaje.getPos()[0] - 1, personaje.getPos()[1]))
                {
                    if (element == "#")
                    {
                        return false;
                    }
                }
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0] - 1, personaje.getPos()[1]);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 2 && personaje.getPos()[0] != row - 1)
            {
                foreach (object element in map.getCell(personaje.getPos()[0] + 1, personaje.getPos()[1]))
                {
                    if (element == "#")
                    {
                        return false;
                    }
                }
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0] + 1, personaje.getPos()[1]);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 3 && personaje.getPos()[1] != col - 1)
            {
                foreach (object element in map.getCell(personaje.getPos()[0], personaje.getPos()[1] + 1))
                {
                    if (element == "#")
                    {
                        return false;
                    }
                }
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0], personaje.getPos()[1] + 1);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 4 && personaje.getPos()[1] != 0)
            {
                foreach (object element in map.getCell(personaje.getPos()[0], personaje.getPos()[1] - 1))
                {
                    if (element == "#")
                    {
                        return false;
                    }
                }
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0], personaje.getPos()[1] - 1);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 5 && personaje.getPos()[0] != 0 && personaje.getPos()[1] != 0)
            {
                foreach (object element in map.getCell(personaje.getPos()[0] - 1, personaje.getPos()[1] - 1))
                {
                    if (element == "#")
                    {
                        return false;
                    }
                }
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0] - 1, personaje.getPos()[1] - 1);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 6 && personaje.getPos()[0] != 0 && personaje.getPos()[1] != col - 1)
            {
                foreach (object element in map.getCell(personaje.getPos()[0] - 1, personaje.getPos()[1] + 1))
                {
                    if (element == "#")
                    {
                        return false;
                    }
                }
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0] - 1, personaje.getPos()[1] + 1);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }

            else if (choice == 7 && personaje.getPos()[0] != row - 1 && personaje.getPos()[1] != 0)
            {
                foreach (object element in map.getCell(personaje.getPos()[0] + 1, personaje.getPos()[1] - 1))
                {
                    if (element == "#")
                    {
                        return false;
                    }
                }
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0] + 1, personaje.getPos()[1] - 1);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 8 && personaje.getPos()[0] != row - 1 && personaje.getPos()[1] != col - 1)
            {
                foreach (object element in map.getCell(personaje.getPos()[0] + 1, personaje.getPos()[1] + 1))
                {
                    if (element == "#")
                    {
                        return false;
                    }
                }
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0] + 1, personaje.getPos()[1] + 1);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }

            else
            {
                return false;
            }
        }

        /*
        public override bool move(Character personaje, int row, int col, Map map, int choice)
        {
            //1 es arriba, 2 es abajo, 3 es derecha, 4 es izquierda
            if (choice == 1 && personaje.getPos()[0] != 0)
            {
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0] - 1, personaje.getPos()[1]);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 2 && personaje.getPos()[0] != row - 1)
            {
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0] + 1, personaje.getPos()[1]);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 3 && personaje.getPos()[1] != col - 1)
            {
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0], personaje.getPos()[1] + 1);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else if (choice == 4 && personaje.getPos()[1] != 0)
            {
                map.removeElement(getPos()[0], getPos()[1], this);
                this.setPos(personaje.getPos()[0], personaje.getPos()[1] - 1);
                map.addElement(personaje.getPos()[0], personaje.getPos()[1], this);
                return true;
            }
            else
            {
                return false;
            }
        }*/

        public override void useAbility(object parameter)
        {
            if (parameter is Map map)
            {
                bool puede_usar_habilidad = true;
                foreach (object element in map.getCell(this.getPos()[0], this.getPos()[1]).ToList())
                {
                    if (element is "#")
                    {
                        Console.WriteLine("El Alien no pudo usar su habilidad especial en esa casilla porque ya había un bloqueo ahí.");
                        puede_usar_habilidad = false;
                    }
                }
                if (puede_usar_habilidad)
                {
                    map.addElement(this.getPos()[0], this.getPos()[1], "#");
                }
            }
            
        }

        public override string ToString()
        {
            return $"A";
        }
    }
}

