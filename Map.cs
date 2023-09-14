using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using Newtonsoft.Json;

namespace Alien_vs_Depredador
{
    public class Map
	{
		public List<object>[,] map { get; set; }

        public Map(int row, int col)
		{
			map = new List<object>[row, col];

			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					map[i, j] = new List<object>();
				}
			}
		}

		public void show()
		{
			for (int row = 0; row < map.GetLength(0); row++)
			{
				for (int col = 0; col < map.GetLength(1); col++)
				{
                    string impresion = "[   ]";
                    char[] impresion_to_char = impresion.ToCharArray();
                    int count = 2;
					foreach(object element in map[row, col])
					{
						impresion_to_char[count] = Convert.ToChar(element.ToString());
						count++;
                    }
                    impresion = new string(impresion_to_char);
                    Console.Write(impresion);
				}
				Console.WriteLine();
			}
		}

		public void addElement(int row, int col, object element)
		{
			map[row, col].Add(element);
		}

		public void removeElement(int row, int col, object element)
		{
			map[row, col].Remove(element);
		}

		public List<object> getCell(int row, int col)
		{
			return map[row, col];
		}

		public List<object> createChar(string choice, int row, int col)
		{
            Alien p1 = new Alien();
            Predator p2 = new Predator();
            if (choice == "A")
			{
				p1.setPos(0, 0);
                p2.setPos(row - 1, col - 1);
                this.addElement(p1.getPos()[0], p1.getPos()[1], p1);
                this.addElement(p2.getPos()[0], p2.getPos()[1], p2);
                List<object> players = new List<object>() { p1, p2 };
                return players;
            }
			else
			{
                p2.setPos(0, 0);
                p1.setPos(row - 1, col - 1);
                this.addElement(p2.getPos()[0], p2.getPos()[1], p2);
                this.addElement(p1.getPos()[0], p1.getPos()[1], p1);
                List<object> players = new List<object>() { p2, p1 };
                return players;
            }
			
        }

		public void fillItems(int row, int col)
		{
            int num_items = (row * col) / 2;
            for (int i = 0; i < num_items; i++)
            {
                Random random = new Random();
                int new_item = random.Next(1, 5);
                int randomRow = random.Next(0, row);
                int randomCol = random.Next(0, col);
                while (this.getCell(randomRow, randomCol).Count != 0)
                {
                    randomRow = random.Next(0, row);
                    randomCol = random.Next(0, col);
                }
                switch (new_item)
                {
                    case 1:
                        Power power = new Power();
                        this.addElement(randomRow, randomCol, power);
                        break;
                    case 2:
                        Health health = new Health();
                        this.addElement(randomRow, randomCol, health);
                        break;
                    case 3:
                        BearTrap bearTrap = new BearTrap();
                        this.addElement(randomRow, randomCol, bearTrap);
                        break;
                    case 4:
                        PoisonPlant poison = new PoisonPlant();
                        this.addElement(randomRow, randomCol, poison);
                        break;
                }
            }
        }
	}
}