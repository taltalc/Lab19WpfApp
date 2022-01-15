using Homework.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Homework.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double r;
        public double R
        {
            get => r;
            set
            {
                r = value;
                OnPropertyChanged();
            }
        }

         void OnPropertyChanged([CallerMemberName] string PropertyName=null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(PropertyName));
        }

        private double l;
        public double L
        {
            get => l;
            set
            {
                l = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; }

        private void OnAddCommandExecute(object p)
        {
            L = Circumference.Add(R);
        }
        private bool CanAddCommandExecute(object p)
        {
            if (R >= 0)
            {
                return true;
            }
            else
                return
                    false;
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecute);
        }
    }
}
