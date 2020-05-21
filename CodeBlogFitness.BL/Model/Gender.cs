using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создание нового пользователя 
        /// </summary>
        /// <param name="name"></param>
        public Gender (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Введите корректное имя пользователя",nameof(name));
            }

            Name = name;
                        
        }

        public override string ToString()
        {
            return Name ;
        }

    }
}
