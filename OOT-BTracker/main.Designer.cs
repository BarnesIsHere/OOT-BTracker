namespace OOT_BTracker
{
    partial class main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modus_btn = new System.Windows.Forms.Button();
            this.modus_normal_btn = new System.Windows.Forms.Button();
            this.modus_keysanity_btn = new System.Windows.Forms.Button();
            this.modus_map_btn = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(106, 26);
            // 
            // menuToolStripMenuItem1
            // 
            this.menuToolStripMenuItem1.Name = "menuToolStripMenuItem1";
            this.menuToolStripMenuItem1.Size = new System.Drawing.Size(105, 22);
            this.menuToolStripMenuItem1.Text = "Menu";
            // 
            // modus_btn
            // 
            this.modus_btn.BackColor = System.Drawing.Color.Black;
            this.modus_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modus_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modus_btn.ForeColor = System.Drawing.Color.White;
            this.modus_btn.Location = new System.Drawing.Point(1, 2);
            this.modus_btn.Margin = new System.Windows.Forms.Padding(0);
            this.modus_btn.Name = "modus_btn";
            this.modus_btn.Size = new System.Drawing.Size(75, 30);
            this.modus_btn.TabIndex = 2;
            this.modus_btn.Text = "Modus";
            this.modus_btn.UseVisualStyleBackColor = false;
            this.modus_btn.Click += new System.EventHandler(this.modus_btn_Click);
            this.modus_btn.MouseEnter += new System.EventHandler(this.modus_btn_MouseEnter);
            this.modus_btn.MouseLeave += new System.EventHandler(this.modus_btn_MouseLeave);
            // 
            // modus_normal_btn
            // 
            this.modus_normal_btn.BackColor = System.Drawing.Color.Black;
            this.modus_normal_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modus_normal_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modus_normal_btn.Location = new System.Drawing.Point(1, 32);
            this.modus_normal_btn.Margin = new System.Windows.Forms.Padding(0);
            this.modus_normal_btn.Name = "modus_normal_btn";
            this.modus_normal_btn.Size = new System.Drawing.Size(75, 30);
            this.modus_normal_btn.TabIndex = 3;
            this.modus_normal_btn.Text = "Normal";
            this.modus_normal_btn.UseVisualStyleBackColor = false;
            this.modus_normal_btn.Visible = false;
            this.modus_normal_btn.Click += new System.EventHandler(this.modus_normal_btn_Click);
            this.modus_normal_btn.MouseEnter += new System.EventHandler(this.modus_normal_btn_MouseEnter);
            this.modus_normal_btn.MouseLeave += new System.EventHandler(this.modus_normal_btn_MouseLeave);
            // 
            // modus_keysanity_btn
            // 
            this.modus_keysanity_btn.BackColor = System.Drawing.Color.Black;
            this.modus_keysanity_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modus_keysanity_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modus_keysanity_btn.Location = new System.Drawing.Point(1, 62);
            this.modus_keysanity_btn.Margin = new System.Windows.Forms.Padding(0);
            this.modus_keysanity_btn.Name = "modus_keysanity_btn";
            this.modus_keysanity_btn.Size = new System.Drawing.Size(75, 30);
            this.modus_keysanity_btn.TabIndex = 4;
            this.modus_keysanity_btn.Text = "Keysanity";
            this.modus_keysanity_btn.UseVisualStyleBackColor = false;
            this.modus_keysanity_btn.Visible = false;
            this.modus_keysanity_btn.Click += new System.EventHandler(this.modus_keysanity_btn_Click);
            this.modus_keysanity_btn.MouseEnter += new System.EventHandler(this.modus_keysanity_btn_MouseEnter);
            this.modus_keysanity_btn.MouseLeave += new System.EventHandler(this.modus_keysanity_btn_MouseLeave);
            // 
            // modus_map_btn
            // 
            this.modus_map_btn.BackColor = System.Drawing.Color.Black;
            this.modus_map_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modus_map_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modus_map_btn.Location = new System.Drawing.Point(1, 92);
            this.modus_map_btn.Margin = new System.Windows.Forms.Padding(0);
            this.modus_map_btn.Name = "modus_map_btn";
            this.modus_map_btn.Size = new System.Drawing.Size(75, 30);
            this.modus_map_btn.TabIndex = 5;
            this.modus_map_btn.Text = "Map";
            this.modus_map_btn.UseVisualStyleBackColor = false;
            this.modus_map_btn.Visible = false;
            this.modus_map_btn.Click += new System.EventHandler(this.modus_map_btn_Click);
            this.modus_map_btn.MouseEnter += new System.EventHandler(this.modus_map_btn_MouseEnter);
            this.modus_map_btn.MouseLeave += new System.EventHandler(this.modus_map_btn_MouseLeave);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(454, 441);
            this.Controls.Add(this.modus_map_btn);
            this.Controls.Add(this.modus_keysanity_btn);
            this.Controls.Add(this.modus_normal_btn);
            this.Controls.Add(this.modus_btn);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "OOT-BTracker";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem1;
        private System.Windows.Forms.Button modus_btn;
        private System.Windows.Forms.Button modus_normal_btn;
        private System.Windows.Forms.Button modus_keysanity_btn;
        private System.Windows.Forms.Button modus_map_btn;
    }
}

