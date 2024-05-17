using System;
using PlayerManagerMVC.Controllers;

namespace PlayerManagerMVC
{
    public class Program
    {
        private static void Main(string[] args)
        {
            PlayerController controller = new PlayerController();
            controller.Run();
        }
    }
}
