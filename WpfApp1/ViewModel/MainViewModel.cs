using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Commands;
using WpfApp1.Pages;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private string words;
        private List<string> wordsList;
        private Page page1;


        //свойство, к которому привязывается другое свойство Command какой-то кнопки
        public ICommand Btn1Command { get; }
        public ICommand Btn2Command { get; }


        public Page Page1 
        { 
            get => page1;
            set 
            { 
                if(value != page1)
                {
                    page1 = value;
                    OnPropertyChanged();
                }
            } 
        }


        public string Words
        {
            get => words;
            set
            {
                if (value != words)
                {
                    words = value;
                    OnPropertyChanged();
                }
            }

        }

        public MainViewModel()
        {
            //Для команды определяем то, что будет выполняться (передаем в конструктор название метода)
            Btn1Command = new MyCommand(ShowWords);
            Btn2Command = new MyCommand(ShowWordsInvert);
        }

        private void ShowWordsInvert(object p)
        {
            if (Words != null && Words.Length > 0)
            {
                wordsList = Words.Split(' ').Reverse().ToList();



                WordShow page = new WordShow();
                page.textBlock.Text = string.Join(" ", wordsList);

                Page1 = page;

            }
        }

        private void ShowWords(object p)
        {
            if (Words != null && Words.Length > 0)
            {
                wordsList = Words.Split(' ').ToList();

                WordShow page = new WordShow();
                page.itemControl.ItemsSource = wordsList;

                Page1 = page;

            }
        }
    }
}
