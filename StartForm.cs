using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProducerandConsumer
{
    public partial class StartForm : Form
    {
        private int producernum;
        private int consumernum;
        private int bufferpoolsize;
        private bool Issetproducer = false;
        private bool Issetconsumer = false;
        private bool Issetbufferpool = false;


        public StartForm()
        {
            InitializeComponent();
        }


        //缓冲池大小输入框 ---------------------------------------------------------------
        private void textBox1_Validated(object sender, EventArgs e)
        {
            check();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                check();
            }
        }
        private void check()
        {
            int value;
            if (int.TryParse(BufferPoolBox.Text, out value) && value > 2 && value < 21)
            {
                bufferpoolsize = value;
                Issetbufferpool = true;
            }
            else
            {
                MessageBox.Show("需要填入3~20之间的数字", "提示");
                BufferPoolBox.Text = string.Empty;
            }
        }


        //生产者消费者数目选择框 ---------------------------------------------------------
        private void ProducerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            producernum = int.Parse(ProducerComboBox.Text);
            Issetproducer = true;
        }
        private void ConsumerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            consumernum = int.Parse(ConsumerComboBox.Text);
            Issetconsumer = true;
        }


        //开始按钮 --------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (Issetconsumer && Issetproducer && Issetbufferpool)
            {
                Hide();
                MainForm mainForm = new MainForm(producernum, consumernum, bufferpoolsize);
                mainForm.ShowDialog();

                Close();
            }
            else MessageBox.Show("数据未完全设置", "提示");
        }


        //杂技 -----------------------------------------------------------------------
        /*
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;



            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                return;
            }
            base.WndProc(ref m);
        }
//--------------------- 
//作者：Jimmy-G
//来源：CSDN
//原文：https://blog.csdn.net/bestgonghuibin/article/details/9021573 
//版权声明：本文为博主原创文章，转载请附上博文链接！*/
    }
}
