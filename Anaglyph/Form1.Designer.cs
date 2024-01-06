namespace Anaglyph
{
    partial class AnaglyphForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaglyphForm));
            this.Menu = new System.Windows.Forms.Panel();
            this.SecondTab = new Guna.UI2.WinForms.Guna2Button();
            this.FirstTab = new Guna.UI2.WinForms.Guna2Button();
            this.Label = new System.Windows.Forms.Label();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimalize = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.ThirdTab = new Guna.UI2.WinForms.Guna2Button();
            this.Menu.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.White;
            this.Menu.Controls.Add(this.ThirdTab);
            this.Menu.Controls.Add(this.SecondTab);
            this.Menu.Controls.Add(this.FirstTab);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu.Location = new System.Drawing.Point(0, 55);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(871, 63);
            this.Menu.TabIndex = 11;
            // 
            // SecondTab
            // 
            this.SecondTab.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.SecondTab.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.SecondTab.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.SecondTab.CheckedState.Parent = this.SecondTab;
            this.SecondTab.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.SecondTab.CustomImages.Parent = this.SecondTab;
            this.SecondTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SecondTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SecondTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SecondTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SecondTab.DisabledState.Parent = this.SecondTab;
            this.SecondTab.FillColor = System.Drawing.Color.White;
            this.SecondTab.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.SecondTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.SecondTab.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.SecondTab.HoverState.Parent = this.SecondTab;
            this.SecondTab.Location = new System.Drawing.Point(177, 0);
            this.SecondTab.Name = "SecondTab";
            this.SecondTab.ShadowDecoration.Parent = this.SecondTab;
            this.SecondTab.Size = new System.Drawing.Size(180, 63);
            this.SecondTab.TabIndex = 1;
            this.SecondTab.Text = "Assembly";
            this.SecondTab.Click += new System.EventHandler(this.SecondTab_Click);
            // 
            // FirstTab
            // 
            this.FirstTab.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.FirstTab.Checked = true;
            this.FirstTab.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.FirstTab.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.FirstTab.CheckedState.FillColor = System.Drawing.Color.White;
            this.FirstTab.CheckedState.Parent = this.FirstTab;
            this.FirstTab.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.FirstTab.CustomImages.Parent = this.FirstTab;
            this.FirstTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.FirstTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.FirstTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.FirstTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.FirstTab.DisabledState.Parent = this.FirstTab;
            this.FirstTab.FillColor = System.Drawing.Color.Transparent;
            this.FirstTab.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.FirstTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.FirstTab.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.FirstTab.HoverState.Parent = this.FirstTab;
            this.FirstTab.Location = new System.Drawing.Point(0, 0);
            this.FirstTab.Name = "FirstTab";
            this.FirstTab.ShadowDecoration.Parent = this.FirstTab;
            this.FirstTab.Size = new System.Drawing.Size(180, 63);
            this.FirstTab.TabIndex = 0;
            this.FirstTab.Text = "C#";
            this.FirstTab.Click += new System.EventHandler(this.FirstTab_Click);
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold);
            this.Label.ForeColor = System.Drawing.Color.White;
            this.Label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label.Location = new System.Drawing.Point(66, 7);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(183, 41);
            this.Label.TabIndex = 1;
            this.Label.Text = "Anaglyph";
            this.Label.Click += new System.EventHandler(this.Label_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.TopPanel.Controls.Add(this.buttonClose);
            this.TopPanel.Controls.Add(this.buttonMinimalize);
            this.TopPanel.Controls.Add(this.Label);
            this.TopPanel.Controls.Add(this.Logo);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(871, 55);
            this.TopPanel.TabIndex = 10;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.buttonClose.BackgroundImage = global::Anaglyph.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(831, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(28, 28);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMinimalize
            // 
            this.buttonMinimalize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.buttonMinimalize.BackgroundImage = global::Anaglyph.Properties.Resources.minimize;
            this.buttonMinimalize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMinimalize.FlatAppearance.BorderSize = 0;
            this.buttonMinimalize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimalize.Location = new System.Drawing.Point(797, 12);
            this.buttonMinimalize.Name = "buttonMinimalize";
            this.buttonMinimalize.Size = new System.Drawing.Size(28, 28);
            this.buttonMinimalize.TabIndex = 2;
            this.buttonMinimalize.UseVisualStyleBackColor = false;
            this.buttonMinimalize.Click += new System.EventHandler(this.buttonMinimalize_Click);
            // 
            // Logo
            // 
            this.Logo.Image = global::Anaglyph.Properties.Resources.images;
            this.Logo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Logo.Location = new System.Drawing.Point(12, 6);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(47, 43);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // PanelContainer
            // 
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(0, 118);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(871, 539);
            this.PanelContainer.TabIndex = 12;
            // 
            // ThirdTab
            // 
            this.ThirdTab.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.ThirdTab.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ThirdTab.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ThirdTab.CheckedState.Parent = this.ThirdTab;
            this.ThirdTab.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ThirdTab.CustomImages.Parent = this.ThirdTab;
            this.ThirdTab.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ThirdTab.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ThirdTab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ThirdTab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ThirdTab.DisabledState.Parent = this.ThirdTab;
            this.ThirdTab.FillColor = System.Drawing.Color.White;
            this.ThirdTab.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.ThirdTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ThirdTab.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ThirdTab.HoverState.Parent = this.ThirdTab;
            this.ThirdTab.Location = new System.Drawing.Point(345, 0);
            this.ThirdTab.Name = "ThirdTab";
            this.ThirdTab.ShadowDecoration.Parent = this.ThirdTab;
            this.ThirdTab.Size = new System.Drawing.Size(180, 63);
            this.ThirdTab.TabIndex = 2;
            this.ThirdTab.Text = "Result";
            this.ThirdTab.Click += new System.EventHandler(this.ThirdTab_Click);
            // 
            // AnaglyphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 657);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaglyphForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Menu.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Menu;
        private Guna.UI2.WinForms.Guna2Button SecondTab;
        private Guna.UI2.WinForms.Guna2Button FirstTab;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMinimalize;
        private Guna.UI2.WinForms.Guna2Button ThirdTab;
    }
}
// aaa
