﻿using CodeBlogFitness.BL.Controller;
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


            Console.WriteLine("Введите пол пользователя");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите вес");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);

            userController.Save();


        }
    }
}
