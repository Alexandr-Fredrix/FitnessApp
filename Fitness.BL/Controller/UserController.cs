using System;
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
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не  может быть равен NULL", nameof(user));
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
        public User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
            }
        }
    }
}
