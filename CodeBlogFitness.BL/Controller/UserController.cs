﻿

using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание новоого контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName,string genderName,DateTime birdyhDay, double weight, double height)
        {
            //TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birdyhDay, weight, height);

            
        }
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs=new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,User);
            }
        }
        /// <summary>
        /// Получить данные пользователя
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)//если объект получится 
                                                           //десериализовать, то он будет помещен в переменную user
                {
                    User = user;
                }            
                
                //TODO: Что делать, если пользователя не прочитали?
            }
        }
    }
}
