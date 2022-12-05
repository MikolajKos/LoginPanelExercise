using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsConverterApp.Core;

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

        private int _outputMessage;
        public int OutputMessage
        {
            get => _outputMessage; 
            set 
            { 
                _outputMessage = value;
                OnPropertyChanged(nameof(OutputMessage));
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

                    },
                    (object o) => true); 
                return _loginCommand;
            }
        }

    }
}
