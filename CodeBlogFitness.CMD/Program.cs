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


            userController.Save();

           
        }
    }
}
