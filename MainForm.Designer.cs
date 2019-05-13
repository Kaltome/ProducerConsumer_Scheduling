using System.Threading;


namespace ProducerandConsumer
{
    partial class MainForm
    {

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;



        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.p_comboBox = new System.Windows.Forms.ComboBox();
            this.p_dataTextBox = new System.Windows.Forms.TextBox();
            this.p_starttimeTextBox = new System.Windows.Forms.TextBox();
            this.c_comboBox = new System.Windows.Forms.ComboBox();
            this.c_starttimeTextBox = new System.Windows.Forms.TextBox();
            this.addProducerButton = new System.Windows.Forms.Button();
            this.addConsumerButton = new System.Windows.Forms.Button();
            this.randomTextBox = new System.Windows.Forms.TextBox();
            this.ListTextBox = new System.Windows.Forms.TextBox();
            this.cleanListButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.cleanMessageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.createRandomList = new System.Windows.Forms.Button();
            this.startRuningButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.randomCheckBox = new System.Windows.Forms.CheckBox();
            this.cleanBufferpoolButtom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // p_comboBox
            // 
            this.p_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.p_comboBox.Location = new System.Drawing.Point(735, 440);
            this.p_comboBox.Name = "p_comboBox";
            this.p_comboBox.Size = new System.Drawing.Size(40, 20);
            this.p_comboBox.TabIndex = 3;
            this.p_comboBox.SelectedIndexChanged += new System.EventHandler(this.p_comboBox_SelectedIndexChanged);
            // 
            // p_dataTextBox
            // 
            this.p_dataTextBox.Location = new System.Drawing.Point(845, 440);
            this.p_dataTextBox.MaxLength = 3;
            this.p_dataTextBox.Multiline = true;
            this.p_dataTextBox.Name = "p_dataTextBox";
            this.p_dataTextBox.Size = new System.Drawing.Size(35, 20);
            this.p_dataTextBox.TabIndex = 4;
            this.p_dataTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.p_dataTextBox_Validating);
            // 
            // p_starttimeTextBox
            // 
            this.p_starttimeTextBox.Location = new System.Drawing.Point(785, 440);
            this.p_starttimeTextBox.MaxLength = 5;
            this.p_starttimeTextBox.Multiline = true;
            this.p_starttimeTextBox.Name = "p_starttimeTextBox";
            this.p_starttimeTextBox.Size = new System.Drawing.Size(50, 20);
            this.p_starttimeTextBox.TabIndex = 4;
            this.p_starttimeTextBox.Validated += new System.EventHandler(this.p_starttimeTextBox_Validated);
            // 
            // c_comboBox
            // 
            this.c_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c_comboBox.Location = new System.Drawing.Point(735, 465);
            this.c_comboBox.Name = "c_comboBox";
            this.c_comboBox.Size = new System.Drawing.Size(40, 20);
            this.c_comboBox.TabIndex = 3;
            this.c_comboBox.SelectedIndexChanged += new System.EventHandler(this.c_comboBox_SelectedIndexChanged);
            // 
            // c_starttimeTextBox
            // 
            this.c_starttimeTextBox.Location = new System.Drawing.Point(785, 465);
            this.c_starttimeTextBox.MaxLength = 5;
            this.c_starttimeTextBox.Multiline = true;
            this.c_starttimeTextBox.Name = "c_starttimeTextBox";
            this.c_starttimeTextBox.Size = new System.Drawing.Size(50, 20);
            this.c_starttimeTextBox.TabIndex = 4;
            this.c_starttimeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.c_starttimeTextBox_Validating);
            // 
            // addProducerButton
            // 
            this.addProducerButton.Location = new System.Drawing.Point(890, 440);
            this.addProducerButton.Name = "addProducerButton";
            this.addProducerButton.Size = new System.Drawing.Size(20, 20);
            this.addProducerButton.TabIndex = 5;
            this.addProducerButton.Text = "+";
            this.addProducerButton.UseVisualStyleBackColor = true;
            this.addProducerButton.Click += new System.EventHandler(this.addProducerButton_Click);
            // 
            // addConsumerButton
            // 
            this.addConsumerButton.Location = new System.Drawing.Point(890, 465);
            this.addConsumerButton.Name = "addConsumerButton";
            this.addConsumerButton.Size = new System.Drawing.Size(20, 20);
            this.addConsumerButton.TabIndex = 5;
            this.addConsumerButton.Text = "+";
            this.addConsumerButton.UseVisualStyleBackColor = true;
            this.addConsumerButton.Click += new System.EventHandler(this.addConsumerButton_Click);
            // 
            // randomTextBox
            // 
            this.randomTextBox.Location = new System.Drawing.Point(735, 515);
            this.randomTextBox.Multiline = true;
            this.randomTextBox.Name = "randomTextBox";
            this.randomTextBox.Size = new System.Drawing.Size(40, 20);
            this.randomTextBox.TabIndex = 4;
            this.randomTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.randomTextBox_Validating);
            // 
            // ListTextBox
            // 
            this.ListTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ListTextBox.Font = new System.Drawing.Font("宋体", 10F);
            this.ListTextBox.Location = new System.Drawing.Point(515, 440);
            this.ListTextBox.Multiline = true;
            this.ListTextBox.Name = "ListTextBox";
            this.ListTextBox.ReadOnly = true;
            this.ListTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ListTextBox.Size = new System.Drawing.Size(200, 200);
            this.ListTextBox.TabIndex = 4;
            // 
            // cleanListButton
            // 
            this.cleanListButton.Location = new System.Drawing.Point(655, 650);
            this.cleanListButton.Name = "cleanListButton";
            this.cleanListButton.Size = new System.Drawing.Size(60, 23);
            this.cleanListButton.TabIndex = 6;
            this.cleanListButton.Text = "清空";
            this.cleanListButton.UseVisualStyleBackColor = true;
            this.cleanListButton.Click += new System.EventHandler(this.cleanListButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.BackColor = System.Drawing.Color.White;
            this.messageTextBox.Font = new System.Drawing.Font("宋体", 10F);
            this.messageTextBox.Location = new System.Drawing.Point(25, 440);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ReadOnly = true;
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.messageTextBox.Size = new System.Drawing.Size(420, 200);
            this.messageTextBox.TabIndex = 4;
            // 
            // cleanMessageButton
            // 
            this.cleanMessageButton.Location = new System.Drawing.Point(385, 650);
            this.cleanMessageButton.Name = "cleanMessageButton";
            this.cleanMessageButton.Size = new System.Drawing.Size(60, 23);
            this.cleanMessageButton.TabIndex = 6;
            this.cleanMessageButton.Text = "清空";
            this.cleanMessageButton.UseVisualStyleBackColor = true;
            this.cleanMessageButton.Click += new System.EventHandler(this.cleanMessageButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(910, 443);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "添加生产者";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(910, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "添加消费者";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(739, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "编号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(793, 415);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(847, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "数据";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(783, 518);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "随机序列(1 - 20)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(18, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(352, 42);
            this.label11.TabIndex = 9;
            this.label11.Text = "生产者-消费者调度示例";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(21, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 22);
            this.label12.TabIndex = 9;
            this.label12.Text = "缓冲池：";
            // 
            // createRandomList
            // 
            this.createRandomList.Location = new System.Drawing.Point(735, 545);
            this.createRandomList.Name = "createRandomList";
            this.createRandomList.Size = new System.Drawing.Size(90, 25);
            this.createRandomList.TabIndex = 10;
            this.createRandomList.Text = "生成随机序列";
            this.createRandomList.UseVisualStyleBackColor = true;
            this.createRandomList.Click += new System.EventHandler(this.createRandomList_Click);
            // 
            // startRuningButton
            // 
            this.startRuningButton.Font = new System.Drawing.Font("宋体", 10F);
            this.startRuningButton.Location = new System.Drawing.Point(735, 600);
            this.startRuningButton.Name = "startRuningButton";
            this.startRuningButton.Size = new System.Drawing.Size(120, 40);
            this.startRuningButton.TabIndex = 10;
            this.startRuningButton.Text = "开始运行";
            this.startRuningButton.UseVisualStyleBackColor = true;
            this.startRuningButton.Click += new System.EventHandler(this.startRuningButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(21, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(125, 22);
            this.label13.TabIndex = 9;
            this.label13.Text = "运行信息：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(511, 400);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(125, 22);
            this.label14.TabIndex = 9;
            this.label14.Text = "调度列表：";
            // 
            // randomCheckBox
            // 
            this.randomCheckBox.AutoSize = true;
            this.randomCheckBox.Location = new System.Drawing.Point(890, 517);
            this.randomCheckBox.Name = "randomCheckBox";
            this.randomCheckBox.Size = new System.Drawing.Size(96, 16);
            this.randomCheckBox.TabIndex = 11;
            this.randomCheckBox.Text = "生成概率相同";
            this.randomCheckBox.UseVisualStyleBackColor = true;
            // 
            // cleanBufferpoolButtom
            // 
            this.cleanBufferpoolButtom.Location = new System.Drawing.Point(130, 130);
            this.cleanBufferpoolButtom.Name = "cleanBufferpoolButtom";
            this.cleanBufferpoolButtom.Size = new System.Drawing.Size(100, 30);
            this.cleanBufferpoolButtom.TabIndex = 13;
            this.cleanBufferpoolButtom.Text = "清空缓冲池";
            this.cleanBufferpoolButtom.UseVisualStyleBackColor = true;
            this.cleanBufferpoolButtom.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.cleanBufferpoolButtom);
            this.Controls.Add(this.randomCheckBox);
            this.Controls.Add(this.startRuningButton);
            this.Controls.Add(this.createRandomList);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cleanMessageButton);
            this.Controls.Add(this.cleanListButton);
            this.Controls.Add(this.addConsumerButton);
            this.Controls.Add(this.addProducerButton);
            this.Controls.Add(this.c_starttimeTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.ListTextBox);
            this.Controls.Add(this.p_starttimeTextBox);
            this.Controls.Add(this.randomTextBox);
            this.Controls.Add(this.p_dataTextBox);
            this.Controls.Add(this.c_comboBox);
            this.Controls.Add(this.p_comboBox);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "生产者-消费者事件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.ComboBox p_comboBox;
        private System.Windows.Forms.TextBox p_dataTextBox;
        private System.Windows.Forms.TextBox p_starttimeTextBox;
        private System.Windows.Forms.ComboBox c_comboBox;
        private System.Windows.Forms.TextBox c_starttimeTextBox;
        private System.Windows.Forms.Button addProducerButton;
        private System.Windows.Forms.Button addConsumerButton;
        private System.Windows.Forms.TextBox randomTextBox;
        private System.Windows.Forms.TextBox ListTextBox;
        private System.Windows.Forms.Button cleanListButton;
        private System.Windows.Forms.Button cleanMessageButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button createRandomList;
        private System.Windows.Forms.Button startRuningButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox randomCheckBox;
        private System.Windows.Forms.Button cleanBufferpoolButtom;
    }


}

