using System;
using MessagePack;

namespace Alien_vs_Depredador
{
    public class Item
	{
		public string name { get; set; }
		public int modifier { get; set; }

		public string getName()
		{
			return name;
		}

		public int getModifier()
		{
			return modifier;
		}

        public override string ToString()
        {
            return $"O";
        }
    }
}

