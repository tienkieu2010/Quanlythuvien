namespace Login
{
    partial class Thongke
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtgv_Thongke = new System.Windows.Forms.DataGridView();
            this.btn_Thongke = new System.Windows.Forms.Button();
            this.dtpk_Denngay = new System.Windows.Forms.DateTimePicker();
            this.dtpk_Tungay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Thongke = new System.Windows.Forms.ComboBox();
            this.chart_Doanhthu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Thongke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Doanhthu)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgv_Thongke
            // 
            this.dtgv_Thongke.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_Thongke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgv_Thongke.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv_Thongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_Thongke.Location = new System.Drawing.Point(18, 13);
            this.dtgv_Thongke.Name = "dtgv_Thongke";
            this.dtgv_Thongke.RowHeadersWidth = 51;
            this.dtgv_Thongke.RowTemplate.Height = 24;
            this.dtgv_Thongke.Size = new System.Drawing.Size(801, 644);
            this.dtgv_Thongke.TabIndex = 37;
            this.dtgv_Thongke.Visible = false;
            this.dtgv_Thongke.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_Thongke_CellContentClick);
            // 
            // btn_Thongke
            // 
            this.btn_Thongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thongke.Location = new System.Drawing.Point(189, 518);
            this.btn_Thongke.Name = "btn_Thongke";
            this.btn_Thongke.Size = new System.Drawing.Size(139, 46);
            this.btn_Thongke.TabIndex = 36;
            this.btn_Thongke.Text = "Thống kê";
            this.btn_Thongke.UseVisualStyleBackColor = true;
            this.btn_Thongke.Click += new System.EventHandler(this.btn_Thongke_Click);
            // 
            // dtpk_Denngay
            // 
            this.dtpk_Denngay.CustomFormat = "dd-MM-yyyy";
            this.dtpk_Denngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_Denngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_Denngay.Location = new System.Drawing.Point(229, 448);
            this.dtpk_Denngay.Name = "dtpk_Denngay";
            this.dtpk_Denngay.Size = new System.Drawing.Size(222, 30);
            this.dtpk_Denngay.TabIndex = 34;
            this.dtpk_Denngay.ValueChanged += new System.EventHandler(this.dtpk_Denngay_ValueChanged);
            // 
            // dtpk_Tungay
            // 
            this.dtpk_Tungay.CustomFormat = "dd-MM-yyyy";
            this.dtpk_Tungay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpk_Tungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpk_Tungay.Location = new System.Drawing.Point(229, 389);
            this.dtpk_Tungay.Name = "dtpk_Tungay";
            this.dtpk_Tungay.Size = new System.Drawing.Size(222, 30);
            this.dtpk_Tungay.TabIndex = 35;
            this.dtpk_Tungay.ValueChanged += new System.EventHandler(this.dtpk_Tungay_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(109, 454);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 25);
            this.label6.TabIndex = 30;
            this.label6.Text = "Đến ngày:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(109, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 31;
            this.label5.Text = "Từ ngày:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(109, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 25);
            this.label4.TabIndex = 32;
            this.label4.Text = "Chọn thời gian cần thống kê:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(109, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "Chọn loại thống kê:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 32);
            this.label1.TabIndex = 29;
            this.label1.Text = "Quản lý thống kê:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbx_Thongke
            // 
            this.cbx_Thongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Thongke.FormattingEnabled = true;
            this.cbx_Thongke.Items.AddRange(new object[] {
            "Thống kế sách đã mượn",
            "Thống kê sách được mượn nhiều nhất ",
            "Thống kê sách được mượn ít nhất",
            "Thống kê sách trễ hạn",
            "Thống kê người mượn nhiều nhất",
            "Thống kê doanh thu"});
            this.cbx_Thongke.Location = new System.Drawing.Point(113, 211);
            this.cbx_Thongke.Name = "cbx_Thongke";
            this.cbx_Thongke.Size = new System.Drawing.Size(338, 33);
            this.cbx_Thongke.TabIndex = 28;
            this.cbx_Thongke.SelectedIndexChanged += new System.EventHandler(this.cbx_Thongke_SelectedIndexChanged);
            // 
            // chart_Doanhthu
            // 
            this.chart_Doanhthu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_Doanhthu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_Doanhthu.Legends.Add(legend1);
            this.chart_Doanhthu.Location = new System.Drawing.Point(18, 13);
            this.chart_Doanhthu.Name = "chart_Doanhthu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_Doanhthu.Series.Add(series1);
            this.chart_Doanhthu.Size = new System.Drawing.Size(801, 644);
            this.chart_Doanhthu.TabIndex = 38;
            this.chart_Doanhthu.Text = "chart1";
            this.chart_Doanhthu.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.chart_Doanhthu);
            this.panel1.Controls.Add(this.dtgv_Thongke);
            this.panel1.Location = new System.Drawing.Point(491, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 673);
            this.panel1.TabIndex = 39;
            // 
            // Thongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 782);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Thongke);
            this.Controls.Add(this.dtpk_Denngay);
            this.Controls.Add(this.dtpk_Tungay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_Thongke);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Thongke";
            this.Text = "Thongke";
            this.Load += new System.EventHandler(this.Thongke_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_Thongke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Doanhthu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_Thongke;
        private System.Windows.Forms.Button btn_Thongke;
        private System.Windows.Forms.DateTimePicker dtpk_Denngay;
        private System.Windows.Forms.DateTimePicker dtpk_Tungay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Thongke;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Doanhthu;
        private System.Windows.Forms.Panel panel1;
    }
}