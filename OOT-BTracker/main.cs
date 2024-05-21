using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOT_BTracker
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            InitButtons();
            InitButtonStates();
        }
        int stick_value, nut_value, bombs_value, bow_value, arrow_fire_value, magic_din_value, sword_kokiri_value, sword_master_value, sword_biggoron_value;

        private void InitButtonStates()
        {
            InitStates(stick_value = 0, stick);
            InitStates(nut_value = 0, nut);
            InitStates(bombs_value = 0, bombs);
            InitStates(bow_value = 0, bow);
            InitStates(arrow_fire_value = 0, arrow_fire);
            InitStates(magic_din_value = 0, magic_din);
            InitStates(sword_kokiri_value = 0, sword_kokiri);
            InitStates(sword_master_value = 0, sword_master);
            InitStates(sword_biggoron_value = 0, sword_biggoron);
        }

        private void InitStates(int value, Button button)
        {
            switch (value)
            {
                default:
                    break;
                case 0:
                    button.Image = SetImageOpacity(button.Image, 0.5F);
                    switch (button.Text)
                    {
                        default:
                            button.Text = "";
                            break;
                        case "Din":
                            button.ForeColor = Color.Gray;
                            break;
                        case "Fire":
                            button.ForeColor = Color.Gray;
                            break;
                    }
                    break;
            }
        }

        /** Initialisiere Buttons */
        private void InitButtons()
        {
            stick.FlatAppearance.BorderSize = 0;
            stick.FlatAppearance.MouseOverBackColor = Color.Transparent;
            stick.FlatAppearance.MouseDownBackColor = Color.Transparent;

            nut.FlatAppearance.BorderSize = 0;
            nut.FlatAppearance.MouseOverBackColor = Color.Transparent;
            nut.FlatAppearance.MouseDownBackColor = Color.Transparent;

            bombs.FlatAppearance.BorderSize = 0;
            bombs.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bombs.FlatAppearance.MouseDownBackColor = Color.Transparent;

            bow.FlatAppearance.BorderSize = 0;
            bow.FlatAppearance.MouseOverBackColor = Color.Transparent;
            bow.FlatAppearance.MouseDownBackColor = Color.Transparent;

            arrow_fire.FlatAppearance.BorderSize = 0;
            arrow_fire.FlatAppearance.MouseOverBackColor = Color.Transparent;
            arrow_fire.FlatAppearance.MouseDownBackColor = Color.Transparent;

            magic_din.FlatAppearance.BorderSize = 0;
            magic_din.FlatAppearance.MouseOverBackColor = Color.Transparent;
            magic_din.FlatAppearance.MouseDownBackColor = Color.Transparent;

            sword_kokiri.FlatAppearance.BorderSize = 0;
            sword_kokiri.FlatAppearance.MouseOverBackColor = Color.Transparent;
            sword_kokiri.FlatAppearance.MouseDownBackColor = Color.Transparent;

            sword_master.FlatAppearance.BorderSize = 0;
            sword_master.FlatAppearance.MouseOverBackColor = Color.Transparent;
            sword_master.FlatAppearance.MouseDownBackColor = Color.Transparent;

            sword_biggoron.FlatAppearance.BorderSize = 0;
            sword_biggoron.FlatAppearance.MouseOverBackColor = Color.Transparent;
            sword_biggoron.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        /** Verändert Bild zu Transparent */
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

        private void stick_MouseDown(object sender, MouseEventArgs e)
        {
            Int32.TryParse(stick.Text, out int result);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (result)
                    {
                        default:
                            stick.Text = (result + 10).ToString();
                            stick_value++;
                            break;
                        case 0:
                            stick.Image = SetImageOpacity(stick.Image, 2F);
                            stick.Text = "10";
                            stick_value++;
                            break;
                        case 20:
                            stick.ForeColor = Color.GreenYellow;
                            stick.Text = "30";
                            stick_value++;
                            break;
                        case 30:
                            break;
                    }
                    break;

                case MouseButtons.Right:
                    switch (result)
                    {
                        default:
                            stick.Text = (result - 10).ToString();
                            stick_value--;
                            break;
                        case 10:
                            stick.Image = SetImageOpacity(stick.Image, 0.5F);
                            stick.Text = "";
                            stick_value--;
                            break;
                        case 30:
                            stick.ForeColor = Color.White;
                            stick.Text = (result - 10).ToString();
                            stick_value--;
                            break;
                        case 0:
                            break;
                    }
                    break;
            }
        }

        private void nut_MouseDown(object sender, MouseEventArgs e)
        {
            Int32.TryParse(nut.Text, out int result);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (result)
                    {
                        default:
                            nut.Text = (result + 10).ToString();
                            nut_value++;
                            break;
                        case 0:
                            nut.Image = SetImageOpacity(nut.Image, 2F);
                            nut.Text = "20";
                            nut_value++;
                            break;
                        case 30:
                            nut.ForeColor = Color.GreenYellow;
                            nut.Text = "40";
                            nut_value++;
                            break;
                        case 40:
                            break;
                    }
                    break;

                case MouseButtons.Right:
                    switch (result)
                    {
                        default:
                            nut.Text = (result - 10).ToString();
                            nut_value--;
                            break;
                        case 10:
                            nut.Image = SetImageOpacity(nut.Image, 0.5F);
                            nut.Text = "";
                            nut_value--;
                            break;
                        case 40:
                            nut.ForeColor = Color.White;
                            nut.Text = (result - 10).ToString();
                            nut_value--;
                            break;
                        case 0:
                            break;
                    }
                    break;
            }
        }

        private void bombs_MouseDown(object sender, MouseEventArgs e)
        {

            Int32.TryParse(bombs.Text, out int result);
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (result)
                    {
                        default:
                            bombs.Text = (result + 10).ToString();
                            bombs_value++;
                            break;
                        case 0:
                            bombs.Image = SetImageOpacity(bombs.Image, 2F);
                            bombs.Text = "20";
                            bombs_value++;
                            break;
                        case 30:
                            bombs.ForeColor = Color.GreenYellow;
                            bombs.Text = "40";
                            bombs_value++;
                            break;
                        case 40:
                            break;
                    }
                    break;

                case MouseButtons.Right:
                    switch (result)
                    {
                        default:
                            bombs.Text = (result - 10).ToString();
                            bombs_value--;
                            break;
                        case 10:
                            bombs.Image = SetImageOpacity(bombs.Image, 0.5F);
                            bombs.Text = "";
                            bombs_value--;
                            break;
                        case 40:
                            bombs.ForeColor = Color.White;
                            bombs.Text = (result - 10).ToString();
                            bombs_value--;
                            break;
                        case 0:
                            break;
                    }
                    break;
            }
        }

        private void bow_Click(object sender, EventArgs e)
        {
            switch (bow_value)
            {
                case 0:
                    bow.Image = SetImageOpacity(bow.Image, 2F);
                    bow.Text = "30";
                    bow_value = 1;
                    break;
                case 1:
                    bow.Image = SetImageOpacity(bow.Image, 0.5F);
                    bow.Text = "";
                    bow_value = 0;
                    break;
            }
        }

        private void arrow_fire_Click(object sender, EventArgs e)
        {
            switch (arrow_fire_value)
            {
                case 0:
                    arrow_fire.Image = SetImageOpacity(arrow_fire.Image, 2F);
                    arrow_fire.ForeColor = Color.White;
                    arrow_fire_value = 1;
                    break;
                case 1:
                    arrow_fire.Image = SetImageOpacity(arrow_fire.Image, 0.5F);
                    arrow_fire.ForeColor = Color.Gray;
                    arrow_fire_value = 0;
                    break;
            }
        }

        private void magic_din_Click(object sender, EventArgs e)
        {
            switch (magic_din_value)
            {
                case 0:
                    magic_din.Image = SetImageOpacity(magic_din.Image, 2F);
                    magic_din.ForeColor = Color.White;
                    magic_din_value = 1;
                    break;
                case 1:
                    magic_din.Image = SetImageOpacity(magic_din.Image, 0.5F);
                    magic_din.ForeColor = Color.Gray;
                    magic_din_value = 0;
                    break;
            }
        }

        private void sword_kokiri_Click(object sender, EventArgs e)
        {
            switch (sword_kokiri_value)
            {
                case 0:
                    sword_kokiri.Image = SetImageOpacity(sword_kokiri.Image, 2F);
                    sword_kokiri_value = 1;
                    break;
                case 1:
                    sword_kokiri.Image = SetImageOpacity(sword_kokiri.Image, 0.5F);
                    sword_kokiri_value = 0;
                    break;
            }
        }

        private void sword_master_Click(object sender, EventArgs e)
        {
            switch (sword_master_value)
            {
                case 0:
                    sword_master.Image = SetImageOpacity(sword_master.Image, 2F);
                    sword_master_value = 1;
                    break;
                case 1:
                    sword_master.Image = SetImageOpacity(sword_master.Image, 0.5F);
                    sword_master_value = 0;
                    break;
            }
        }

        private void sword_biggoron_Click(object sender, EventArgs e)
        {
            switch (sword_biggoron_value)
            {
                case 0:
                    sword_biggoron.Image = SetImageOpacity(sword_biggoron.Image, 2F);
                    sword_biggoron_value = 1;
                    break;
                case 1:
                    sword_biggoron.Image = SetImageOpacity(sword_biggoron.Image, 0.5F);
                    sword_biggoron_value = 0;
                    break;
            }
        }
    }
}
