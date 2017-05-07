namespace Grupp_31_SystemUtveckling
{
    partial class MapSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_map = new System.Windows.Forms.ComboBox();
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.tb_map = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rb_1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_map
            // 
            this.cb_map.FormattingEnabled = true;
            this.cb_map.Location = new System.Drawing.Point(35, 126);
            this.cb_map.Name = "cb_map";
            this.cb_map.Size = new System.Drawing.Size(398, 24);
            this.cb_map.TabIndex = 0;
            // 
            // rb_2
            // 
            this.rb_2.AutoSize = true;
            this.rb_2.Location = new System.Drawing.Point(12, 159);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(17, 16);
            this.rb_2.TabIndex = 3;
            this.rb_2.UseVisualStyleBackColor = true;
            // 
            // tb_map
            // 
            this.tb_map.Location = new System.Drawing.Point(36, 158);
            this.tb_map.Name = "tb_map";
            this.tb_map.Size = new System.Drawing.Size(397, 22);
            this.tb_map.TabIndex = 4;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(358, 62);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 26);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rb_1
            // 
            this.rb_1.AutoSize = true;
            this.rb_1.Checked = global::Grupp_31_SystemUtveckling.Properties.Settings.Default.True;
            this.rb_1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Grupp_31_SystemUtveckling.Properties.Settings.Default, "True", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rb_1.Location = new System.Drawing.Point(12, 129);
            this.rb_1.Name = "rb_1";
            this.rb_1.Size = new System.Drawing.Size(17, 16);
            this.rb_1.TabIndex = 1;
            this.rb_1.TabStop = true;
            this.rb_1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 34);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select a MAP from the dropdown list or directly type the directory \r\nin the text " +
    "box.";
            // 
            // MapSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 192);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.tb_map);
            this.Controls.Add(this.rb_2);
            this.Controls.Add(this.rb_1);
            this.Controls.Add(this.cb_map);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MapSelector";
            this.ShowIcon = false;
            this.Text = "MapSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_map;
        private System.Windows.Forms.RadioButton rb_1;
        private System.Windows.Forms.RadioButton rb_2;
        private System.Windows.Forms.TextBox tb_map;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}