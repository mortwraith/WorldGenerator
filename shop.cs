using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGens
{
    class shop
    {
        public string entranceLine { get; set; }
        public List<string> items { get; set; }
        public double baseAmt { get; set; }
        public List<int> prices { get; set; }
        public string shopName { get; set; }
        public string keeperName { get; set; }
        private static Random rand = new Random();
        public string keeperRace;

        public shop(int price, int size)
        {
            int amtItems = rand.Next(1, size * 2);
            items = new List<string>(amtItems);
            baseAmt = price;
            prices = new List<int>(amtItems);
            keeperRace = generators.generateIntelligentCreature();
            for (int i = 0; i < amtItems; i++)
            {
                items.Add(generators.generateTreasure());
                prices.Add((int)(items[i].Length * (baseAmt / 10)));
            }
            keeperName = generators.general("bossNames.txt") + " " + generators.general("npcSurnames.txt");
        }

        public override string ToString()
        {
            string output = "The shopkeeper's name is ";

            output += keeperName + ". \nThey are from a race of  " + keeperRace + ".\nThey say: \"";
            output += generators.general("shop.txt") + "\"\n\n";
            for (int i = 0; i < prices.Count; i++)
            {
                output += items[i] + ": " + prices[i] + "\n";
            }

            return output;
        }
    }
}
