using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace ProducerandConsumer
{



    public partial class MainForm : Form
    {



        /// <summary> 进程调度函数
        /// </summary>
        private void processRun()
        {
            //初始化数据（进程实际开始运行时间和已完成进程数）
            runtime = 0;
            runconsumernum = 0;
            runproducernum = 0;
            finishproducernum = 0;
            finishconsumernum = 0;
            finishthreadnum = 0;

            //统计该次运行生产者总数和消费者总数
            for (int i = 0; i < processlistsize; i++)
            {
                if (processlist[i].status) runconsumernum++;
                else runproducernum++;
            }

            //调用进程
            int time = 0;
            for (int i = 0; i < processlistsize; i++)
            {
                MyProcess thisProcess = processlist[i];
                Thread.Sleep(thisProcess.starttime - time);

                int no = thisProcess.no;

                //判断是生产者还是消费者
                if (thisProcess.status == false)
                {
                    //该进程未被调用，直接启动
                    if (producer[no] == null || producer[no].IsAlive == false)
                    {
                        producersemaphore[no].WaitOne();
                        producer[no] = new Thread(thisProcess.Produce);
                        producer[no].Start();
                    }
                    //该进程正在调用中，建立新线程托管启动
                    else
                    {
                        Thread checkthread = new Thread(new ParameterizedThreadStart(producerRecall));
                        checkthread.Start(thisProcess);
                    }
                }
                else
                {
                    //该进程未被调用，直接启动
                    if (consumer[no] == null || consumer[no].IsAlive == false)
                    {
                        consumersemaphore[no].WaitOne();
                        consumer[no] = new Thread(thisProcess.Consume);
                        consumer[no].Start();
                    }
                    //该进程正在调用中，建立新线程托管启动
                    else
                    {
                        Thread checkthread = new Thread(new ParameterizedThreadStart(consumerRecall));
                        checkthread.Start(thisProcess);
                    }
                }
                time = thisProcess.starttime;
            }

            while (finishthreadnum != runconsumernum + runproducernum) Thread.Sleep(10);

            isruning = false;
        }


        /// <summary> 等待再次调用正在运行的生产者
        /// </summary>
        private void producerRecall(object t)
        {
            MyProcess p = t as MyProcess;
            int no = p.no;
            mainform.producersemaphore[no].WaitOne();

            producer[no] = new Thread(p.Produce);
            producer[no].Start();

        }

        /// <summary> 等待再次调用正在运行的消费者
        /// </summary>
        private void consumerRecall(object t)
        {
            MyProcess p = t as MyProcess;
            int no = p.no;
            mainform.consumersemaphore[no].WaitOne();

            consumer[no] = new Thread(p.Consume);
            consumer[no].Start();

        }







        /// <summary> 进程信息及执行函数类
        /// </summary>
        public class MyProcess
        {
            public MyProcess() { }
            public MyProcess(bool st, int n, int stt, string d = "")
            {
                status = st;
                no = n;
                starttime = stt;
                data = d;
            }



            /// <summary> 生产者运行函数
            /// </summary>
            public void Produce()
            {
                //申请缓冲池空间信号量(如果缓冲池满且消费者已全部执行完毕，跳出等待)
                while ((!mainform.bufferpool.useEmptynum(1)) && mainform.finishconsumernum != mainform.runconsumernum) continue;

                //申请缓冲池使用信号量
                mainform.mainsemaphore.WaitOne();

                //获取真实开始运行时间
                Thread.Sleep(650);
                if (mainform.runtime <= starttime) mainform.runtime = starttime;
                int time = mainform.runtime;
                mainform.runtime += 650;


                //若缓冲池非满则执行写，否则发出无法写入信息
                if (!(mainform.bufferpool.useFillnum(0)))
                {
                    mainform.bufferpool.Write(data);

                    Action<string> actionDelegate = (x) => { mainform.messageTextBox.AppendText(x); };
                    mainform.messageTextBox.Invoke(actionDelegate,"生产者" + (no + 1).ToString() + " 写入数据：" + data + " 开始运行时间：" + time.ToString() + "ms\r\n" );
                }
                else
                {
                    Action<string> actionDelegate = (x) => { mainform.messageTextBox.AppendText(x); };
                    mainform.messageTextBox.Invoke(actionDelegate, "缓冲池已满，" + "生产者" + (no + 1).ToString() + " 无法写入数据："+ data + " 开始运行时间：" + time.ToString() + "ms\r\n");
                }
                

                //释放信号，增加已执行进程数和生产者进程数
                mainform.mainsemaphore.Release();
                mainform.bufferpool.useFillnum(2);
                mainform.finishthreadnum++;
                mainform.finishproducernum++;
                mainform.producersemaphore[no].Release();
            }



            /// <summary> 消费者执行函数
            /// </summary>
            public void Consume()
            {
                //申请缓冲池空间信号量(如果缓冲池空且生产已全部执行完毕，跳出等待)
                while ((!mainform.bufferpool.useFillnum(1)) && mainform.finishproducernum != mainform.runproducernum) continue;

                //申请缓冲池正在使用信号量
                mainform.mainsemaphore.WaitOne();

                //获取真实开始运行时间
                Thread.Sleep(350);
                if (mainform.runtime <= starttime) mainform.runtime = starttime;
                int time = mainform.runtime;
                mainform.runtime += 350;


                //若缓冲池非空则执行读，否则发出无法读取信息
                if (!(mainform.bufferpool.useEmptynum(0)))
                {
                    mainform.bufferpool.Read(ref data);

                    Action<string> actionDelegate = (x) => { mainform.messageTextBox.AppendText(x); };
                    mainform.messageTextBox.Invoke(actionDelegate, "消费者" + (no + 1).ToString() + " 读取数据：" + data + " 开始运行时间：" + time.ToString() + "ms\r\n");
                }
                else
                {
                    Action<string> actionDelegate = (x) => { mainform.messageTextBox.AppendText(x); };
                    mainform.messageTextBox.Invoke(actionDelegate, "缓冲池为空，" + "消费者" + (no + 1).ToString() + " 无法读取数据" + " 开始运行时间：" + time.ToString() + "ms\r\n");
                }
                

                //释放信号，增加已执行进程数和消费者进程数
                mainform.mainsemaphore.Release();
                mainform.bufferpool.useEmptynum(2);
                mainform.finishconsumernum++;
                mainform.finishthreadnum++;
                mainform.consumersemaphore[no].Release();
            }


            
            public bool status; 
            public int no;
            public int starttime;
            public string data;
        }



        
        /// <summary> 存储将要执行的进程的序列类
        /// </summary>
        public class Processlist
        {
            public Processlist() { }
            public MyProcess this[int i]
            {
                get
                {
                    return list[i];
                }
            }

            /// <summary> 添加进程
            /// </summary>
            public bool Add(MyProcess myp)
            {
                if (size == maxsize) return false;
                list[size] = myp;
                size++;
                return true;
            }
            
            /// <summary> 清除所有进程
            /// </summary>
            public void Clean()
            {
                list = new MyProcess[maxsize];
                size = 0;
            }
            
            /// <summary> 进程序列实际大小
            /// </summary>
            private int size;
            private const int maxsize = 20;
            private MyProcess[] list = new MyProcess[maxsize];
        }







        /// <summary> 缓冲池
        /// </summary>
        public class Bufferpool
        {
            public Bufferpool()
            {
                box = new TextBox[size];
                emptynum = size;
                p_pointerpos = size - 1;

                Setbufferpool();
            }
            public Bufferpool(int s)
            {
                size = s;
                emptynum = size;
                box = new TextBox[size];
                Setbufferpool();
            }
            public TextBox this[int i]
            {
                get
                {
                    return box[i];
                }
            }



            /// <summary> 添加缓冲池控件
            /// </summary>
            private void Setbufferpool()
            {
                this.consumerPointer = new System.Windows.Forms.Panel();
                this.producerPointer = new System.Windows.Forms.Panel();
                this.label8 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.label10 = new System.Windows.Forms.Label();
                // 
                // bufferpool
                // 
                int bufferboxsize = pointerwidth - 5;
                for (int i = 0; i < size; i++)
                {

                    box[i] = new System.Windows.Forms.TextBox();
                    box[i].Text = "?";
                    box[i].TabIndex = 1 + i;
                    box[i].Multiline = true;
                    box[i].ReadOnly = true;
                    box[i].BackColor = Color.White;
                    box[i].Name = "bufferbox_" + i.ToString();
                    box[i].Font = new System.Drawing.Font("宋体", 10F);
                    box[i].TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                    box[i].Size = new System.Drawing.Size(bufferboxsize, bufferboxsize);
                    box[i].Location = new System.Drawing.Point(25 + i * bufferboxsize + i * 5, 240);
                }
                // 
                // consumerPointer
                // 
                this.consumerPointer.Controls.Add(this.label8);
                this.consumerPointer.Controls.Add(this.label7);
                this.consumerPointer.Location = new System.Drawing.Point(19, 280);
                this.consumerPointer.Name = "consumerPointer";
                this.consumerPointer.Size = new System.Drawing.Size(92, 61);
                this.consumerPointer.TabIndex = 0;
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
                this.label8.Location = new System.Drawing.Point(15, 3);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(24, 30);
                this.label8.TabIndex = 0;
                this.label8.Text = "↑";
                // 
                // label7
                // 
                this.label7.AutoSize = true;
                this.label7.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
                this.label7.Location = new System.Drawing.Point(3, 35);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(84, 19);
                this.label7.TabIndex = 0;
                this.label7.Text = "消费者指针";
                // 
                // producerPointer
                // 
                this.producerPointer.Controls.Add(this.label9);
                this.producerPointer.Controls.Add(this.label10);
                this.producerPointer.Location = new System.Drawing.Point(19, 180);
                this.producerPointer.Name = "producerPointer";
                this.producerPointer.Size = new System.Drawing.Size(92, 56);
                this.producerPointer.TabIndex = 0;
                // 
                // label9
                // 
                this.label9.AutoSize = true;
                this.label9.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
                this.label9.Location = new System.Drawing.Point(15, 23);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(24, 30);
                this.label9.TabIndex = 0;
                this.label9.Text = "↓";
                // 
                // label10
                // 
                this.label10.AutoSize = true;
                this.label10.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
                this.label10.Location = new System.Drawing.Point(4, 4);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(84, 19);
                this.label10.TabIndex = 0;
                this.label10.Text = "生产者指针";

                this.consumerPointer.SuspendLayout();
                this.producerPointer.SuspendLayout();
                this.consumerPointer.ResumeLayout(false);
                this.consumerPointer.PerformLayout();
                this.producerPointer.ResumeLayout(false);
                this.producerPointer.PerformLayout();
            }
            

            
            /// <summary> 生产者写入缓冲池
            /// </summary>
            public void Write(string s)
            {
                    Action<string> actionDelegate = (x) => { box[p_pointerpos].Text = s; };
                    box[p_pointerpos].Invoke(actionDelegate, "");

                    movep_pointer();
            }
            /// <summary> 消费者读取缓冲池
            /// </summary>
            public void Read(ref string s)
            {
                    string p = "";
                    Action<string> actionDelegate = (x) => {
                        p = box[c_pointerpos].Text;
                        box[c_pointerpos].Text = "?";
                    };
                    box[c_pointerpos].Invoke(actionDelegate, " ");
                    s = p;

                    movec_pointer();
            }
            


            /// <summary> 移动生产者指针
            /// </summary>
            public void movep_pointer()
            {
                p_pointerpos = (p_pointerpos + 1) % size;
                Action<string> actionDelegate = (x) => { producerPointer.Location = new Point(19 + p_pointerpos * pointerwidth, 180); };
                producerPointer.Invoke(actionDelegate, "");
            }

            /// <summary> 移动消费者指针
            /// </summary>
            public void movec_pointer()
            {
                c_pointerpos = (c_pointerpos + 1) % size;
                Action<string> actionDelegate = (x) => { consumerPointer.Location = new Point(19 + c_pointerpos * pointerwidth, 280); };
                consumerPointer.Invoke(actionDelegate, "");
            }



            /// <summary> 初始化缓冲池
            /// </summary>
            public void cleanbufferpool()
            {
                fillnum = 0;
                emptynum = size;
                for(int i = 0; i < size; i++)
                {
                    box[i].Text = "?";
                }
                producerPointer.Location = new Point(19, 180);
                consumerPointer.Location = new Point(19, 280);
                p_pointerpos = 0;
                c_pointerpos = 0;
            }



            /// <summary>
            /// 封装访问参数emptynum函数，保证每次只有一个进程访问。 
            /// get == 0 判断空；get == 1 获取信号量； get == 2 释放信号量；
            /// </summary>
            public bool useEmptynum(int get)
            {
                lock (this)
                {
                    if (get == 1)
                    {
                        if (emptynum == 0) return false;
                        emptynum--;
                        return true;
                    }
                    else if(get == 2)
                    {
                        if (emptynum != size)
                        {
                            emptynum++;
                        }
                        return true;
                    }
                    else
                    {
                        return emptynum == size ? true : false;
                    }
                }
            }



            /// <summary>
            /// 封装访问参数fillnum函数，保证每次只有一个进程访问。 
            /// get == 0 判断满；get == 1 获取信号量； get == 2 释放信号量；
            /// </summary>
            public bool useFillnum(int get)
            {
                lock (this)
                {
                    if (get == 1)
                    {
                        if (fillnum == 0) return false;
                        fillnum--;
                        return true;
                    }
                    else if(get == 2)
                    {
                        if (fillnum != size)
                        {
                            fillnum++;
                        }
                        return true;
                    }
                    else
                    {
                        return fillnum == size ? true : false;
                    }

                }
            }

      

            private TextBox[] box;
            private int size;
            private int fillnum = 0;     //已写入的数目的信号量
            private int emptynum;        //空信号量
            private int c_pointerpos = 0;
            private int p_pointerpos = 0;
            private int pointerwidth = 45;

            internal System.Windows.Forms.Panel consumerPointer;
            internal System.Windows.Forms.Panel producerPointer;
            internal System.Windows.Forms.Label label7;
            internal System.Windows.Forms.Label label8;
            internal System.Windows.Forms.Label label9;
            internal System.Windows.Forms.Label label10;
        }

        










        //本窗口实例
        private static MainForm mainform;

        //生产者、消费者、缓冲池属性
        private readonly int producernum = 3;
        private readonly int consumernum = 5;
        private readonly int bufferpoolsize = 5;
        private Thread[] producer;
        private Thread[] consumer;
        private Bufferpool bufferpool;

        //输入区属性(输入的数据，是否已输入标记)
        private int c_inputno;
        private int c_inputtime;
        private int p_inputno;
        private int p_inputtime;
        private int inputrandomnum;
        private int maxtime = 0;
        private string p_inputdata;
        private bool issetcno = false;
        private bool issetctime = false;
        private bool issetpno = false;
        private bool issetptime = false;
        private bool issetpdata = false;
        private bool issetrandom = false;

        //进程执行属性（， 缓冲区执行信号量）
        private Semaphore[] producersemaphore;                          //线程信号量
        private Semaphore[] consumersemaphore;                          //线程信号量
        private Semaphore mainsemaphore = new Semaphore(1, 1);          //缓冲区执行信号量
        private Processlist processlist = new Processlist();            //进程列表
        private bool isruning = false;                                  //正在运行标记
        private int processlistsize = 0;
        private int runtime = 0;
        private int finishthreadnum;                                    //列表中生产者，消费者总数及已运行数
        private int runproducernum = 0;
        private int runconsumernum = 0;
        private int finishproducernum = 0;
        private int finishconsumernum = 0;



        



        //构造函数 ---------------------------------------------------------------------
        public MainForm()
        {
            mainform = this;
            producer = new Thread[producernum];
            consumer = new Thread[consumernum];
            bufferpool = new Bufferpool(bufferpoolsize);
            producersemaphore = new Semaphore[producernum];
            consumersemaphore = new Semaphore[consumernum];

            InitializeComponent();

            MyInitializeComponent();
        }

        public MainForm(int p1, int c1, int b1)
        {
            mainform = this;
            producernum = p1;
            consumernum = c1;
            bufferpoolsize = b1;
            producer = new Thread[producernum];
            consumer = new Thread[consumernum];
            bufferpool = new Bufferpool(bufferpoolsize);
            producersemaphore = new Semaphore[producernum];
            consumersemaphore = new Semaphore[consumernum];

            InitializeComponent();

            MyInitializeComponent();
        }



        

        //主界面控件布局函数 -----------------------------------------------------------------------------------
        private void MyInitializeComponent()
        {
            //
            // processsemaphore
            //
            for(int i = 0; i < producernum; i++)
            {
                producersemaphore[i] = new Semaphore(1, 1);
            }
            for(int i = 0; i < consumernum; i++)
            {
                consumersemaphore[i] = new Semaphore(1, 1);
            }

            // 
            // bufferpool
            //
            Controls.Add(bufferpool.producerPointer);
            Controls.Add(bufferpool.consumerPointer);
            for (int i = 0; i < bufferpoolsize; i++)
            {
                Controls.Add(bufferpool[i]);
            }
            //
            // p_comboBox & c_comboBox
            //
            for(int i = 1; i <= producernum; i++)
            {
                p_comboBox.Items.Add(i.ToString());
            }
            for(int i = 1; i <= consumernum; i++)
            {
                c_comboBox.Items.Add(i.ToString());
            }
        }











        //输入生产者信息 ---------------------------------------------------------------------------------------
        private void p_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            p_inputno = int.Parse(p_comboBox.Text);
            issetpno = true;
        }

        private void p_starttimeTextBox_Validated(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(p_starttimeTextBox.Text, out value))
            {
                if (Checktime(value))
                {
                    p_inputtime = value;
                    issetptime = true;
                }
            }
            else
            {
                MessageBox.Show("数据不规范", "提示");
                p_starttimeTextBox.Text = string.Empty;
                issetptime = false;
            }
        }

        private void p_dataTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (p_dataTextBox.Text == string.Empty) issetpdata = false;
            else
            {
                p_inputdata = p_dataTextBox.Text;
                issetpdata = true;
            }
        }


        //添加生产者 ----------------------
        private void addProducerButton_Click(object sender, EventArgs e)
        {
            if(isruning)
            {
                MessageBox.Show("正在运行");
                return;
            }
            if (issetptime && issetpno && issetpdata && processlistsize < 20)
            {
                if (Checktime(p_inputtime))
                {
                    MyProcess p = new MyProcess(false, p_inputno - 1, p_inputtime, p_inputdata);
                    processlist.Add(p);
                    maxtime = p_inputtime;
                    processlistsize++;
                    ListTextBox.AppendText("生产者" + p_inputno.ToString() + " 写入时间：" + p_inputtime.ToString() + "ms\r\n" + "写入数据：" + p_inputdata + "\r\n\r\n");
                }
            }
            else if (processlistsize >= 20)
            {
                MessageBox.Show("进程队列已满，无法添加", "提示");
            }
            else MessageBox.Show("数据未填写完全", "提示");

        }





        //输入消费者信息 ---------------------------------------------------------------------------------------
        private void c_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            c_inputno = int.Parse(c_comboBox.Text);
            issetcno = true;
        }

        private void c_starttimeTextBox_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (int.TryParse(c_starttimeTextBox.Text, out value))
            {
                if (Checktime(value))
                {
                    c_inputtime = value;
                    issetctime = true;
                }
            }
            else
            {
                MessageBox.Show("数据不规范", "提示");
                c_starttimeTextBox.Text = string.Empty;
                issetctime = false;
            }
        }


        //添加消费者 ----------------------------------
        private void addConsumerButton_Click(object sender, EventArgs e)
        {
            if (isruning)
            {
                MessageBox.Show("正在运行");
                return;
            }
            if (issetctime && issetcno && processlistsize < 20)
            {
                if (Checktime(c_inputtime))
                {
                    MyProcess c = new MyProcess(true, c_inputno - 1, c_inputtime);
                    processlist.Add(c);
                    maxtime = c_inputtime;
                    processlistsize++;
                    ListTextBox.AppendText("消费者" + c_inputno.ToString() + " 读取时间：" + c_inputtime.ToString() + "ms\r\n\r\n");
                }
            }
            else if (processlistsize >= 20)
            {
                MessageBox.Show("进程队列已满，无法添加", "提示");
            }
            else MessageBox.Show("数据未填写完全", "提示");
        }


        //检查时间填写规范 --------------------------------
        private bool Checktime(int t)
        {
            if (t >= maxtime) return true;
            else
            {
                MessageBox.Show("请填入更晚的运行时刻", "提示");
                return false;
            }
        }





        //生成随机队列 --------------------------------------------------------------------------------------------
        private void randomTextBox_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (int.TryParse(randomTextBox.Text, out value) && value > 0 && value < 21)
            {
                inputrandomnum = value;
                issetrandom = true;
            }
            else
            {
                MessageBox.Show("需要填入1~20之间的数字", "提示");
                randomTextBox.Text = string.Empty;
                issetrandom = false;
            }
        }

        private void createRandomList_Click(object sender, EventArgs e)
        {
            if (isruning)
            {
                MessageBox.Show("正在运行");
                return;
            }
            if (issetrandom)
            {
                int rdtime = 0;
                Random rd = new Random();
                cleanList();
                processlistsize = inputrandomnum;
                for (int i = 0; i < processlistsize; i++)
                {
                    int rdno;
                    string rddata;
                    bool rdstatus = (randomCheckBox.Checked == true)? rd.Next(0, 2) == 1 : rd.Next(0, producernum + consumernum) >= producernum;

                    if (rdstatus == false)
                    {
                        rdno = rd.Next(0, producernum) + 1;
                        rddata = rd.Next(100, 1000).ToString();
                        ListTextBox.AppendText("生产者" + rdno.ToString() + " 写入时间：" + rdtime.ToString() + "ms\r\n" + "写入数据：" + rddata + "\r\n\r\n");
                    }
                    else
                    {
                        rdno = rd.Next(0, consumernum) + 1;
                        rddata = string.Empty;
                        ListTextBox.AppendText("消费者" + rdno.ToString() + " 读取时间：" + rdtime.ToString() + "ms\r\n\r\n");
                    }
                    MyProcess mp = new MyProcess(rdstatus, rdno - 1, rdtime, rddata);
                    processlist.Add(mp);
                    maxtime = rdtime;
                    rdtime += rd.Next(0, 21) * 50;
                }
            }
            else MessageBox.Show("未填写序列长度", "提示");
        }
        




        //清除队列信息 ------------------------------------------------------------------------------------------
        private void cleanListButton_Click(object sender, EventArgs e)
        {
            if (isruning)
            {
                MessageBox.Show("正在运行");
                return;
            }
            cleanList();
        }
        private void cleanList()
        {
            ListTextBox.Text = string.Empty;
            maxtime = 0;
            processlistsize = 0;
            processlist.Clean();
        }


        //开始运行 ---------------------------------------------------------------------------------------------
        private void startRuningButton_Click(object sender, EventArgs e)
        {
            if (isruning)
            {
                MessageBox.Show("正在运行");
                return;
            }
            Thread runthread = new Thread(new ThreadStart(processRun));
            isruning = true;
            runthread.Start();
        }


        //清空信息栏 -------------------------------------------------------------------------------------------
        private void cleanMessageButton_Click(object sender, EventArgs e)
        {
            messageTextBox.Text = string.Empty;
        }

        //初始化缓冲池 -----------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            if (isruning)
            {
                MessageBox.Show("正在运行");
                return;
            }
            mainform.bufferpool.cleanbufferpool();
        }
    }










}
