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

        public List <User> Users { get; }// Список пользователей*
        public User CurrentUser { get; }// Кокретный пользователь*

        public bool IsNewUser { get; } = false;// чек на нового пользователя*

        /// <summary>
        /// Создание нового конкретного пользователя
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);//единственный пользователь( с именем userName) или Null(Сокращаеться до u-users)

            if (CurrentUser==null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
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


        /// <summary>
        /// Создание нового пользователя*
        /// </summary>
        /// <param name="genderName"></param>
        /// <param name="birthDay"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void SetNewUserData(string genderName,DateTime birthDay,double weight= 1,double height= 1)
        {
            

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDay;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
    }
}
