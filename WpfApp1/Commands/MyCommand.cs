using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1.Commands
{
    public class MyCommand : ICommand
    {
        //переданный код пользователем команды
        private Action<object> execute;


        //Специальный метод, который вызывается системой, когда наступает нужное событие (для Button - событие click)
        public void Execute(object? parameter)
        {
            //исполнение переданного кода
            execute?.Invoke(parameter);
        }


        //сюда приходит исполняемый код, который выполнится тогда, когда вызовется метод Execute
        public MyCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }
    }
}
