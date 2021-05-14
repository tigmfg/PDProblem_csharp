using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PhilosopherDineProblem
{
    class PDproblem
    {
        /////当哲学家同时拿起左右两边的筷子时，才会开始进餐，防止进程死锁
        public static readonly int maxPhilosopher = 5;    // 最大的哲学家数量

        public  List<Semaphore> forks = new List<Semaphore>();    //用列表储存五个叉子
        static Semaphore andSem = new Semaphore(1,1);     //and信号量，当同时获得两个叉子时才能进餐

        public void CreatForks()
        {
            for (int i = 0; i < maxPhilosopher; i++)     //创建五个叉子信号量
            {
                forks.Add(new Semaphore(1, 1));
            }
        }

        public void Dine(object numberObj)
        {
            while (true)
            {
                int number = Convert.ToInt32(numberObj) - 1;   //列表索引从0开始，所以要-1
                andSem.WaitOne();   //等待and信号量
                forks[number].WaitOne();   //取得左侧叉子
                Console.WriteLine(Thread.CurrentThread.Name + "取得左侧叉子");
                forks[(number + 1) % maxPhilosopher].WaitOne();   //取得右侧叉子
                Console.WriteLine(Thread.CurrentThread.Name + "取得右侧叉子");
                Console.WriteLine(Thread.CurrentThread.Name + "开始进食");
                andSem.Release();   //当同时获得两侧叉子时，释放and信号量
                Thread.Sleep(1000);
                forks[number].Release();
                forks[(number + 1) % maxPhilosopher].Release();    //进餐结束，放下两个叉子
                Console.WriteLine(Thread.CurrentThread.Name + "放下叉子，陷入思考");
                Thread.Sleep(new Random().Next(2000, 5000));
            }
        }
    }
}
