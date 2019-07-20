using HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHR
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker<int> worker = new Worker<int>(new Func<int>(() =>
            {
                int i = 1 + 1;
                return i;
            }));
            worker.Worked += handle;
            worker.Worked += handle2;
            worker.StartWorking();
            Console.Read();
            //Task.Factory.StartNew(new (in 2) => { },)
            Action<int> action = new Action<int>((int i) => { });
        }

        private static void handle(object sender, int result, EventArgs e)
        {
            Console.WriteLine("handle：" + result);
        }

        private static void handle2(object sender, int result, EventArgs e)
        {
            Console.WriteLine("handle2：" + result);
        }
    }
}
