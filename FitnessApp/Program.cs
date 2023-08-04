using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение FitnessApp");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол пользователя");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения пользователя");
            var birdthDay = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите вес пользователя");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост пользователя");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birdthDay, weight, height);
            userController.Save();
        }
    }
}
