

using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /// 

        public List <User> Users { get; }
        public User CurrentUser { get; }

        /// <summary>
        /// Создание новоого контроллера пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);//единственный пользователь или Null

            if (CurrentUser==null)
            {
                CurrentUser = new User();
            }           
                       
        }
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs=new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,Users);
            }
        }
        /// <summary>
        /// Получить cписок сохраненный пользователей
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is List<User> users)//если объект получится 
                                                                 //десериализовать, то он будет помещен в переменную user
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }


            }
        }
    }
}
