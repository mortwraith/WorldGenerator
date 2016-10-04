using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGens
{
    class Land
    {
        public List<PointOfIntrest> pis = new List<PointOfIntrest>(5);
        public String type;
        public List<string> creatures { get; }
        private static Random rand = new Random();
        public string rulingCreature;
        public string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Land"/> class.
        /// </summary>
        /// <param name="temp">The temperature 0 = cold, 1= hot, 2 = temperate.</param>
        /// <param name="isNextMountains">If true it is next to a mountain</param>
        /// <param name="adjCreats">List of creatures in adjacent lands</param>
        public Land(int temp, bool isNextMountains,List<string> adjCreats,List<string> adjRulers)
        {
            creatures = new List<string>(10);
            int mountainRand = rand.Next(0, 30);
            int piAmt = rand.Next(1, 6);
            if ((isNextMountains && mountainRand < 5 )|| mountainRand < 2)
            {
                type = "Mountains";
            }
            if (type == null)
            {
                switch (temp)
                {
                    case 0:
                        type = generators.general("coldBiomes.txt");
                        break;
                    case 1:
                        type = generators.general("HotBiomes.txt");
                        break;
                    default:
                        type = generators.general("tempBiomes.txt");
                        break;
                } 
            }
            for (int i = 0; i < piAmt; i++)
            {
                if (rand.Next(2) == 1)
                {
                    pis.Add(new dungeon(rand.Next(1,7)));
                }
                else
                {
                    pis.Add(new town(rand.Next(1,5)));
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (rand.Next(5) == 4)
                {
                    creatures.Add(adjCreats[rand.Next(0,adjCreats.Count)]);
                }
                else
                {
                    creatures.Add(generators.generateCreature());
                }
            }
            if (adjRulers.Count != 0 && rand.Next(0,3) >= 1)    // 66.66% chance
            {
                rulingCreature = adjRulers[rand.Next(0, adjRulers.Count)];
            }
            else
            {
                if (rand.Next(0,5) < 3)
                {
                    rulingCreature = generators.generateIntelligentCreature();
                }
                else
                {
                    rulingCreature = "none";
                }
            }
            name = "The " + generators.general("itemAdj.txt") + type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Land"/> class.
        /// </summary>
        /// <param name="temp">The temperature 0 = cold, 1= hot, 2 = temperate.</param>
        /// <param name="isNextMountains">If true it is next to a mountain</param>
        /// <param name="adjCreats">List of creatures in adjacent lands</param>
        public Land(int temp, bool isNextMountains)
        {
            creatures = new List<string>(10);
            int mountainRand = rand.Next(0, 30);
            int piAmt = rand.Next(0, 6);
            if ((isNextMountains && mountainRand < 5) || mountainRand < 2)
            {
                type = "Mountains";
            }
            if (type == null)
            {
                switch (temp)
                {
                    case 0:
                        type = generators.general("coldBiomes.txt");
                        break;
                    case 1:
                        type = generators.general("HotBiomes.txt");
                        break;
                    default:
                        type = generators.general("tempBiome.txt");
                        break;
                }
            }
            for (int i = 0; i < piAmt; i++)
            {
                if (rand.Next(3) == 1)
                {
                    pis.Add(new dungeon(rand.Next(1,7)));
                }
                else
                {
                    pis.Add(new town(rand.Next(1,5)));
                }
            }
            for (int i = 0; i < 10; i++)
            {
               creatures.Add(generators.generateCreature());
            }
            
            if (rand.Next(0, 5) < 2)
            {
                rulingCreature = generators.generateIntelligentCreature();
            }
            else
            {
                rulingCreature = "none";
            }
            name = "The " + generators.general("itemAdj.txt") + type;
        }

        public override string ToString()
        {
            return name; 
        }

        public string getInfo()
        {
            string output = "";

            output += "This land is named " + name + ". ";
            output += "It's biome is " + type + ". ";
            if (!rulingCreature.Equals("none"))
            {
                output += "It is ruled by " + rulingCreature + ". "; 
            }
            output += "\nIt contains the following creatures:";
            for (int i = 0; i < creatures.Count; i++)
            {
                output += "\n\t" + (i+1) + ". " + creatures[i];
            }

            return output;
        }
    }
}
