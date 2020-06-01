using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Runtime.CompilerServices;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день ");


            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);

            if (userController.IsNewUser)//реализованная проверка на пользователя
            {
                Console.WriteLine("Введите свой пол");
                var gender = Console.ReadLine();
                DateTime birthDate;
                birthDate = ParseDateTime();

                double weight = ParseDouble("Вес");
                double height = ParseDouble("Рост");

                

                userController.SetNewUserData(gender, birthDate, weight, height);


            }



            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }
        /// <summary>
        /// Проверка на корректность введенной даты рождения*
        /// </summary>
        /// <returns></returns>
        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("ВВод даты рождения");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неправильная дата");
                }

            }

            return birthDate;
        }

        /// <summary>
        /// Проверка на корректность введеных данных Вес + Рост *
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неправильный формат {name}");
                }

            }

        }
    }
}
