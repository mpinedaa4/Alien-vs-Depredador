using System;
using System.Numerics;

namespace Alien_vs_Depredador
{
    class Predator : Character
    {

        public Predator()
        {
            name = "Depredador";
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
            else
            {
                return false;
            }
        }

        public override void useAbility(object parameter)
        {
            if (parameter is Character enemy)
            {
                
                if (this.getPos()[0] == enemy.getPos()[0])
                {
                    if (this.getStr() > enemy.getStr())
                    {
                        this.combat(enemy);
                    }
                    else
                    {
                        Console.WriteLine("La fuerza del Depredador no es suficiente para herir al Alien con su habilidad especial.");
                    }
                }
                else
                {
                    Console.WriteLine("El Depredador ha usado su habilidad especial, pero no había nadie en rango.");
                }
            }
        }

        public override string ToString()
        {
            return $"D";
        }
    }
}

