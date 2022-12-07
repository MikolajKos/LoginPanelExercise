using LoginPanelLesson.MVVM.Models;
using LoginPanelLesson.MVVM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginPanelLesson.Repositories
{
    public class LinqQueries
    {
        private MainModel model = new();
        private PasswordHashing pwHashing = new();

        public bool DoesLoginExist(string login)
        {
            model.myContext = new();
            bool loginExist = model.myContext.User.Any(k => k.UserLogin == login);

            return loginExist;
        }

        public bool EnteredAndDbPasswordsAreSame(string login, string password)
        {
            model.myContext = new();

            string HashedPW = pwHashing.HashPassword(password);
            var getPassword = model.myContext.User.FirstOrDefault(k => k.UserLogin == login)?.UserPassword;

            if (getPassword == HashedPW) return true;

            return false;
        }

        public void Register(string login, string password)
        {
            model.myContext = new();
            string HashedPW = pwHashing.HashPassword(password);

            model.myContext.User.Add(
            new Users()
            {
                UserLogin = login,
                UserPassword = HashedPW
            });

            model.myContext.SaveChanges();
        }

        public string Login(string login)
        {
            model.myContext = new();
            var storedLogin = model.myContext.User.FirstOrDefault(k => k.UserLogin == login).UserLogin;
            return $"Welcome {storedLogin}!";
        }
    }
}
