namespace ProjectB
{
    partial class viewclo
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
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_return = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Viewcl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Viewcl)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Silver;
            this.btn_add.CausesValidation = false;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_add.Location = new System.Drawing.Point(67, 120);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(215, 61);
            this.btn_add.TabIndex = 25;
            this.btn_add.Text = "Add new Clo";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_return
            // 
            this.btn_return.BackColor = System.Drawing.Color.Silver;
            this.btn_return.CausesValidation = false;
            this.btn_return.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_return.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_return.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btn_return.Location = new System.Drawing.Point(536, 120);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(215, 61);
            this.btn_return.TabIndex = 28;
            this.btn_return.Text = "Return to Main Screen";
            this.btn_return.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(301, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 35);
            this.label7.TabIndex = 29;
            this.label7.Text = "Clo Portal";
            // 
            // Viewcl
            // 
            this.Viewcl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Viewcl.Location = new System.Drawing.Point(68, 220);
            this.Viewcl.Name = "Viewcl";
            this.Viewcl.Size = new System.Drawing.Size(684, 150);
            this.Viewcl.TabIndex = 30;
            this.Viewcl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Viewcl_CellContentClick);
            // 
            // viewclo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Viewcl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_return);
            this.Controls.Add(this.btn_add);
            this.Name = "viewclo";
            this.Text = "viewclo";
            this.Load += new System.EventHandler(this.viewclo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Viewcl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView Viewcl;
    }
}