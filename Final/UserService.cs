using Final.DAL;
using Final.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public IEnumerable<User> GetAllUsersWithLoans()
        {
            return _userRepository.GetAllUsersWithLoans();
        }

        public User? GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
             _userRepository.DeleteUserById(id);
        }

        public void DeleteUserByName(string name)
        {
             _userRepository.DeleteUserByName(name);
        }
    }
}
