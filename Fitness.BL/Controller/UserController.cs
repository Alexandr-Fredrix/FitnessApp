using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Контроль пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения. 
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контролера.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName, string genderName, DateTime birdthday, double weight, double height)
        {
            ///TODO: Должна быть проверка.
            var gender = new Gender(genderName);
            User = new User(userName, gender, birdthday, weight, height);
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileLoadException"> Пользователь приложения. </exception>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                } 

                //TODO: Что делать если пользователя не прочетали
            }
        }

    }
}
