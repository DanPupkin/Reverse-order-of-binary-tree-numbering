namespace order_of_binary_tree_numbering
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.draw_button = new System.Windows.Forms.Button();
            this.Nodes_connection_switch = new System.Windows.Forms.CheckBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 680, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Пронумеровать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(630, 346);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 502);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(692, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.draw_button);
            this.flowLayoutPanel1.Controls.Add(this.Nodes_connection_switch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 599);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 500, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1262, 74);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(312, 3);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(134, 34);
            this.draw_button.TabIndex = 7;
            this.draw_button.Text = "отрисовать";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Visible = false;
            // 
            // Nodes_connection_switch
            // 
            this.Nodes_connection_switch.AutoSize = true;
            this.Nodes_connection_switch.Location = new System.Drawing.Point(132, 3);
            this.Nodes_connection_switch.Name = "Nodes_connection_switch";
            this.Nodes_connection_switch.Size = new System.Drawing.Size(174, 24);
            this.Nodes_connection_switch.TabIndex = 8;
            this.Nodes_connection_switch.Text = "Соеденять вершины";
            this.Nodes_connection_switch.UseVisualStyleBackColor = true;
            // 
            // Table
            // 
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(630, 27);
            this.Table.Name = "Table";
            this.Table.RowHeadersWidth = 51;
            this.Table.RowTemplate.Height = 29;
            this.Table.Size = new System.Drawing.Size(583, 303);
            this.Table.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Form1";
            this.Text = "Обход в ширину";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Panel panel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox Nodes_connection_switch;
        private Button draw_button;
        private DataGridView Table;
    }
}