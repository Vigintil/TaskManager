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
    /// <summary>
    /// Логика взаимодействия для EditTaskWindow.xaml
    /// </summary>
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
                case "Работа":
                    task.TaskCategory = TaskCategory.Work; break;
                case "Личное":
                    task.TaskCategory = TaskCategory.Personal; break;
                case "Дом":
                    task.TaskCategory = TaskCategory.Home; break;
                case "Здоровье":
                    task.TaskCategory = TaskCategory.Health; break;
                case "Финансы":
                    task.TaskCategory = TaskCategory.Finance; break;
                case "Покупки":
                    task.TaskCategory = TaskCategory.Shopping; break;
                case "Социальное":
                    task.TaskCategory = TaskCategory.Social; break;
                case "Обучение":
                    task.TaskCategory = TaskCategory.Education; break;
                case "Прогулки":
                    task.TaskCategory = TaskCategory.Walks; break;
                case "Хобби":
                    task.TaskCategory = TaskCategory.Hobbies; break;
                case "Дни рождения":
                    task.TaskCategory = TaskCategory.Birthdates; break;
                case "Проекты":
                    task.TaskCategory = TaskCategory.Projects; break;
                case "Долгосрочные планы":
                    task.TaskCategory = TaskCategory.LongTermGoals; break;
                case "Идеи":
                    task.TaskCategory = TaskCategory.Ideas; break;
                case "Игры":
                    task.TaskCategory = TaskCategory.Games; break;
                case "Праздники":
                    task.TaskCategory = TaskCategory.Holidays; break;
            }




            viewModel.UpdateTask(task);
            Close();
        }
    }
}
