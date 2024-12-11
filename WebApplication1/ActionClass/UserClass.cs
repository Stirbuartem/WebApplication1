using WebApplication1.Interface;
using WebApplication1.Models;
using static WebApplication1.ActionClass.HelperClass.DTO.AccountDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.ActionClass.Account;
using WebApplication1.ActionClass.HelperClass.DTO;



namespace WebApplication1.AcshanClass
{
    public class UserClass : IUser
    {
        
            private readonly Shtirbu223ToysShopDbContext _context;

            public UserClass(Shtirbu223ToysShopDbContext context)
            {
                _context = context;
            }

            public List<UserDTO> GetUsers()
            {
                try
                {
                    var users = _context.Users.ToList();

                    var userDTOs = users.Select(user => new UserDTO
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        Surname = user.Surname,
                        Login = user.Login,
                        Password = user.Password
                    }).ToList();

                    return userDTOs;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при получении пользователей: " + ex.Message);
                }
            }

            public List<UserDTO> GetUser(int userId)
            {
                try
                {
                    var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

                    if (user == null)
                    {
                        return new List<UserDTO>();
                    }

                    var userDTO = new UserDTO
                    {
                        UserId = user.UserId,
                        Name = user.Name,
                        Surname = user.Surname,
                        Login = user.Login,
                        Password = user.Password
                    };

                    return new List<UserDTO> { userDTO };
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при получении пользователя: " + ex.Message);
                }
            }

            public string AddUser(UserCreate user)
            {
                try
                {
                    if (user.Name.Contains(" ") ||
                        user.Surname.Contains(" ") ||
                        user.Login.Contains(" ") ||
                        user.Password.Contains(" "))
                    {
                        throw new Exception("У вас содержиться пробелы. Удалите пожалуйста");
                    }

                    if (user.Password.Length <= 4)
                    {
                        throw new Exception("Пароль должен содержать больше четырёх символов");
                    }

                    User createUser = new User()
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Login = user.Login,
                        Password = user.Password
                    };

                    _context.Users.Add(createUser);
                    _context.SaveChanges();

                    int userId = createUser.UserId;
                    string success = $"Успешно создан пользователь с ID {userId}";

                    Results.Created();
                    return success;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка в выполнении запроса: " + ex.Message);
                }
            }

            public List<string> UserUpdate(int userId, UserUpdate user)
            {
                try
                {
                    if (user.Name.Contains(" ") ||
                        user.Surname.Contains(" ") ||
                        user.Login.Contains(" ") ||
                        user.Password.Contains(" "))
                    {
                        throw new Exception("ни в одном поле не должно содержаться пробела.");
                    }

                    if (user.Password.Length <= 4)
                    {
                        throw new Exception("пароль должен содержать больше 4-ёх символов.");
                    }

                    var existingUser = _context.Users.FirstOrDefault(u => u.UserId == userId);
                    if (existingUser == null)
                    {
                        return new List<string> { "Пользователь не найден." };
                    }

                    existingUser.Name = user.Name ?? existingUser.Name;
                    existingUser.Surname = user.Surname ?? existingUser.Surname;
                    existingUser.Login = user.Login ?? existingUser.Login;
                    existingUser.Password = user.Password ?? existingUser.Password;

                    _context.SaveChanges();

                }
                catch (Exception ex) 
                {
                    throw new Exception(ex.Message);
                }
            }
            public List<string> DeleteUser(int userId)
            {
                try
                {
                    var existingUser = _context.Users.FirstOrDefault(u => u.UserId == userId);
                    if (existingUser == null)
                    {
                        return new List<string> { "Пользователь не найден." };
                    }

                    _context.Users.Remove(existingUser);
                    _context.SaveChanges();

                    return new List<string> { "Пользователь успешно удален." };
                }
                catch (Exception ex)
                {
                    return new List<string> { "Ошибка при удалении пользователя: " + ex.Message };
                }
            }

        List<AccountDTO> IUser.GetUsers()
        {
            throw new NotImplementedException();
        }

        public List<AccountDTO> GetUser(string phone)
        {
            throw new NotImplementedException();
        }

        public List<string> AddAcount(AccountCreate account)
        {
            throw new NotImplementedException();
        }

        public List<string> UpdateUser(string phone, AccountUpdateDTO user)
        {
            throw new NotImplementedException();
        }

        public List<string> DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        object IUser.AddUser(UserCreate user)
        {
            throw new NotImplementedException();
        }

        object IUser.GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public List<string> UpdateUser(int userId, UserUpdate user)
        {
            throw new NotImplementedException();
        }
    }
    }

