using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        //событие - оповещение о том, что нужно обновить представление
        //основной способ связи (общения) между представлением и вид-моделью
        public event PropertyChangedEventHandler? PropertyChanged;

        //функция - обертка над событием PropertyChanged, в метод передается название свойства, которое изменилось
        protected void OnPropertyChanged([CallerMemberName]string? propertyName = null)
        {
            //вызов события, туда передаем отправителя события (инициатора - sender) и название свойства
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
