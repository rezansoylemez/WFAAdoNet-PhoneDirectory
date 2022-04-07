
namespace WFAAdoNet_TelefonReber
{
    partial class AdminPaneli
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
            this.listKisiler = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.radioSeihr = new System.Windows.Forms.RadioButton();
            this.radioIlce = new System.Windows.Forms.RadioButton();
            this.txtAranan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listKisiler
            // 
            this.listKisiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listKisiler.FormattingEnabled = true;
            this.listKisiler.ItemHeight = 15;
            this.listKisiler.Location = new System.Drawing.Point(13, 13);
            this.listKisiler.Name = "listKisiler";
            this.listKisiler.Size = new System.Drawing.Size(207, 409);
            this.listKisiler.TabIndex = 0;
            this.listKisiler.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listKisiler_MouseClick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(227, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(391, 351);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Şehir";
            this.columnHeader1.Width = 99;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "İlçe";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Adres Detayı";
            this.columnHeader3.Width = 178;
            // 
            // radioSeihr
            // 
            this.radioSeihr.AutoSize = true;
            this.radioSeihr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioSeihr.Location = new System.Drawing.Point(227, 13);
            this.radioSeihr.Name = "radioSeihr";
            this.radioSeihr.Size = new System.Drawing.Size(84, 19);
            this.radioSeihr.TabIndex = 2;
            this.radioSeihr.TabStop = true;
            this.radioSeihr.Text = "Şehir Ara";
            this.radioSeihr.UseVisualStyleBackColor = true;
            // 
            // radioIlce
            // 
            this.radioIlce.AutoSize = true;
            this.radioIlce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioIlce.Location = new System.Drawing.Point(227, 38);
            this.radioIlce.Name = "radioIlce";
            this.radioIlce.Size = new System.Drawing.Size(73, 19);
            this.radioIlce.TabIndex = 2;
            this.radioIlce.TabStop = true;
            this.radioIlce.Text = "İlçe Ara";
            this.radioIlce.UseVisualStyleBackColor = true;
            // 
            // txtAranan
            // 
            this.txtAranan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAranan.Location = new System.Drawing.Point(409, 38);
            this.txtAranan.Name = "txtAranan";
            this.txtAranan.Size = new System.Drawing.Size(161, 21);
            this.txtAranan.TabIndex = 3;
            this.txtAranan.TextChanged += new System.EventHandler(this.txtAranan_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(406, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Aranan Kelime Veya Harf";
            // 
            // AdminPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 435);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAranan);
            this.Controls.Add(this.radioIlce);
            this.Controls.Add(this.radioSeihr);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.listKisiler);
            this.Name = "AdminPaneli";
            this.Text = "AdminPaneli";
            this.Load += new System.EventHandler(this.AdminPaneli_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listKisiler;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.RadioButton radioSeihr;
        private System.Windows.Forms.RadioButton radioIlce;
        private System.Windows.Forms.TextBox txtAranan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}