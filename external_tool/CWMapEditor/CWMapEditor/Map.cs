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

namespace CWMapEditor
{
    //Determines what color buttons change when they are clicked
    enum ClickState
    {
        NoState,
        TreeState,
        WaterState,
        BoulderState,
        FireState,
        TrunkState,
        ClearState
    }

    public partial class Map : Form
    {
        ClickState currentState;
        Button[,] buttonGrid;

        public Map()
        {
            InitializeComponent();
            Control1_MouseClick(this);
            MouseClick += ChangeColor;
        }

        private void mapBackground_Click(object sender, EventArgs e)
        {

        }

        private void Map_Load(object sender, EventArgs e)
        {
            //Loads the map, legend, and a grid of buttons to be clicked for editing
            int scale = 64;
            currentState = ClickState.NoState;
            buttonGrid = new Button[mapBackground.Width / 64, mapBackground.Height / 64];
            Size buttonSize = new Size();
            buttonSize.Width = 64;
            buttonSize.Height = 64;

            

            //Load and populate button grid
            for (int x = 0; x < mapBackground.Height/scale; x += 1)
            {
                for (int y = 0; y < mapBackground.Width/scale; y += 1)
                {
                    //Define defaults for every new button and make active/visible
                    buttonGrid[y, x] = new Button();
                    buttonGrid[y, x].Size = (buttonSize);
                    buttonGrid[y, x].Name = "button" + x + y;
                    buttonGrid[y, x].Location = new Point(y*scale, x*scale);
                    buttonGrid[y, x].Enabled = true;
                    buttonGrid[y, x].Visible = true;
                    buttonGrid[y, x].Text = "" + x + ", " + y;
                    this.Controls.Add(buttonGrid[y, x]);
                    buttonGrid[y, x].BringToFront();
                }
            }

            //Load ability of buttons to change color
            foreach (Control c in this.Controls)
            {

                if (c.Name.Contains("button"))
                {
                    c.Click += ChangeColor;
                }
                
            }

        }

        //Check for color coding on mouse click
        private void Control1_MouseClick(Control container)
        {
            //Get mouse position as a rectangle
            Rectangle mousePosition = new Rectangle(new Point(MousePosition.X, MousePosition.Y), new Size(1, 1));

            //DOES NOT WORK, buttons generated in Load do not show up in list of controls
            
        }

        private void ChangeColor(Object sender, EventArgs e)
        {
            Control c = (Control)sender;
            if (c.Name.Contains("button"))
            {
                switch (currentState)
                {
                    case ClickState.TreeState:
                        c.BackColor = Color.ForestGreen;
                        break;
                    case ClickState.BoulderState:
                        c.BackColor = Color.SlateGray;
                        break;
                    case ClickState.WaterState:
                        c.BackColor = Color.PaleTurquoise;
                        break;
                    case ClickState.FireState:
                        c.BackColor = Color.OrangeRed;
                        break;
                    case ClickState.TrunkState:
                        c.BackColor = Color.Peru;
                        break;
                    case ClickState.ClearState:
                        c.BackColor = Color.Transparent;
                        break;
                    default:
                        break;
                }
            }
            
        }

        //Methods to change state when a corresponding button is clicked
        private void boulderButton_Click(object sender, EventArgs e)
        {
            currentState = ClickState.BoulderState;
        }

        private void treeButton_Click(object sender, EventArgs e)
        {
            currentState = ClickState.TreeState;
        }

        private void waterButton_Click(object sender, EventArgs e)
        {
            currentState = ClickState.WaterState;
        }

        private void fireButton_Click(object sender, EventArgs e)
        {
            currentState = ClickState.FireState;
        }

        private void trunkButton_Click(object sender, EventArgs e)
        {
            currentState = ClickState.TrunkState;
        }

        //Exports the map to a txt file
        private void ExportButton_Click(object sender, EventArgs e)
        {
            StreamWriter output = null;
            int scale = 64;
            int count = 0;

            //Ask the user for where to putput the file
            string filename;
            SaveFileDialog whereToSave = new SaveFileDialog();
            whereToSave.ShowDialog();
            
            filename = whereToSave.FileName;

            if (!filename.Contains(".txt"))
            {
                filename = whereToSave.FileName + ".txt";
            }

            //Make sure file exists and is not open
            try
            {
                output = new StreamWriter(filename);

                //Write by character to grid on txt file
                for (int y = 0; y < buttonGrid.GetLength(1); y++)
                {
                    for (int x = 0; x < buttonGrid.GetLength(0); x++)
                    {
                        if (buttonGrid[x, y].BackColor == Color.ForestGreen)
                        {
                            output.Write("t");
                        }
                        else if (buttonGrid[x, y].BackColor == Color.SlateGray)
                        {
                            output.Write("b");
                        }
                        else if (buttonGrid[x, y].BackColor == Color.PaleTurquoise)
                        {
                            output.Write("w");
                        }
                        else if (buttonGrid[x, y].BackColor == Color.OrangeRed)
                        {
                            output.Write("f");
                        }
                        else if (buttonGrid[x, y].BackColor == Color.Peru)
                        {
                            output.Write("s");
                        }
                        else
                        {
                            output.Write("x");
                        }

                    }
                    output.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\tError exporting map: " + ex.Message);
            }

            if (output != null)
            {
                output.Close();
            }


        }

        private void TrunkButton_Click_1(object sender, EventArgs e)
        {
            currentState = ClickState.TrunkState;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            currentState = ClickState.ClearState;
        }
    }
}
