using System;
using Model.Logic;
using static Util.Menu;

namespace Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task \"Products\"\n");

            Manager manager = new Manager();
            MenuForManager(manager);
        }
    }
}