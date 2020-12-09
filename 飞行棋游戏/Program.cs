using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞行棋游戏
{
    class Program
    {
        //static 修饰的变量只能放在类中，不能放在方法中
        static int[] Maps = new int[100];
        //声明一个静态数组用来存储玩家A和玩家B的坐标
        static int[] PlayerPos = new int[2];
        //存储两个玩家的姓名
        static string[] PlayerNames = new string[2];
        //存储两个暂停确认标志
        static bool[] Flag = new bool[2];   //bool值默认是false
        static void Main(string[] args)
        {
            GameShow();
            InputName();
            Console.Clear();    //清屏
            GameShow();
            Console.WriteLine("{0}的士兵用A表示", PlayerNames[0]);
            Console.WriteLine("{0}的士兵用B表示", PlayerNames[1]);
            //在画地图之前要初始化地图
            InitailMap();
            DrawMap();

            //当玩家A跟玩家B没有一个人在终点的时候，两个玩家不停的去玩游戏
            while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
            {
                if (Flag[0] == false)
                {
                    PlayGame(0);
                }
                else
                {
                    Flag[0] = true;
                }

                if (Flag[1] == false)
                {
                    PlayGame(1);
                }
                else
                {
                    Flag[1] = true;
                }

            }
            Console.ReadKey();
        }

        /// <summary>
        /// 画游戏头
        /// </summary>
        public static void GameShow()
        {
            //设置背景色     ctrl+k+c注释    ctrl+k+u取消
            //Console.BackgroundColor = ConsoleColor.Yellow;
            //设置前景色
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*********飞行器游戏**********");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("*****************************");
        }

        /// <summary>
        /// 初始化地图
        /// </summary>
        public static void InitailMap()
        {
            int[] luckyturn = { 6, 23, 40, 55, 69, 83 };    //幸运轮盘☢ 
            for (int i = 0; i < luckyturn.Length; i++)
            {
                int index = luckyturn[i];
                Maps[index] = 1;
            }
            int[] landMine = { 5, 37, 17, 33, 38, 50, 64, 80, 94 };    //地雷 ✺
            for (int i = 0; i < landMine.Length; i++)
            {
                int index = landMine[i];
                Maps[index] = 2;
            }
            int[] pause = { 9, 27, 60, 93 };    //暂停 ㊡
            for (int i = 0; i < pause.Length; i++)
            {
                int index = pause[i];
                Maps[index] = 3;
            }
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };    //时空隧道 卐
            for (int i = 0; i < timeTunnel.Length; i++)
            {
                int index = timeTunnel[i];
                Maps[index] = 4;
            }
        }

        /// <summary>
        /// 画地图
        /// </summary>
        public static void DrawMap()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("图例：幸运轮盘⊙    地雷 ★    暂停 ㊡    时空隧道 卐");
            //第一横行
            #region 第一横行
            for (int i = 0; i < 30; i++)
            {
                Console.Write(DrawStringMap(i));
            }//for
            #endregion

            //画完第一横行需要换行
            Console.WriteLine();

            //第一竖行
            #region 第二竖行
            for (int i = 30; i <= 34; i++)
            {
                for (int j = 0; j <= 28; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(DrawStringMap(i));
                //打印完一行后也要换行
                Console.WriteLine();
            }
            #endregion

            //第二横行
            #region 第二横行
            for (int i = 64; i >= 35; i--)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

            //打印前要换行
            Console.WriteLine();

            //第二竖行
            #region 第二竖行
            for (int i = 65; i <= 69; i++)
            {
                Console.Write(DrawStringMap(i));
                //打印后也要换行
                Console.WriteLine();
            }
            #endregion

            ////画完第二竖横行 不需要 换行
            //Console.WriteLine();

            //第三横行
            #region 第三横行
            for (int i = 70; i <= 99; i++)
            {
                Console.Write(DrawStringMap(i));
            }
            #endregion

            //打印完最后一行地图后要换行
            Console.WriteLine();
        }

        /// <summary>
        /// 从地图的方法中抽象出来一个方法
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string DrawStringMap(int i)
        {
            string str = " ";
            // 如果玩家一和玩家二的坐标一样，玩家还在地图上，画一个尖括号
            if (PlayerPos[0] == PlayerPos[1] && PlayerPos[0] == i)
            {
                str = "<>";
            }
            else if (PlayerPos[0] == i)
            {
                //shift+空格切换全角
                str = "A";
            }
            else if (PlayerPos[1] == i)
            {
                str = "B";
            }
            else
            {
                switch (Maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        str = "□";
                        break;

                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = "⊙";
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str = "★";
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str = "㊡";
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        str = "卐";
                        break;
                }//switch
            }//else
            return str;
        }

        /// <summary>
        /// 玩家姓名输入
        /// </summary>
        public static void InputName()
        {
            Console.WriteLine("请输入玩家A的姓名");
            PlayerNames[0] = Console.ReadLine();
            while (PlayerNames[0] == "")
            {
                Console.WriteLine("玩家A的姓名不能为空，请重新输入");
                PlayerNames[0] = Console.ReadLine();
            }

            Console.WriteLine("请输入玩家B的姓名");
            PlayerNames[1] = Console.ReadLine();
            while (PlayerNames[1] == "" || PlayerNames[0] == PlayerNames[1])
            {
                if (PlayerNames[1] == "")
                {
                    Console.WriteLine("玩家B的姓名不能为空，请重新输入");
                }
                if (PlayerNames[0] == PlayerNames[1])
                {
                    Console.WriteLine("玩家B的姓名不能和玩家A一样，请重新输入");
                }
                PlayerNames[1] = Console.ReadLine();
            }
        }

        /// <summary>
        /// 玩游戏
        /// </summary>
        public static void PlayGame(int playerNumber)
        {
            Random r = new Random();
            int rNumber = r.Next(1, 7);
            Console.WriteLine("{0}按任意键开始掷骰子", PlayerNames[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}掷出了{1}", PlayerNames[playerNumber], rNumber);
            PlayerPos[playerNumber] += rNumber;
            Console.WriteLine("{0}按任意键开始行动", PlayerNames[playerNumber]);
            Console.ReadKey(true);
            Console.WriteLine("{0}行动完了", PlayerNames[playerNumber]);
            Console.ReadKey(true);

            //PlayerPos[playerNumber] += 99;    运行调试

            ChangePos();    //添加预防数组超出范围
                            //ReadKey:从键盘读取一个字符显示在控制台中  ReadLine：从键盘读取多个字符返回 
                            //Write：将字符写到控制台不换行   WriteLine：将字符写到控制台并换行

            //玩家A有可能菜刀了玩家B 方块 幸运轮盘 地雷 暂停 时空隧道
            if (PlayerPos[0] == PlayerPos[1])
            {
                Console.WriteLine("玩家{0}踩到了玩家{1}，玩家{2}退六格", PlayerNames[playerNumber], PlayerNames[1 - playerNumber], PlayerNames[1 - playerNumber]);
                PlayerPos[1 - playerNumber] -= 6;
                Console.ReadKey(true);
            }
            else//踩到了关卡
            {
                //玩家的坐标
                switch (Maps[PlayerPos[playerNumber]])  //0 1 2 3 4 
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到了方块，安全。", PlayerNames[playerNumber]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到了幸运轮盘，请选择 1——交换位置 2——轰炸对方退六格。", PlayerNames[playerNumber]);
                        string input = Console.ReadLine();
                        while (true)
                        {
                            if (input == "1")
                            {
                                Console.WriteLine("玩家{0}选择跟玩家{1}交换位置", PlayerNames[playerNumber], PlayerNames[1 - playerNumber]);
                                Console.ReadKey(true);
                                int temp = PlayerPos[playerNumber];
                                PlayerPos[playerNumber] = PlayerPos[1 - playerNumber];
                                PlayerPos[1 - playerNumber] = temp;
                                Console.WriteLine("交换完成，按任意键继续！");
                                Console.ReadKey(true);
                                break;
                            }
                            else if (input == "2")
                            {
                                Console.WriteLine("玩家{0}选择轰炸玩家{1}，玩家{2}退六格", PlayerNames[playerNumber], PlayerNames[1 - playerNumber], PlayerNames[1 - playerNumber]);
                                Console.ReadKey(true);
                                PlayerPos[1 - playerNumber] -= 6;
                                Console.WriteLine("玩家{0}退了六格", PlayerNames[1 - playerNumber]);
                                Console.ReadKey(true);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("只能输入1或者输入2 1——交换位置 2——轰炸对方");
                                input = Console.ReadLine();
                            }
                        }//while
                        break;

                    case 2:
                        Console.WriteLine("玩家{0}踩到了地雷，退六格", PlayerNames[playerNumber]);
                        PlayerPos[playerNumber] -= 6;
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到了暂停，暂停一回合", PlayerNames[playerNumber]);
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到了时空隧道，前进10格", PlayerNames[playerNumber]);
                        PlayerPos[playerNumber] += 10;
                        Console.ReadKey(true);
                        break;
                }//switch
            }//else
            ChangePos();
            DrawMap();

        }

        /// <summary>
        /// 当玩家坐标发生改变后调用
        /// </summary>
        public static void ChangePos()
        {
            if (PlayerPos[0] <= 0)
            {
                PlayerPos[0] = 0;
            }
            else if (PlayerPos[0] >= 99)
            {
                PlayerPos[0] = 99;
                DrawMap();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("             ~~恭喜胜利~~");
                Console.WriteLine("玩家{0}战胜了玩家{1}，恭喜恭喜", PlayerNames[0], PlayerNames[1]);
                Console.WriteLine("             ~~恭喜胜利~~");
                Console.ReadKey(true);
                IsAgain();
                //Environment.Exit(0);
            }

            if (PlayerPos[1] <= 0)
            {
                PlayerPos[1] = 0;
            }
            else if (PlayerPos[1] >= 99)
            {
                PlayerPos[1] = 99;
                DrawMap();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("             ~~恭喜胜利~~");
                Console.WriteLine("玩家{0}战胜了玩家{1}，恭喜恭喜", PlayerNames[1], PlayerNames[0]);
                Console.WriteLine("             ~~恭喜胜利~~");
                Console.ReadKey(true);
                IsAgain();
                //Environment.Exit(0);
            }

        }

        //public static void Win()
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine("胜利");
        //}


        /// <summary>
        /// 判断玩家是否再来一局
        /// </summary>
        public static void IsAgain()
        {
            while(true)
            {
                Console.WriteLine("请问还要再来一局吗？是请输入 Yes/No");
                String againFlag = Console.ReadLine();
                while (againFlag != "Yes" && againFlag != "yes" && againFlag != "No" && againFlag != "no")
                {
                    Console.WriteLine("输入错误，请重输！");
                    againFlag = Console.ReadLine();
                }
                if (againFlag == "Yes" || againFlag == "yes")
                {
                    PlayerPos[0] = 0;
                    PlayerPos[1] = 0;
                    DrawMap();
                    while (PlayerPos[0] < 99 && PlayerPos[1] < 99)
                    {
                        if (Flag[0] == false)
                        {
                            PlayGame(0);
                        }
                        else
                        {
                            Flag[0] = true;
                        }

                        if (Flag[1] == false)
                        {
                            PlayGame(1);
                        }
                        else
                        {
                            Flag[1] = true;
                        }

                    }//while

                }
                else if (againFlag == "No" || againFlag == "no")
                {
                    Environment.Exit(0);
                }
            }
           
        }
    }
} 
