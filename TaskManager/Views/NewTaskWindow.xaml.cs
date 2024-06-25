using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskManager.Models;
using TaskManager.ViewModel;

namespace TaskManager.Views
{
    /// <summary>
    /// Логика взаимодействия для NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public NewTaskWindow()
        {
            InitializeComponent();
            viewModel = new TaskViewModel();
            DataContext = viewModel;
        }

        private TaskViewModel viewModel;
        private ObservableCollection<TaskChecklist> taskChecklist = new ObservableCollection<TaskChecklist>();

        private void Window_Closed(object sender, EventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).PopulateItems();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listSubtasks.Items.Add(textblockSubtask.Text);
            taskChecklist.Clear();
            for (int i = 0; i < listSubtasks.Items.Count; i++)
            {
                taskChecklist.Add(new TaskChecklist() { Description = listSubtasks.Items[i].ToString(), IsComplete = false });
            }

            viewModel.TaskChecklist = taskChecklist;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listSubtasks.Items.Remove(listSubtasks.SelectedItem);
            taskChecklist.Clear();
            for (int i = 0; i < listSubtasks.Items.Count; i++)
            {
                taskChecklist.Add(new TaskChecklist() { Description = listSubtasks.Items[i].ToString(), IsComplete = false });
            }

            viewModel.TaskChecklist = taskChecklist;
        }
    }
}
