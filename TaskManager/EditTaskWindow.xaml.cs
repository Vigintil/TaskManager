using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

namespace TaskManager
{
    public partial class EditTaskWindow : Window
    {
        public EditTaskWindow()
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
                taskChecklist.Add(new TaskChecklist() { Description = listSubtasks.Items[0].ToString(), IsComplete = false });
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            viewModel.LoadTasks();
            Task task = (Application.Current.MainWindow as MainWindow).EditTask;

            task.Name = editTaskWindowTitle.Text;
            task.Description = editTaskWindowDescription.Text;

            taskChecklist.Clear();
            for (int i = 0; i < listSubtasks.Items.Count; i++)
            {
                taskChecklist.Add(new TaskChecklist() { Description = listSubtasks.Items[i].ToString(), IsComplete = false });
            }

            task.TaskChecklist = taskChecklist;

            switch (cathegorySelection.Text)
            {
                case "Work":
                    task.TaskCategory = TaskCategory.Work; break;
                case "Personal":
                    task.TaskCategory = TaskCategory.Personal; break;
                case "Home":
                    task.TaskCategory = TaskCategory.Home; break;
                case "Health":
                    task.TaskCategory = TaskCategory.Health; break;
                case "Finance":
                    task.TaskCategory = TaskCategory.Finance; break;
                case "Shopping":
                    task.TaskCategory = TaskCategory.Shopping; break;
                case "Social":
                    task.TaskCategory = TaskCategory.Social; break;
                case "Education":
                    task.TaskCategory = TaskCategory.Education; break;
                case "Walks":
                    task.TaskCategory = TaskCategory.Walks; break;
                case "Hobbies":
                    task.TaskCategory = TaskCategory.Hobbies; break;
                case "Birthdates":
                    task.TaskCategory = TaskCategory.Birthdates; break;
                case "Projects":
                    task.TaskCategory = TaskCategory.Projects; break;
                case "Long Term Goals":
                    task.TaskCategory = TaskCategory.LongTermGoals; break;
                case "Ideas":
                    task.TaskCategory = TaskCategory.Ideas; break;
                case "Games":
                    task.TaskCategory = TaskCategory.Games; break;
                case "Holidays":
                    task.TaskCategory = TaskCategory.Holidays; break;
            }




            viewModel.UpdateTask(task);
            Close();
        }
    }
}
