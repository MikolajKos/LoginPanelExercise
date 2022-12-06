using LoginPanelLesson.Repositories;
using LoginPanelLesson.Validation;
using LoginPanelLesson.Validation.TypesOfValidation;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using UnitsConverterApp.Core;
using static System.Windows.Visibility;

namespace LoginPanelLesson.MVVM.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private string _loginInput;
        public string LoginInput
        {
            get => _loginInput;
            set
            {
                _loginInput = value;
                OnPropertyChanged(nameof(LoginInput));
            }
        }


        private string _passwordInput;
        public string PasswordInput
        {
            get => _passwordInput;
            set
            {
                _passwordInput = value;
                OnPropertyChanged(nameof(PasswordInput));
            }
        }


        private string _outputMessage;
        public string OutputMessage
        {
            get => _outputMessage;
            set
            {
                _outputMessage = value;
                OnPropertyChanged(nameof(OutputMessage));
            }
        }


        private Visibility _unDottedPasswordVisibility = Hidden;
        public Visibility UnDottedPasswordVisibility
        {
            get => _unDottedPasswordVisibility;
            set
            {
                _unDottedPasswordVisibility = value;
                OnPropertyChanged(nameof(UnDottedPasswordVisibility));
            }
        }


        private Visibility _dottedPasswordVisibility = Visible;
        public Visibility DottedPasswordVisibility
        {
            get => _dottedPasswordVisibility;
            set
            {
                _dottedPasswordVisibility = value;
                OnPropertyChanged(nameof(DottedPasswordVisibility));
            }
        }



        private ICommand _changeVisibilityCommand;

        public ICommand ChangeVisibilityCommand
        {
            get
            {
                if (_changeVisibilityCommand == null) _changeVisibilityCommand = new RelayCommand(
                    (object o) =>
                    {
                        UnDottedPasswordVisibility = UnDottedPasswordVisibility == Hidden ? Visible : Hidden;
                        DottedPasswordVisibility = DottedPasswordVisibility == Visible ? Hidden : Visible;
                    },
                    (object o) => true);
                return _changeVisibilityCommand;
            }
        }


        private ICommand _loginCommand = null;
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null) _loginCommand = new RelayCommand(
                    (object o) =>
                    {
                        Validate validate = new Validate();
                        validate.AddValidator(new Validator<string>(LoginInput, "Login",
                            new List<ISpecyficValidation<string>>()
                            {
                                new ValidateStringEmpty()
                            }));
                        validate.AddValidator(new Validator<string>(PasswordInput, "Password",
                            new List<ISpecyficValidation<string>>()
                            {
                                new ValidateStringEmpty()
                            }));

                        if (!validate.Validation(out string message))
                        {
                            OutputMessage = message;
                            return;
                        }


                        LinqQueries myQueries = new LinqQueries();

                        myQueries.Login(LoginInput, PasswordInput, out string loginMessage);
                        OutputMessage = loginMessage;
                    },
                    (object o) => true);
                return _loginCommand;
            }
        }

        private ICommand _registerCommand = null;
        public ICommand RegisterCommand
        {
            get
            {
                if (_registerCommand == null) _registerCommand = new RelayCommand(
                    (object o) =>
                    {
                        Validate validate = new Validate();
                        validate.AddValidator(new Validator<string>(LoginInput, "Login",
                            new List<ISpecyficValidation<string>>()
                            {
                                new ValidateStringEmpty(),
                                new ValidateLoginStringExist(),
                                new ValidateStringRange(5, 30)
                            }));
                        validate.AddValidator(new Validator<string>(PasswordInput, "Password",
                            new List<ISpecyficValidation<string>>()
                            {
                                new ValidateStringEmpty(),
                                new ValidateStringMatchRegex(),
                                new ValidateStringRange(10, 50)
                            }));

                        if (!validate.Validation(out string message))
                        {
                            OutputMessage = message;
                            return;
                        }

                        LinqQueries myQueries = new LinqQueries();
                        myQueries.Register(LoginInput, PasswordInput, out string registerMessage);

                        LoginInput = string.Empty;
                        PasswordInput = string.Empty;
                        OutputMessage = registerMessage;
                    },
                    (object o) => true);
                return _registerCommand;
            }
        }


    }
}
