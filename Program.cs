using System;
namespace Alien_vs_Depredador;

class Program
{
    static void Main()
    {
        Controller controller = new Controller();
        controller.start();
        while (true)
        {
            controller.turn(1);
            System.Threading.Thread.Sleep(3000);
            controller.turn(2);
            System.Threading.Thread.Sleep(3000);
        }
    }
}
