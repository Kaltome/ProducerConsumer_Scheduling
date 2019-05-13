namespace ProducerandConsumer
{
    partial class StartForm
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
            this.ProducerComboBox = new System.Windows.Forms.ComboBox();
            this.ConsumerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.BufferPoolBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProducerComboBox
            // 
            this.ProducerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProducerComboBox.FormattingEnabled = true;
            this.ProducerComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.ProducerComboBox.Location = new System.Drawing.Point(204, 170);
            this.ProducerComboBox.Name = "ProducerComboBox";
            this.ProducerComboBox.Size = new System.Drawing.Size(58, 20);
            this.ProducerComboBox.TabIndex = 0;
            this.ProducerComboBox.SelectedIndexChanged += new System.EventHandler(this.ProducerComboBox_SelectedIndexChanged);
            // 
            // ConsumerComboBox
            // 
            this.ConsumerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConsumerComboBox.FormattingEnabled = true;
            this.ConsumerComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.ConsumerComboBox.Location = new System.Drawing.Point(204, 214);
            this.ConsumerComboBox.Name = "ConsumerComboBox";
            this.ConsumerComboBox.Size = new System.Drawing.Size(58, 20);
            this.ConsumerComboBox.TabIndex = 1;
            this.ConsumerComboBox.SelectedIndexChanged += new System.EventHandler(this.ConsumerComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "生产者数目";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "消费者数目";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(154, 280);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "开始";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "缓冲池大小";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.Title.Location = new System.Drawing.Point(95, 48);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(199, 30);
            this.Title.TabIndex = 4;
            this.Title.Text = "生产者-消费者调度";
            // 
            // BufferPoolBox
            // 
            this.BufferPoolBox.Location = new System.Drawing.Point(204, 124);
            this.BufferPoolBox.Name = "BufferPoolBox";
            this.BufferPoolBox.Size = new System.Drawing.Size(58, 21);
            this.BufferPoolBox.TabIndex = 5;
            this.BufferPoolBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.BufferPoolBox.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "(3 - 20)";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.BufferPoolBox);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConsumerComboBox);
            this.Controls.Add(this.ProducerComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据选择";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProducerComboBox;
        private System.Windows.Forms.ComboBox ConsumerComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox BufferPoolBox;
        private System.Windows.Forms.Label label4;
    }
}