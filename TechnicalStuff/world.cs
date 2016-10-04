using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGens
{
    class world
    {
        public List<List<Land>> Rows;
        public string name;

        public world(int sizeIn)
        {
            int amtRows;
            int rowLands = 4;
            switch (sizeIn)
            {
                case 0: //xSmall
                    amtRows = 3;
                    break;
                case 1: //Small
                    amtRows = 5;
                    break;
                case 2: //Medium
                    amtRows = 7; 
                    break;
                case 3: //Large
                    amtRows = 9;
                    rowLands = 5;
                    break;
                case 4: //xLarge
                    amtRows = 13;
                    rowLands = 5;
                    break;
                default:
                    amtRows = 3;
                    break;
            }
            Rows = new List<List<Land>>(amtRows);
            for (int i = 0; i < amtRows; i++)
            {
                Rows.Add(new List<Land>(rowLands));
            }
            for (int i = 0; i < amtRows; i++)
            {
                bool nextMtns = false;
                for (int j = 0; j < rowLands; j++)
                {
                    List<string> adjCreats = new List<string>(40);
                    List<string> adjRule = new List<string>(4);

                    if (i == 0 && j == 0)
                    {
                        Rows[i].Add(new Land(0, false));
                    }
                    else if (i == 0 || i == amtRows - 1)
                    {
                        if (j != rowLands - 1 && j != 0)
                        {
                            adjCreats.AddRange(Rows[i][j - 1].creatures);
                            adjRule.Add(Rows[i][j - 1].rulingCreature);
                            if (Rows[i][j - 1].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(0, nextMtns, adjCreats, adjRule));
                        }
                        else if (j == 0)
                        {
                            adjCreats.AddRange(Rows[i - 1][j].creatures);
                            adjRule.Add(Rows[i - 1][j].rulingCreature);
                            if (Rows[i - 1][j].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(0, nextMtns, adjCreats, adjRule));
                        }
                        else
                        {
                            adjCreats.AddRange(Rows[i][j - 1].creatures);
                            adjCreats.AddRange(Rows[i][0].creatures);
                            adjRule.Add(Rows[i][j - 1].rulingCreature);
                            adjRule.Add(Rows[i][0].rulingCreature);
                            if (Rows[i][j - 1].type.Equals("Mountains") || Rows[i][0].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(0, nextMtns, adjCreats, adjRule));
                        }
                    }
                    else if (i == Math.Ceiling((double)amtRows / 2))
                    {
                        if (j != rowLands - 1 && j != 0)
                        {
                            adjCreats.AddRange(Rows[i][j - 1].creatures);
                            adjCreats.AddRange(Rows[i - 1][j].creatures);
                            adjRule.Add(Rows[i][j - 1].rulingCreature);
                            adjRule.Add(Rows[i - 1][j].rulingCreature);
                            if (Rows[i][j - 1].type.Equals("Mountains") || Rows[i - 1][j].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(1, nextMtns, adjCreats, adjRule));
                        }
                        else if (j == 0)
                        {
                            adjCreats.AddRange(Rows[i - 1][j].creatures);
                            adjRule.Add(Rows[i - 1][j].rulingCreature);
                            if (Rows[i - 1][j].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(1, nextMtns, adjCreats, adjRule));
                        }
                        else
                        {
                            adjCreats.AddRange(Rows[i][j - 1].creatures);
                            adjCreats.AddRange(Rows[i - 1][j].creatures);
                            adjCreats.AddRange(Rows[i][0].creatures);
                            adjRule.Add(Rows[i][j - 1].rulingCreature);
                            adjRule.Add(Rows[i - 1][j].rulingCreature);
                            adjRule.Add(Rows[i][0].rulingCreature);
                            if (Rows[i][j - 1].type.Equals("Mountains") || Rows[i - 1][j].type.Equals("Mountains") || Rows[i][0].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(1, nextMtns, adjCreats, adjRule));
                        }
                    }
                    else
                    {
                        if (j != rowLands - 1 && j != 0)
                        {
                            adjCreats.AddRange(Rows[i][j - 1].creatures);
                            adjCreats.AddRange(Rows[i - 1][j].creatures);
                            adjRule.Add(Rows[i][j - 1].rulingCreature);
                            adjRule.Add(Rows[i - 1][j].rulingCreature);
                            if (Rows[i][j - 1].type.Equals("Mountains") || Rows[i - 1][j].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(2, nextMtns, adjCreats, adjRule));
                        }
                        else if (j == 0)
                        {
                            adjCreats.AddRange(Rows[i - 1][j].creatures);
                            adjRule.Add(Rows[i - 1][j].rulingCreature);
                            if (Rows[i - 1][j].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(2, nextMtns, adjCreats, adjRule));
                        }
                        else
                        {
                            adjCreats.AddRange(Rows[i][j - 1].creatures);
                            adjCreats.AddRange(Rows[i - 1][j].creatures);
                            adjCreats.AddRange(Rows[i][0].creatures);
                            adjRule.Add(Rows[i][j - 1].rulingCreature);
                            adjRule.Add(Rows[i - 1][j].rulingCreature);
                            adjRule.Add(Rows[i][0].rulingCreature);
                            if (Rows[i][j - 1].type.Equals("Mountains") || Rows[i - 1][j].type.Equals("Mountains") || Rows[i][0].type.Equals("Mountains"))
                            {
                                nextMtns = true;
                            }
                            Rows[i].Add(new Land(2, nextMtns, adjCreats, adjRule));
                        }
                    }
                }
            }
        }
    }
}
