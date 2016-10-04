using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RandomGens
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();
        private int maxRooms = 1;
        private int worldSize = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void D20_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rand.Next(1,21).ToString();
        }

        private void D10_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rand.Next(1, 11).ToString();
        }

        private void D5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rand.Next(1, 6).ToString();
        }

        private void D100_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rand.Next(1, 101).ToString();
        }

        private void D6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rand.Next(1, 7).ToString();
        }

        private void D12_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rand.Next(1, 13).ToString();
        }

        private void D50_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rand.Next(1, 51).ToString();
        }

        private void D4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = rand.Next(1, 5).ToString();
        }

        private void Coin_Click(object sender, EventArgs e)
        {
            int coinVal = rand.Next(1, 3);
            if (coinVal == 1)
            {
                richTextBox1.Text = "Heads";
            }
            else
            {
                richTextBox1.Text = "Tails";
            }
        }

        private void Shows_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("shows.txt");
        }

        private void Cards_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.handOfCards();
        }

        private void Tarot_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("tarot.txt");
        }

        private void Ball_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("ball.txt");
        }
        
        private void Games_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("games.txt");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(richTextBox1.Text);
            sw.Close();
        }
        
        private void Movies_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("movies.txt");
        }

        private void Roll_Click(object sender, EventArgs e)
        {
            int sum = 0;
            try
            {
                string strOutput = "";
                int dX = int.Parse(Dx.Text);
                int dNum = int.Parse(DAmount.Text);
                int rVal;
                richTextBox1.Text = "";
                if (dNum != 1)
                {
                    for (int i = 0; i < dNum; i++)
                    {
                        rVal = rand.Next(1, dX + 1);
                        sum += rVal;
                        if (i < dNum - 1)
                        {
                            strOutput += rVal.ToString() + " + ";
                        }
                        else
                        {
                            strOutput += rVal.ToString() + " = ";
                        }
                    }
                    richTextBox1.Text += strOutput + sum.ToString();
                }
                else
                {
                    richTextBox1.Text = rand.Next(1, dX + 1).ToString();
                }
            }
            catch (Exception error)
            {
                richTextBox1.Text = error.Message;
            }
        }

        private void shop_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("shop.txt");
        }

        private void Annoy_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("annoy.txt");
        }

        private void Thanks_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("thanks.txt");
        }

        private void bye_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("goodbye.txt");
        }

        private void traveller_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.general("traveller.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strOutput = "";
                int dX = int.Parse(Dx.Text);
                int dNum = int.Parse(DAmount.Text);
                int rVal;
                List<int> vals = new List<int>(dX);
                richTextBox1.Text = "";
                if (dNum != 1)
                {
                    for (int i = 0; i < dNum; i++)
                    {
                        rVal = rand.Next(1, dX + 1);
                        vals.Add(rVal);
                    }
                    vals.Sort();
                    while (vals.Count > 0 && vals[0] == 1 && vals.Count > 1)
                    {
                        if (vals[vals.Count - 1] != 1)
                        {
                            vals.RemoveAt(vals.Count - 1); 
                        }
                        else
                        {
                            break;
                        }
                        vals.RemoveAt(0);
                    }
                    if (vals.Count > 1)
                    {
                        for (int i = 0; i < vals.Count && vals.Count != 1; i++)
                        {
                            if (i != vals.Count - 1)
                            {
                                strOutput += vals[i].ToString() + " + ";
                            }
                            else
                            {
                                richTextBox1.Text += strOutput + vals[i].ToString() + " = " + vals.Sum().ToString();
                                return;
                            }
                        }
                    }
                    else if (vals.Count == 1)
                    {
                        richTextBox1.Text = vals[0].ToString();
                    }
                    else
                    {
                        richTextBox1.Text = "1";
                    }
                }
                else
                {
                    richTextBox1.Text = rand.Next(1, dX + 1).ToString();
                }
            }
            catch (Exception error)
            {
                richTextBox1.Text = error.Message;
            }
        }

        private void RollSep_Click(object sender, EventArgs e)
        {
            try
            {
                string strOutput = "";
                int dX = int.Parse(Dx.Text);
                int dNum = int.Parse(DAmount.Text);
                int rVal;
                richTextBox1.Text = "";
                if (dNum != 1)
                {
                    for (int i = 0; i < dNum; i++)
                    {
                        rVal = rand.Next(1, dX + 1);
                        strOutput += rVal.ToString() + "\n";
                    }
                    richTextBox1.Text = strOutput;

                }
                else
                {
                    richTextBox1.Text = rand.Next(1, dX + 1).ToString();
                }
            }
            catch (Exception error)
            {
                richTextBox1.Text = error.Message;
            }
        }


        private void creatureGen_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.generateCreature();
        }

        private void itemGen_Click(object sender, EventArgs e)
        {
           richTextBox1.Text = generators.generateTreasure();
        }

        private void ships_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "The " + generators.general("adjs.txt") + generators.general("ships.txt");
        }

        private void dungeonGen_Click(object sender, EventArgs e)
        {
            int rooms = rand.Next(maxRooms / 2, maxRooms);
            int amtMon = 0;
            int.TryParse(monBaseTxt.Text, out amtMon);
            dungeon dun = new dungeon(rooms, amtMon);
            richTextBox1.Text = dun.getInfo();
        }

        private void sizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            maxRooms = (sizes.SelectedIndex + 1) * 3;
        }

        private void roomGen_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = new room(rand.Next(0, 5), 5, int.Parse(baseMon.Text)).ToString(); //the amtRooms doesn't matter
            }
            catch (Exception error)
            {
                richTextBox1.Text = error.Message;
            }
        }

        private void npcGen_Click(object sender, EventArgs e)
        {
            if (rand.Next(0,4) == 3)
            {
                richTextBox1.Text = generators.general("bossNames.txt") + " " + generators.general("bossDesc.txt"); 
            }
            else
            {
                richTextBox1.Text = generators.general("bossNames.txt") + " " + generators.general("npcSurnames.txt");
            }
        }

        private void genShop_Click(object sender, EventArgs e)
        {
            int amt;
            try
            {
                amt = int.Parse(baseMon.Text);
                richTextBox1.Text = new shop(amt, 5).ToString();
            }
            catch (Exception)
            {
                richTextBox1.Text = "You must select a size and amount for base money.";
            }
        }

        private void genBuilding_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = new building(maxRooms, int.Parse(baseMon.Text)).ToString();
            }
            catch (Exception)
            {
                richTextBox1.Text = new building().ToString();
            }
        }

        private void genTown_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = new town(maxRooms, int.Parse(baseMon.Text)).getInfo();
            }
            catch (Exception)
            {
                richTextBox1.Text = new town().getInfo();
            }
        }

        private void intGen_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.generateIntelligentCreature();
        }

        private void modIntGen_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generators.generateModifiedIntelligentCreature();
        }

        private void worldGen_Click(object sender, EventArgs e)
        {
            worldSize = worldSizes.SelectedIndex;
            intrestList.ClearSelected();
            intrestList.Items.Clear();
            landsList.ClearSelected();
            landsList.Items.Clear();
            world w = new world(worldSize);
            for (int i = 0; i < w.Rows.Count; i++)
            {
               for (int j = 0; j < w.Rows[i].Count; j++)
                {
                    landsList.Items.Add(w.Rows[i][j]);   
                }
            }
        }

        private void intrestList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = intrestList.SelectedIndex;
            if (select != -1)
            {
                PointOfIntrest lan = (PointOfIntrest)intrestList.Items[select];
                richTextBox1.Text = lan.getInfo(); 
            }
        }

        private void landsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            intrestList.ClearSelected();
            intrestList.Items.Clear();
            int select = landsList.SelectedIndex;
            if (select != -1)
            {
                string output = "";
                Land lan = (Land)landsList.Items[select];
                for (int i = 0; i < lan.pis.Count; i++)
                {
                    intrestList.Items.Add(lan.pis[i]);
                }
                for (int i = 0; i < landsList.Items.Count; i++)
                {
                    if (worldSize < 3 && (i%4) == 0 && i != 0)
                    {
                        output += "\n";
                    }
                    else if (worldSize > 2 && (i%5) == 0 && i != 0)
                    {
                        output += "\n";
                    }
                    if (i == select)
                    {
                        output += "[x] ";
                    }
                    else
                    {
                        output += "[  ] ";
                    }
                }
                output += "\n";
                mapTextbox.Text = output;
                output = lan.getInfo();
                richTextBox1.Text = output; 
            }
        }
        
    }
}
