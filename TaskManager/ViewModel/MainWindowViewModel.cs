using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Views;

namespace TaskManager.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static public NewTaskWindow newTaskWindow;

        public ICommand IOpenNewWindow => new RelayCommand(OpenNewWindow);
        private void OpenNewWindow()
        {
            newTaskWindow = new NewTaskWindow();
            newTaskWindow.Show();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
