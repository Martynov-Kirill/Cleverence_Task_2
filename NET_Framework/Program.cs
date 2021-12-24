using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NET_Framework
{
	internal class Program
	{
		private static void DoSomeWork(object sender, EventArgs e)
		{
			Console.WriteLine("Enter Handler");
			Thread.Sleep(1000);
			Console.WriteLine("Enter Handler");
			Thread.Sleep(1000);
			Console.WriteLine("Enter Handler");
			Thread.Sleep(1000);
			Console.WriteLine("Exit Handler");
		}

		private static void Run()
		{
			EventHandler h = new EventHandler(DoSomeWork);
			//AsyncCaller ac = new AsyncCaller(h);
			//if (ac.Invoke(5000, this, EventArgs.Empty))
			//	Console.WriteLine("Completed successfully");
			//else
			//	Console.WriteLine("Timeout occured");
		}

		static void Main(string[] args)
		{
			Run();
			Console.WriteLine("Done.");
			Console.ReadKey();
		}
	}
}
