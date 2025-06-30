using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamePacOop
{
    public partial class GameOverfrm : Form
    {
        public GameOverfrm()
        {
            InitializeComponent();
        }

        private void GameOverfrm_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form restartFrm = new Form1();
            restartFrm.Show();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
