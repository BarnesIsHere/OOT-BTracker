using OOT_BTracker.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml;

namespace OOT_BTracker
{
    public class ItemTracker
    {
        main parent;
        KeySanity keySanity;
        private Items load;
        private float ausblend = 0.5F, einblend = 2F;
        List<Button> buttons = new List<Button>();
        private FontFamily family;
        public PrivateFontCollection pfc = new PrivateFontCollection();


        private int[] dungeon_state = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private string[] dungeon_name = { "FREE", "DEKU", "DCVN", "JABU", "FRST", "FIRE", "WATR", "SHDW", "SPRT"};

        public ItemTracker(main sender)
        {
            parent = sender; 
            load = parent.loaditems;
            family = parent.pfc.Families[0];
            Init_buttons();
        }
        public void Set_KeySanity(KeySanity k)
        {
            this.keySanity = k;
        }

        // Erstelle alle Items die für den Tracker benötigt werden

        private List<string> Array_Auslesen(ArrayList arraylist)
        {
            List<string> itemlist = (List<string>)arraylist[7];
            return itemlist;
        }

        public void Init_buttons()
        {
            int zeile = 9;
            int zeilec = 0, spaltec = 0;

            for(int i = 0; i < load.output.items.Count(); i++)
            {
                string itemnames = load.output.items[i].name;
                int itemstatus = load.output.items[i].status;
                bool itemuncheck = load.output.items[i].uncheck;
                int tracktype = load.output.items[i].type;
                string itemtext = load.output.items[i].text;
                int itemmin = load.output.items[i].min;
                int itemmax = load.output.items[i].max;
                string picture = load.output.items[i].pictures[itemstatus].name;

                ResourceManager rm = Resources.ResourceManager;

                Button tbut = new Button();
                tbut.Image = (Bitmap)rm.GetObject(picture);
                if (itemnames != "Leerer Slot" & itemstatus == 0 & itemuncheck & picture != "")
                {
                    tbut.Image = SetImageOpacity(tbut.Image, 0.5F);
                }


                tbut.Tag = i;
                tbut.Size = new Size(48, 48);
                tbut.Location = new Point(10 + (zeilec * 48), 40 + (spaltec * 48));
                tbut.FlatStyle = FlatStyle.Flat;
                tbut.FlatAppearance.BorderSize = 0;
                tbut.FlatAppearance.MouseOverBackColor = Color.Transparent;
                tbut.FlatAppearance.MouseDownBackColor = Color.Transparent;
                tbut.Text = itemtext;
                tbut.Font = new Font(parent.pfc.Families[0], 8F, FontStyle.Regular);
                tbut.TextAlign = ContentAlignment.BottomRight;
                if (tracktype == 4)
                {
                    tbut.TextAlign = ContentAlignment.BottomCenter;
                    tbut.ForeColor = Color.DarkGray;
                }
                if (tracktype == 5)
                {
                    tbut.ForeColor = Color.DarkGray;
                }
                tbut.MouseDown += new MouseEventHandler(tbuttons);
                parent.Controls.Add(tbut);
                buttons.Add(tbut);
                zeilec++;
                if (zeilec == zeile)
                {
                    zeilec = 0;
                    spaltec++;
                }
            }


            /*
            for (int i = 0; i < items.Count(); i++)
            {
                MessageBox.Show(items[i].ToArray()[0].ToString());
            }
            */
        }


