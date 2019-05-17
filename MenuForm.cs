using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WonderGame
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            DoubleBuffered = true;
            ClientSize = new Size(600, 600);

            var play = new Button
            {
                Location = new Point(0, 0),
                Size = new Size(600, 300),
                Text = "Game!"
            };

            var exit = new Button
            {
                Location = new Point(0, 300),
                Size = new Size(600, 300),
                Text = "Exit!"
            };

            Controls.Add(play);
            play.Click += (sender, args) =>
            {
                var gameForm = new GameForm();
                gameForm.Show();
                this.Hide();
            };

            Controls.Add(exit);
            exit.Click += (sender, args) =>
            {
                this.Close();
            };
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
