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

        private bool EnteredAndDbPasswordsAreSame(string password, string login)
        {
            var getPassword = model.myContext.User.FirstOrDefault(k => k.UserLogin == login)?.UserPassword;

            if (getPassword == password) return true;

            return false;
        }

        private string GetLogin(string login)
        {
            model.myContext = new();
            var storedLogin = model.myContext.User.FirstOrDefault(k => k.UserLogin == login).UserLogin;
            return storedLogin.ToString();
        }

        public void Register(string login, string password, out string message)
        {
            message =  "";

            model.myContext = new();
            string HashedPW = pwHashing.HashPassword(password);

            model.myContext.User.Add(
            new Users()
            {
                UserLogin = login,
                UserPassword = HashedPW
            });

            model.myContext.SaveChanges();
            message = $"Registered successfully, welcome {login}!";
        }

        public void Login(string login, string password, out string message)
        {
            message = "";
            model.myContext = new();
            string HashedPW = pwHashing.HashPassword(password);

            if (!EnteredAndDbPasswordsAreSame(HashedPW, login))
            {
                message = "Incorrect password or login";
                return;
            }

            message = $"Welcome {GetLogin(login)}!";
        }
    }
}
