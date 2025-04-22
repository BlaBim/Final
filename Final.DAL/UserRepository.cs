using Final.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.UsersFinal;
        }

        public User GetUserById(int id)
        {
            return _context.UsersFinal.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByName(string name)
        {
            return _context.UsersFinal.FirstOrDefault(u => u.Name == name);
        }

        public IEnumerable<User> GetAllUsersWithLoans()
        {
            return _context.UsersFinal
                .Include(u => u.Loans)
                .ToList();
        }

        public User GetUserByIdWithLoans(int id)
        {
            return _context.UsersFinal
                .Include(u => u.Loans)
                .FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _context.UsersFinal.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.UsersFinal.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.UsersFinal.Remove(user);
                _context.SaveChanges();
            }
        }
        public void DeleteUserByName(string name)
        {
            var user = GetUserByName(name);
            if (user != null)
            {
                _context.UsersFinal.Remove(user);
                _context.SaveChanges();
            }
        }

        public void DeleteAllUsers()
        {
            var users = GetAllUsers();
            _context.UsersFinal.RemoveRange(users);
            _context.SaveChanges();
        }
    }
}
