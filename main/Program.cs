using System;
using System.Threading;

namespace PhilosopherDineProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            PDproblem table = new PDproblem();  //实例化解决方案

            new Thread(new ThreadStart(table.CreatForks)).Start();  //先执行CreatForks，往叉子列表添加五个叉子信号量
            Thread.Sleep(10);

            Thread philosopher1 = new Thread(table.Dine);   //创建线程
            philosopher1.Name = "哲学家1";
            Thread philosopher2 = new Thread(table.Dine);
            philosopher2.Name = "哲学家2";
            Thread philosopher3 = new Thread(table.Dine);
            philosopher3.Name = "哲学家3";
            Thread philosopher4 = new Thread(table.Dine);
            philosopher4.Name = "哲学家4";
            Thread philosopher5 = new Thread(table.Dine);
            philosopher5.Name = "哲学家5";
            philosopher1.Start(1);   //引入参数，启用线程
            philosopher2.Start(2);
            philosopher3.Start(3);
            philosopher4.Start(4);
            philosopher5.Start(5);
            philosopher1.Join();
            philosopher2.Join();
            philosopher3.Join();
            philosopher4.Join();
            philosopher5.Join();
        }
    }
}
