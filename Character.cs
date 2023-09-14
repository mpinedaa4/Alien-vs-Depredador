using System;
using System.Numerics;
using System.Text.Json;

namespace Alien_vs_Depredador
{
    abstract class Character
    {
        public string name { get; set; }
        public List<int> position { get; set; } = new List<int>() {0,0};
        public int strength { get; set; }
        public int hp { get; set; }

        public string getName()
        {
            return name;
        }

        public List<int> getPos()
        {
            return position;
        }

        public int getStr()
        {
            return strength;
        }

        public int getHp()
        {
            return hp;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setPos(int new_row, int new_col)
        {
            this.position[0] = new_row;
            this.position[1] = new_col;
        }
        public void setStr(int new_strength)
        {
            strength = new_strength;
        }

        public void setHp(int new_hp)
        {
            hp = new_hp;
        }

        public abstract bool move(Character personaje, int row, int col, Map map, int choice);

        public void useItem(Item item)
        {
            switch (item.getName())
            {
                case "Power":
                case "Poison Plant":
                    strength += item.getModifier();
                    Console.WriteLine();
                    Console.WriteLine("El " + this.getName() + " ha encontrado un " + item.getName() + ". Su fuerza se ha modificado en " +
                        item.getModifier() + " puntos.");
                    Console.WriteLine();
                    break;
                case "Health":
                case "Bear Trap":
                    hp += item.getModifier();
                    Console.WriteLine();
                    Console.WriteLine("El " + this.getName() + " ha encontrado un " + item.getName() + ". Su vida se ha modificado en " +
    item.getModifier() + " puntos.");
                    Console.WriteLine();
                    break;
            }
        }

        public void status()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("| Estado actual del " + this.getName() +  ":\n| Posición: " + this.getPos()[0] +
            ", " + this.getPos()[1] + "\n| Vida: " + this.getHp() + "\n| Fuerza: " + this.getStr());
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine();
        }

        public void combat(Character enemy)
        {
            Console.WriteLine();
            Console.WriteLine("Ha comenzado un combate:");
            Console.WriteLine();
            if (this.getStr() == enemy.getStr())
            {
                Console.WriteLine("El nivel de fuerza de ambos personajes es el mismo. Ninguno ha perdido puntos de vida.");
            }
            else if (this.getStr() > enemy.getStr())
            {
                int lost_health = this.getStr() - enemy.getStr();
                enemy.setHp(enemy.getHp() - lost_health);
                Console.WriteLine("El " + enemy.getName() + " ha perdido " + lost_health + " puntos de vida.");
            }
            else
            {
                int lost_health = enemy.getStr() - this.getStr();
                this.setHp(this.getHp() - lost_health);
                Console.WriteLine("El " + this.getName() + " ha perdido " + lost_health + " puntos de vida.");
            }
        }

        public abstract void useAbility(object parameter);

    }
}