        public Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }
        private void tbuttons(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            int pos = Convert.ToInt32(button.Tag);
            ResourceManager rm = Resources.ResourceManager;
            string itemnames = load.output.items[pos].name;
            int itemstatus = load.output.items[pos].status;
            bool itemuncheck = load.output.items[pos].uncheck;
            int tracktype = load.output.items[pos].type;
            string itemtext = load.output.items[pos].text;
            int itemmin = load.output.items[pos].min;
            int itemmax = load.output.items[pos].max;
            string picture;
            try
            {
                picture = load.output.items[pos].pictures[itemstatus].name;
            }
            catch
            {
                picture = "";
            }

            if (itemnames != "Leerer Slot")
            {
                switch (e.Button)
                {
                    case MouseButtons.Right:
                        switch (tracktype)
                        {
                            case 0:
                                if (itemstatus != 0)
                                {
                                    if (itemuncheck)
                                    {
                                        button.Image = SetImageOpacity(button.Image, ausblend);
                                        itemstatus--;
                                        if(itemnames == "Membership" & keySanity != null)
                                        {
                                            keySanity.Set_GF(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                switch (itemstatus)
                                {
                                    default:
                                        if(itemstatus == itemmax)
                                        {
                                            button.ForeColor = Color.White;
                                            itemstatus--;
                                            
                                            button.Text = itemstatus.ToString();
                                            load.output.items[pos].text = button.Text;
                                        }
                                        else
                                        {
                                            if (itemstatus != 0)
                                            {
                                                itemstatus--;
                                                button.Text = itemstatus.ToString();
                                                load.output.items[pos].text = button.Text;
                                            }
                                        }
                                        break;
                                    case 1:
                                        itemstatus--;
                                        button.Text = "";
                                        load.output.items[pos].text = button.Text;
                                        if (itemuncheck) button.Image = SetImageOpacity(button.Image, ausblend);
                                        break;
                                }
                                break;
                            case 2:
                                if (itemstatus == itemmax)
                                {
                                    button.ForeColor = Color.White;
                                    itemstatus -= 10;
                                    button.Text = itemstatus.ToString();
                                    load.output.items[pos].text = button.Text;
                                }
                                else
                                if(itemstatus == itemmin)
                                {
                                    itemstatus = 0;
                                    button.Text = "";
                                    load.output.items[pos].text = button.Text;
                                    button.Image = SetImageOpacity(button.Image, ausblend);
                                }
                                else
                                if (itemstatus != 0)
                                {
                                    itemstatus -= 10;
                                    button.Text = itemstatus.ToString();
                                    load.output.items[pos].text = button.Text;
                                }
                                break;
                            case 3:
                                switch (itemstatus)
                                {
                                    case 1:
                                        if (itemuncheck) button.Image = SetImageOpacity(button.Image, ausblend);
                                        button.Text = itemtext;
                                        load.output.items[pos].text = button.Text;
                                        itemstatus--;
                                        break;
                                    default:
                                        if (itemstatus >itemmin)
                                        {
                                            itemstatus--;
                                            picture = load.output.items[pos].pictures[itemstatus-1].name;
                                            button.Image = (Bitmap)rm.GetObject(picture);

                                            Button_Change(button, picture);
                                        }
                                        break;
                                }
                                break;
                            case 4:
                                if (itemstatus == 0)
                                {
                                    Dungeon_Change(button);
                                }
                                if (itemstatus != 0)
                                {
                                    if (itemuncheck)
                                    {
                                        button.Image = SetImageOpacity(button.Image, ausblend);
                                        itemstatus--;
                                        button.ForeColor = Color.DarkGray;
                                    }
                                }
                                break;
                            case 5:
                                if (itemstatus != 0)
                                {
                                    if (itemuncheck)
                                    {
                                        button.Image = SetImageOpacity(button.Image, ausblend);
                                        itemstatus--;
                                        button.ForeColor = Color.DarkGray;
                                    }
                                }
                                break;
                        }
                        break;
                    case MouseButtons.Left:
                        switch (tracktype)
                        {
                            case 0:
                                if (itemstatus != 1)
                                {
                                    button.Image = SetImageOpacity(button.Image, einblend);
                                    itemstatus++;
                                    if (itemnames == "Membership" & keySanity != null)
                                    {
                                        keySanity.Set_GF(true);
                                    }
                                }
                                break;
                            case 1:
                                switch (itemstatus)
                                {
                                    case 0:
                                        button.Image = SetImageOpacity(button.Image, einblend);
                                        itemstatus++;
                                        button.Text = itemstatus.ToString();
                                        load.output.items[pos].text = button.Text;
                                        button.TextAlign = ContentAlignment.BottomRight;
                                        break;
                                    default:
                                        if (itemstatus < itemmax)
                                        {
                                            itemstatus++;
                                            button.Text = itemstatus.ToString();
                                            load.output.items[pos].text = button.Text;
                                            if (itemstatus == itemmax) button.ForeColor = Color.FromArgb(54, 255, 54); 
                                        }
                                        break;
                                }
                                break;
                            case 2:
                                switch (itemstatus)
                                {
                                    case 0:
                                        button.Image = SetImageOpacity(button.Image, einblend);
                                        itemstatus += itemmin;
                                        button.Text = itemstatus.ToString();
                                        load.output.items[pos].text = button.Text;
                                        button.TextAlign = ContentAlignment.BottomRight;
                                        break;
                                    default:
                                        if (itemstatus < itemmax)
                                        {
                                            itemstatus +=10;
                                            button.Text = itemstatus.ToString();
                                            load.output.items[pos].text = button.Text;
                                            if (itemstatus == itemmax) button.ForeColor = Color.FromArgb(54, 255, 54);
                                        }
                                        break;
                                }
                                break;
                            case 3:
                                switch (itemstatus)
                                {
                                    case 0:
                                        button.Image = SetImageOpacity(button.Image, einblend);
                                        itemstatus++;
                                        picture = load.output.items[pos].pictures[itemstatus - 1].name;
                                        Button_Change(button, picture);
                                        break;
                                    default:
                                        if (itemstatus < itemmax)
                                        {
                                            itemstatus++;
                                            picture = load.output.items[pos].pictures[itemstatus - 1].name;
                                            button.Image = (Bitmap)rm.GetObject(picture);
                                            Button_Change(button, picture);
                                        }
                                        break;
                                }
                                break;
                            case 4:
                                if (itemstatus != 1)
                                {
                                    button.Image = SetImageOpacity(button.Image, einblend);
                                    itemstatus++;
                                    button.ForeColor = Color.White;
                                }


                                break;
                            case 5:
                                if (itemstatus != 1)
                                {
                                    button.Image = SetImageOpacity(button.Image, einblend);
                                    itemstatus++;
                                    button.ForeColor = Color.White;
                                }
                                break;
                        }
                        break;
                }
                load.output.items[pos].status = itemstatus;
            }
            //MessageBox.Show("Auf Positon: " + pos + " Folgender Status: " + Convert.ToInt32(items[pos].ToArray()[1]).ToString());
        }

        private void Button_Change(Button button, string item)
        {
            switch (item)
            {
                case "wallet_default":
                    button.Text = "99";
                    break;
                case "wallet_silver":
                    button.Text = "200";
                    button.ForeColor = Color.White;
                    break;
                case "wallet_gold":
                    button.Text = "500";
                    button.ForeColor = Color.FromArgb(54, 255, 54);
                    break;
                case "wallet_tycoon":
                    button.Text = "999";
                    button.ForeColor = Color.FromArgb(54, 255, 54);
                    break;
                case "scale_silver":
                    button.Text = "S";
                    break;
                case "scale_gold":
                    button.Text = "G";
                    break;
                case "magic_power_small":
                    button.Text = "";
                    break;
                case "magic_power_big":
                    button.Text = "+";
                    break;
            }
        }

        private void Dungeon_Change(Button button)
        {
            button.Font = new Font(family, 7.0F, FontStyle.Regular);
            switch (button.Text)
            {
                case "???":
                    Switch_Dungeons(button, -1);
                    break;
                case "FREE":
                    Switch_Dungeons(button, 0);
                    break;
                case "DEKU":
                    Switch_Dungeons(button, 1);
                    break;
                case "DCVN":
                    Switch_Dungeons(button, 2);
                    break;
                case "JABU":
                    Switch_Dungeons(button, 3);
                    break;
                case "FRST":
                    Switch_Dungeons(button, 4);
                    break;
                case "FIRE":
                    Switch_Dungeons(button, 5);
                    break;
                case "WATR":
                    Switch_Dungeons(button, 6);
                    break;
                case "SHDW":
                    Switch_Dungeons(button, 7);
                    break;
                case "SPRT":
                    Switch_Dungeons(button, 8);
                    break;
            }
        }

        private void Switch_Dungeons(Button button, int akt_dungeon)
        {
            int z = 0;
            if(akt_dungeon != -1) z = akt_dungeon;
            
            for (int i = z;  i < dungeon_state.Count(); i++)
            {
                if (dungeon_state[i] == 0)
                {
                    button.Text = dungeon_name[i];
                    dungeon_state[i] = 1;
                    if (akt_dungeon != i & akt_dungeon != -1) dungeon_state[akt_dungeon] = 0;
                    break;
                }
                if(dungeon_state.Count() - 1 == i)
                {
                    if (akt_dungeon != -1)
                    {
                        dungeon_state[akt_dungeon] = 0;
                    }
                    button.Text = "???";
                }
            }
        }

        public void Set_GF(Boolean active)
        {
            for(int i = 0; i < load.output.items.Count(); i++)
            {
                string itemnames = load.output.items[i].name;
                int itemstatus = load.output.items[i].status;
                if(itemnames == "Membership")
                {
                    if(active)
                    {
                        load.output.items[i].status = 1;
                        buttons[i].Image = SetImageOpacity(buttons[i].Image, einblend);
                    }
                    else
                    {
                        load.output.items[i].status = 0;
                        buttons[i].Image = SetImageOpacity(buttons[i].Image, ausblend);
                    }
                }
            }
        }

        public Boolean Get_GF()
        {
            for (int i = 0; i < load.output.items.Count(); i++)
            {
                if (load.output.items[i].name == "Membership")
                {
                    return Convert.ToBoolean(load.output.items[i].status);
                }
            }
            return false;
        }
    }
}
