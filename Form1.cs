using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customscrollbars
{
    public partial class customscrolls : Form
    {
        public customscrolls()
        {
            InitializeComponent();
        }
        bool ismouseonscroll = false;
        private void scrollbutton_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismouseonscroll)
            {
                // preventing user from going negative X
                if (scrollbutton.Location.X < 0)
                {
                    ismouseonscroll = false;
                    scrollbutton.Location = new Point(2, 0);
                    return;
                }
                // preventing user from going over maximum X
                else if (scrollbutton.Location.X >= scrollbarhandler.Size.Width-scrollbutton.Size.Width)
                {
                    ismouseonscroll = false;
                    scrollbutton.Location = new Point(scrollbarhandler.Size.Width - scrollbutton.Size.Width - 2, 0);
                }
                // otherwise scroll normally
                else
                {
                    scrollbutton.Location = new Point(e.X + scrollbutton.Location.X - 30, 0);
                    flowLayoutPanel1.AutoScrollPosition = new Point(scrollbutton.Location.X * 7, 0);
                }

            }
        }
        private void scrollusingloc_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismouseonscroll)
            {
                // preventing user from going negative X
                if (scrollusingloc.Location.X < 0)
                {
                    ismouseonscroll = false;
                    scrollusingloc.Location = new Point(2, 0);
                    flowLayoutPanel2.Location = new Point(0, flowLayoutPanel2.Location.Y);
                    return;
                }
                // preventing user from going over maximum X
                else if (scrollusingloc.Location.X >= scrollhandler2.Size.Width - scrollusingloc.Size.Width)
                {
                    ismouseonscroll = false;
                    scrollusingloc.Location = new Point(scrollhandler2.Size.Width - scrollusingloc.Size.Width - 2, 0);
                }
                // otherwise scroll normally
                else
                {
                    scrollusingloc.Location = new Point(e.X + scrollusingloc.Location.X - 30, 0);
                    // change the -1 to something else to change scroll power, but don't go over 0, neither place 0, i think you understand why
                    flowLayoutPanel2.Location = new Point(scrollusingloc.Location.X*-5, flowLayoutPanel2.Location.Y);
                }

            }
        }
        private void scrollbutton_MouseUp(object sender, MouseEventArgs e)
        {
            ismouseonscroll = false;
        }

        private void scrollbutton_MouseDown(object sender, MouseEventArgs e)
        {
            ismouseonscroll = true;
        }

        private void customscrolls_Load(object sender, EventArgs e)
        {
            Console.WriteLine(scrollbarhandler.Size.Width);
        }

       
    }
}
