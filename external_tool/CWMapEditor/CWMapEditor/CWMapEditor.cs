using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWMapEditor
{
    public partial class CWMapEditor : Form
    {
        public CWMapEditor()
        {
            InitializeComponent();
        }

        private void loadDefaultButton_Click(object sender, EventArgs e)
        {
            Map defaultMap = new Map();

            defaultMap.Show();
        }

        private void loadBlankButton_Click(object sender, EventArgs e)
        {
            //Instantiate map and new array of buttons for grid
            Map defaultMap = new Map();
            defaultMap.Show();

            
        }

        private void CWMapEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
