using System;
using System.Data;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class User
    {
        
        #region Свойства Пользователя 
        public string Name { get; }

        public Gender Gender { get; }
          
        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height  { get; set; }
        #endregion

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthDate">Дата Рождения</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name,
                        Gender gender,
                        DateTime birthDate,
                        double weight,
                        double height)
        {
    #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользоватля не может быть пустым ", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол Не может быть кривым", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("невозможная дата рождения", nameof(birthDate)); 
            }

            if (weight<=0)
            {
                throw new ArgumentNullException("Вес не может быть меньше 0",nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше 0", nameof(height));
            }
            #endregion
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
