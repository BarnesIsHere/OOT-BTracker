using OOT_BTracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace OOT_BTracker
{
    public partial class main : Form
    {
        public ItemTracker itemt;
        public KeySanity keysa;
        public MapTracker mapt;
        public Items loaditems = new Items();
        public Dungeons dungeonitem = new Dungeons();
        public Areas areas = new Areas();
        //Create your private font collection object.
        public PrivateFontCollection pfc = new PrivateFontCollection();
        public main()
        {
            Fontfamily_Set();
            InitializeComponent();
            Menu_Initialize();

            this.itemt = new ItemTracker(this);
            itemt.Init_buttons();
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;



            // Aktiv für Tests
            //keysa = new KeySanity(this);
            //MessageBox.Show(oot.output.items[0].name.ToString());
        }

        public void Fontfamily_Set()
        {
            pfc.AddFontFile("../../Resources/KroneContour.ttf");
        }

        public void Window_Size(int window)
        {
            switch (window)
            {
                case 0:
                    this.Size = new Size(470, 480);
                    this.MinimumSize = new Size(470, 480);
                    this.MaximumSize = new Size(470, 480);
                    break;
                case 1:
                    this.Size = new Size(470, 610);
                    this.MinimumSize = new Size(470, 610);
                    this.MaximumSize = new Size(470, 610);
                    break;
                case 2:
                    this.Size = new Size(470 + 750, 480 + 400);
                    this.MinimumSize = new Size(470 + 750, 480 + 400);
                    this.MaximumSize = new Size(470 + 750, 480 + 400);
                    break;
            }
        }

        public ItemTracker Instance_ItemTracker()
        {
            return this.itemt;
        }

        public void Unload_All(int unloadelement)
        {

            this.Window_Size(unloadelement);
            this.Controls.Clear();
            this.Controls.Add(modus_btn);
            this.Controls.Add(modus_normal_btn);
            this.Controls.Add(modus_keysanity_btn);
            this.Controls.Add(modus_map_btn);
            switch (unloadelement)
            {
                case 0:
                    if (keysa != null)
                    {
                        keysa = null;
                    }
                    if (mapt != null)
                    {
                        mapt = null;
                    }
                    itemt.Init_buttons();
                    break;
                case 1:
                    keysa = new KeySanity(this);
                    if (mapt != null)
                    {
                        mapt = null;
                    }
                    itemt.Set_KeySanity(keysa);
                    itemt.Init_buttons();
                    keysa.Set_ItemTracker(itemt);
                    keysa.Init_Items();
                    break;
                case 2:
                    if (keysa == null)
                        keysa = new KeySanity(this);
                    mapt = new MapTracker(this);
                    itemt.Set_KeySanity(keysa);
                    itemt.Init_buttons();
                    keysa.Set_ItemTracker(itemt);
                    keysa.Init_Items();
                    mapt.Init_Buttons();
                    break;
            }
            
            
        }

        private void Menu_Initialize()
        {
            modus_btn.FlatAppearance.BorderSize = 0;
            modus_normal_btn.FlatAppearance.BorderSize = 0;
            modus_keysanity_btn.FlatAppearance.BorderSize= 0;
            modus_map_btn.FlatAppearance.BorderSize = 0;
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
            Unload_All(0);
            Modus_Btn_Visible_Hide();
        }

        private void Modus_Btn_Visible_Hide()
        {
            modus_normal_btn.Visible = !modus_normal_btn.Visible;
            modus_keysanity_btn.Visible = !modus_keysanity_btn.Visible;
            modus_map_btn.Visible = !modus_map_btn.Visible;
        }

        private void modus_keysanity_btn_Click(object sender, EventArgs e)
        {
            Unload_All(1);
            Modus_Btn_Visible_Hide();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaint(e);
            if (keysa != null)
            {
                keysa.DrawLine(e);
            }
        }

        private void modus_map_btn_Click(object sender, EventArgs e)
        {
            Unload_All(2);
            Modus_Btn_Visible_Hide();
        }

        private void modus_map_btn_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(sender);
        }

        private void modus_map_btn_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(sender);
        }
    }
}
