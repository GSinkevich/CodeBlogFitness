using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;


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

            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите свой пол");
                var gender = Console.ReadLine();
                DateTime birthDate;
                double weight;
                double height;


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


                
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }
    }
}
