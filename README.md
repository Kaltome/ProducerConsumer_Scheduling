# 生产者-消费者调度

一个生产者-消费者调度示例程序，采用winform实现，来玩玩吧。

<br/>

## 使用方法

1、运行程序。输入所有数据后可点击进入主界面。

2、主界面右下方为添加进程区。选择生产者、消费者及其编号，输入该进程开始调度的时间和写入的数据（仅生产者）。新输入的进程开始调度时间要不早于最后一个加入调度列表的进程的开始调度时间。单击右侧的添加按钮即可添加该进程进入调度列表。最大添加量为20。<br/>

可输入长度，随机生成进程列表。可选择生成生产者，消费者的概率是否相同（否则两者生成概率之比为两者数量之比）。<br/>

可点击清空按钮清空列表重新输入。随机生成进程列表时默认先清空列表。

3、输入调度列表后，点击“开始运行”按钮即可观察到生产者，消费者的运行情况，左下侧信息栏实时显示运行信息。

4、运行完毕后，可选择清空缓冲池，清空运行信息，更改调度列表，再次运行等操作
<br/>

<br/>

## 运行规则
#### 生产者-消费者调度：

1、若干进程通过有限的共享缓冲区交换数据

2、“生产者”进程不断放入数据，而“消费者”进程不断取走数据

3、共享缓冲区共有N个；任何时刻只能有一个进程可对共享缓冲区进行操作

4、生产者/消费者通过等待获取缓冲区容量信号量（是否空满）和缓冲区执行信号量（是否有其他进程正在访问缓冲区）来获得读写权限

4、当缓冲区满时，生产者必须等待直到缓冲区出现可写空位；当缓冲区空时，消费者必须等待直到缓冲区出现可读数据
<br/>
#### 本程序运行规则：
1、  本程序运用程序内线程来模拟进程，主调度线程指调度分发生产者/消费者的线程，执行线程指生产者/消费者线程

2、  执行线程被调度指该线程开始运行，申请信号量，并非指开始执行读写操作。

3、	每个生产者运行均消耗650ms，每个消费者运行均消耗350ms

4、	当生产者(消费者)在等待缓冲区容量信号量时，若之后已无消费者(生产者)等待执行，则退出等待，输出无法正常执行信息

5、	开始运行时间指生产者/消费者开始对缓冲区执行读写操作时间，非开始调度时间

6、	某个执行线程在运行时可存在被主调度线程尝试再次调度的情况，此时主调度线程创建一个子线程来监测等待执行线程运行完毕，然后再度调用

7、	生产者指针指向下一个写入的位置，消费者指针指向要读取的位置

8、	多个执行线程等待信号量时，选择哪个线程获取信号量来执行读写动作随机




