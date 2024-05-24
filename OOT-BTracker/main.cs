using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OOT_BTracker
{
    public partial class main : Form
    {
        ItemTracker itemt;
        KeySanity keysa;
        public main()
        {
            InitializeComponent();
            Menu_Initialize();

            this.itemt = new ItemTracker(this);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;


            // Aktiv für Tests
            //keysa = new KeySanity(this);
        }

        public ItemTracker Instance_ItemTracker()
        {
            return this.itemt;
        }

        public void Unload_All()
        {
            itemt.Original_Size();
            keysa = null;
        }

        private void Menu_Initialize()
        {
            modus_btn.FlatAppearance.BorderSize = 0;
            modus_normal_btn.FlatAppearance.BorderSize = 0;
            modus_keysanity_btn.FlatAppearance.BorderSize= 0;
        }

        private void modus_btn_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(sender);
        }

        private void modus_btn_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(sender);
        }

        private void modus_normal_btn_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(sender);
        }

        private void modus_normal_btn_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(sender);
        }

        private void OnMouseEnter(object sender)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Black;
            button.FlatAppearance.MouseOverBackColor = Color.White;
        }

        private void OnMouseLeave(object sender)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
        }

        private void modus_keysanity_btn_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(sender);
        }

        private void modus_keysanity_btn_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(sender);
        }

        private void modus_btn_Click(object sender, EventArgs e)
        {
            Modus_Btn_Visible_Hide();
        }

        private void modus_normal_btn_Click(object sender, EventArgs e)
        {
            Unload_All();
            Modus_Btn_Visible_Hide();
        }

        private void Modus_Btn_Visible_Hide()
        {
            modus_normal_btn.Visible = !modus_normal_btn.Visible;
            modus_keysanity_btn.Visible = !modus_keysanity_btn.Visible;
        }

        private void modus_keysanity_btn_Click(object sender, EventArgs e)
        {
            if (keysa == null)
            {
                keysa = new KeySanity(this);
                itemt.Set_KeySanity(keysa);
            }
            Modus_Btn_Visible_Hide();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(keysa != null)
            {
                keysa.DrawLine(e);
            }
        }
    }
}
