using System;

namespace Project1_QuanLyCongViecCanLam
{
    class Program
    {
        static void Main(string[] args)
        {
            Todo manager = new Todo();
            try
            {
                manager.MainMenu();
            }
            catch (FormatException)
            {
                Console.WriteLine("Phải nhập đúng cú pháp.");
                manager.MainMenu();

            }

        }
    }
}
