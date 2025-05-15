namespace Login
{
    partial class Muonsach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_thedocgia = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtg_phieumuon = new System.Windows.Forms.DataGridView();
            this.dtg_thedocgia = new System.Windows.Forms.DataGridView();
            this.grb_kiemtraphieumuon = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_kiemtraphieumuon = new System.Windows.Forms.TextBox();
            this.grb_kiemtrathedocgia = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_thedocgia = new System.Windows.Forms.TextBox();
            this.grb_ttpm = new System.Windows.Forms.GroupBox();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.checklb_sach = new System.Windows.Forms.CheckedListBox();
            this.btn_lapphieumuon = new System.Windows.Forms.Button();
            this.dtp_Ngayhethan = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Mathe = new System.Windows.Forms.TextBox();
            this.txt_timkiemsach = new System.Windows.Forms.TextBox();
            this.dgv_sach = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_Ngaymuon = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_phieumuon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_thedocgia)).BeginInit();
            this.grb_kiemtraphieumuon.SuspendLayout();
            this.grb_kiemtrathedocgia.SuspendLayout();
            this.grb_ttpm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sach)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_thedocgia
            // 
            this.lbl_thedocgia.AutoSize = true;
            this.lbl_thedocgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_thedocgia.Location = new System.Drawing.Point(858, 2);
            this.lbl_thedocgia.Name = "lbl_thedocgia";
            this.lbl_thedocgia.Size = new System.Drawing.Size(194, 25);
            this.lbl_thedocgia.TabIndex = 18;
            this.lbl_thedocgia.Text = "Thông tin thẻ độc giả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(858, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Danh sách phiếu mượn";
            // 
            // dtg_phieumuon
            // 
            this.dtg_phieumuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_phieumuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_phieumuon.Location = new System.Drawing.Point(585, 142);
            this.dtg_phieumuon.Name = "dtg_phieumuon";
            this.dtg_phieumuon.RowHeadersWidth = 51;
            this.dtg_phieumuon.RowTemplate.Height = 24;
            this.dtg_phieumuon.Size = new System.Drawing.Size(754, 628);
            this.dtg_phieumuon.TabIndex = 16;
            this.dtg_phieumuon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_phieumuon_CellClick);
            // 
            // dtg_thedocgia
            // 
            this.dtg_thedocgia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_thedocgia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_thedocgia.Location = new System.Drawing.Point(585, 30);
            this.dtg_thedocgia.Name = "dtg_thedocgia";
            this.dtg_thedocgia.RowHeadersWidth = 51;
            this.dtg_thedocgia.RowTemplate.Height = 24;
            this.dtg_thedocgia.Size = new System.Drawing.Size(754, 68);
            this.dtg_thedocgia.TabIndex = 15;
            this.dtg_thedocgia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_thedocgia_CellClick);
            // 
            // grb_kiemtraphieumuon
            // 
            this.grb_kiemtraphieumuon.Controls.Add(this.label6);
            this.grb_kiemtraphieumuon.Controls.Add(this.txt_kiemtraphieumuon);
            this.grb_kiemtraphieumuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_kiemtraphieumuon.Location = new System.Drawing.Point(3, 102);
            this.grb_kiemtraphieumuon.Name = "grb_kiemtraphieumuon";
            this.grb_kiemtraphieumuon.Size = new System.Drawing.Size(565, 76);
            this.grb_kiemtraphieumuon.TabIndex = 13;
            this.grb_kiemtraphieumuon.TabStop = false;
            this.grb_kiemtraphieumuon.Text = "Kiểm tra lịch sử mượn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Mã thẻ:";
            // 
            // txt_kiemtraphieumuon
            // 
            this.txt_kiemtraphieumuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_kiemtraphieumuon.Location = new System.Drawing.Point(176, 40);
            this.txt_kiemtraphieumuon.Name = "txt_kiemtraphieumuon";
            this.txt_kiemtraphieumuon.Size = new System.Drawing.Size(238, 27);
            this.txt_kiemtraphieumuon.TabIndex = 0;
            this.txt_kiemtraphieumuon.TextChanged += new System.EventHandler(this.txt_kiemtraphieumuon_TextChanged);
            // 
            // grb_kiemtrathedocgia
            // 
            this.grb_kiemtrathedocgia.Controls.Add(this.label7);
            this.grb_kiemtrathedocgia.Controls.Add(this.txt_thedocgia);
            this.grb_kiemtrathedocgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_kiemtrathedocgia.Location = new System.Drawing.Point(3, 2);
            this.grb_kiemtrathedocgia.Name = "grb_kiemtrathedocgia";
            this.grb_kiemtrathedocgia.Size = new System.Drawing.Size(565, 86);
            this.grb_kiemtrathedocgia.TabIndex = 14;
            this.grb_kiemtrathedocgia.TabStop = false;
            this.grb_kiemtrathedocgia.Text = "Kiểm tra thẻ độc giả";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Thẻ độc giả:";
            // 
            // txt_thedocgia
            // 
            this.txt_thedocgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_thedocgia.Location = new System.Drawing.Point(176, 46);
            this.txt_thedocgia.Name = "txt_thedocgia";
            this.txt_thedocgia.Size = new System.Drawing.Size(238, 27);
            this.txt_thedocgia.TabIndex = 0;
            this.txt_thedocgia.TextChanged += new System.EventHandler(this.txt_thedocgia_TextChanged);
            // 
            // grb_ttpm
            // 
            this.grb_ttpm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grb_ttpm.Controls.Add(this.btn_xoa);
            this.grb_ttpm.Controls.Add(this.checklb_sach);
            this.grb_ttpm.Controls.Add(this.btn_lapphieumuon);
            this.grb_ttpm.Controls.Add(this.dtp_Ngayhethan);
            this.grb_ttpm.Controls.Add(this.label2);
            this.grb_ttpm.Controls.Add(this.txt_Mathe);
            this.grb_ttpm.Controls.Add(this.txt_timkiemsach);
            this.grb_ttpm.Controls.Add(this.dgv_sach);
            this.grb_ttpm.Controls.Add(this.label3);
            this.grb_ttpm.Controls.Add(this.label4);
            this.grb_ttpm.Controls.Add(this.dtp_Ngaymuon);
            this.grb_ttpm.Controls.Add(this.label1);
            this.grb_ttpm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_ttpm.Location = new System.Drawing.Point(3, 198);
            this.grb_ttpm.Name = "grb_ttpm";
            this.grb_ttpm.Size = new System.Drawing.Size(565, 572);
            this.grb_ttpm.TabIndex = 12;
            this.grb_ttpm.TabStop = false;
            this.grb_ttpm.Text = "Thông tin phiếu mượn";
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(389, 382);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(116, 39);
            this.btn_xoa.TabIndex = 19;
            this.btn_xoa.Text = " Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // checklb_sach
            // 
            this.checklb_sach.FormattingEnabled = true;
            this.checklb_sach.Items.AddRange(new object[] {
            ""});
            this.checklb_sach.Location = new System.Drawing.Point(20, 382);
            this.checklb_sach.Name = "checklb_sach";
            this.checklb_sach.Size = new System.Drawing.Size(363, 180);
            this.checklb_sach.TabIndex = 17;
            // 
            // btn_lapphieumuon
            // 
            this.btn_lapphieumuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lapphieumuon.Location = new System.Drawing.Point(394, 502);
            this.btn_lapphieumuon.Name = "btn_lapphieumuon";
            this.btn_lapphieumuon.Size = new System.Drawing.Size(165, 60);
            this.btn_lapphieumuon.TabIndex = 16;
            this.btn_lapphieumuon.Text = "Lập phiếu mượn sách";
            this.btn_lapphieumuon.UseVisualStyleBackColor = true;
            this.btn_lapphieumuon.Click += new System.EventHandler(this.btn_lapphieumuon_Click);
            // 
            // dtp_Ngayhethan
            // 
            this.dtp_Ngayhethan.CustomFormat = "dd/MM/yyyy";
            this.dtp_Ngayhethan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Ngayhethan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Ngayhethan.Location = new System.Drawing.Point(233, 128);
            this.dtp_Ngayhethan.Name = "dtp_Ngayhethan";
            this.dtp_Ngayhethan.Size = new System.Drawing.Size(238, 27);
            this.dtp_Ngayhethan.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ngày hết hạn:";
            // 
            // txt_Mathe
            // 
            this.txt_Mathe.Location = new System.Drawing.Point(233, 46);
            this.txt_Mathe.Name = "txt_Mathe";
            this.txt_Mathe.Size = new System.Drawing.Size(116, 27);
            this.txt_Mathe.TabIndex = 9;
            // 
            // txt_timkiemsach
            // 
            this.txt_timkiemsach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timkiemsach.Location = new System.Drawing.Point(233, 193);
            this.txt_timkiemsach.Name = "txt_timkiemsach";
            this.txt_timkiemsach.Size = new System.Drawing.Size(238, 30);
            this.txt_timkiemsach.TabIndex = 9;
            this.txt_timkiemsach.TextChanged += new System.EventHandler(this.txt_timkiemsach_TextChanged);
            // 
            // dgv_sach
            // 
            this.dgv_sach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_sach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_sach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sach.Location = new System.Drawing.Point(6, 229);
            this.dgv_sach.Name = "dgv_sach";
            this.dgv_sach.RowHeadersWidth = 51;
            this.dgv_sach.RowTemplate.Height = 24;
            this.dgv_sach.Size = new System.Drawing.Size(553, 131);
            this.dgv_sach.TabIndex = 7;
            this.dgv_sach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sach_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mã thẻ độc giả:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(104, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tìm kiếm sách:";
            // 
            // dtp_Ngaymuon
            // 
            this.dtp_Ngaymuon.CustomFormat = "dd/MM/yyyy";
            this.dtp_Ngaymuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Ngaymuon.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_Ngaymuon.Location = new System.Drawing.Point(233, 89);
            this.dtp_Ngaymuon.Name = "dtp_Ngaymuon";
            this.dtp_Ngaymuon.Size = new System.Drawing.Size(238, 27);
            this.dtp_Ngaymuon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày mượn:";
            // 
            // Muonsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1351, 782);
            this.Controls.Add(this.lbl_thedocgia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtg_phieumuon);
            this.Controls.Add(this.dtg_thedocgia);
            this.Controls.Add(this.grb_kiemtraphieumuon);
            this.Controls.Add(this.grb_kiemtrathedocgia);
            this.Controls.Add(this.grb_ttpm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Muonsach";
            this.Text = "Muonsach";
            this.Load += new System.EventHandler(this.Muonsach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_phieumuon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_thedocgia)).EndInit();
            this.grb_kiemtraphieumuon.ResumeLayout(false);
            this.grb_kiemtraphieumuon.PerformLayout();
            this.grb_kiemtrathedocgia.ResumeLayout(false);
            this.grb_kiemtrathedocgia.PerformLayout();
            this.grb_ttpm.ResumeLayout(false);
            this.grb_ttpm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_thedocgia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtg_phieumuon;
        private System.Windows.Forms.DataGridView dtg_thedocgia;
        private System.Windows.Forms.GroupBox grb_kiemtraphieumuon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_kiemtraphieumuon;
        private System.Windows.Forms.GroupBox grb_kiemtrathedocgia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_thedocgia;
        private System.Windows.Forms.GroupBox grb_ttpm;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.CheckedListBox checklb_sach;
        private System.Windows.Forms.Button btn_lapphieumuon;
        private System.Windows.Forms.DateTimePicker dtp_Ngayhethan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_timkiemsach;
        private System.Windows.Forms.DataGridView dgv_sach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_Ngaymuon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Mathe;
        private System.Windows.Forms.Label label3;
    }
}