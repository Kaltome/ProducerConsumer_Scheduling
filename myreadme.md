## 合并二叉树

给出两个二叉树，合并它们并返回合并后的二叉树。合并规则：相同位置的节点值相加

如果相同位置都不为 null，则数值相加

如果相同位置一个树为 null，一个树值为 A，则设置为 A

如果相同位置都为 null，则设置为 null

<br/>

## 代码实现
声明两个string类型的变量array1，array2，来获取输入的数据
用三个vector<string>类型的变量 tree1 tree2 mergetree来代表合并前的两棵树和合并后的树

分别检索array1，array2， 忽略' [ '，用一个string类型s来收集输入的字符，遇到' , '或' ] '则把s推入到各自的Vector：tree1，tree2中，清空s

同时检索tree1 tree2，若一个已检索完成，则把另一个剩下的元素加入到mergetree中，按顺序获取tree1 tree2中的元素，若两个均不为‘null’，则把他们
转化成int做加法再转回string加入到mergetree中，若两个均为‘null’，则把‘null’加入到mergetree中，若其中一个为‘null’，则把另一个加入到mergetree中

按顺序输入mergetree中的元素，程序完成
