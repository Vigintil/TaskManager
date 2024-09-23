using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using TaskManager.DataService;
using TaskManager.Models;

namespace TaskManager.ViewModel
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan Timer { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public string TaskCategoryS { get { return ""; } set 
            { 
                switch (value)
                {
                    case "System.Windows.Controls.ComboBoxItem: Work":
                        TaskCategory = TaskCategory.Work; break;
                    case "System.Windows.Controls.ComboBoxItem: Personal":
                        TaskCategory = TaskCategory.Personal; break;
                    case "System.Windows.Controls.ComboBoxItem: Home":
                        TaskCategory = TaskCategory.Home; break;
                    case "System.Windows.Controls.ComboBoxItem: Health":
                        TaskCategory = TaskCategory.Health; break;
                    case "System.Windows.Controls.ComboBoxItem: Finance":
                        TaskCategory = TaskCategory.Finance; break;
                    case "System.Windows.Controls.ComboBoxItem: Shopping":
                        TaskCategory = TaskCategory.Shopping; break;
                    case "System.Windows.Controls.ComboBoxItem: Social":
                        TaskCategory = TaskCategory.Social; break;
                    case "System.Windows.Controls.ComboBoxItem: Education":
                        TaskCategory = TaskCategory.Education; break;
                    case "System.Windows.Controls.ComboBoxItem: Walks":
                        TaskCategory = TaskCategory.Walks; break;
                    case "System.Windows.Controls.ComboBoxItem: Hobbies":
                        TaskCategory = TaskCategory.Hobbies; break;
                    case "System.Windows.Controls.ComboBoxItem: Birthdates":
                        TaskCategory = TaskCategory.Birthdates; break;
                    case "System.Windows.Controls.ComboBoxItem: Projects":
                        TaskCategory = TaskCategory.Projects; break;
                    case "System.Windows.Controls.ComboBoxItem: Long Term Goals":
                        TaskCategory = TaskCategory.LongTermGoals; break;
                    case "System.Windows.Controls.ComboBoxItem: Ideas":
                        TaskCategory = TaskCategory.Ideas; break;
                    case "System.Windows.Controls.ComboBoxItem: Games":
                        TaskCategory = TaskCategory.Games; break;
                    case "System.Windows.Controls.ComboBoxItem: Holidays":
                        TaskCategory = TaskCategory.Holidays; break;
                }
            } }
        public ObservableCollection<TaskChecklist> TaskChecklist { get; set; }
        public ICommand IAddNewTask => new RelayCommand(AddNewTask);

        private readonly TaskDataService _taskDataService;

        private ObservableCollection<Task> _tasks;

        public ObservableCollection<Task> Tasks { get { return _tasks; } set {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks)); } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TaskViewModel()
        {
            _taskDataService = new TaskDataService();
            TaskChecklist = new ObservableCollection<TaskChecklist>();
            DateTime = DateTime.Now;
        }

        public void LoadTasks()
        {
            var TaskList = _taskDataService.LoadTasks();
            Tasks = new ObservableCollection<Task>(TaskList);
        }

        public void AddNewTask()
        {
            Task newTask = new Task 
            {
                Name = this.Name, 
                Description = this.Description,
                Id = _taskDataService.GenerateNewTaskId(),
                DateTime = this.DateTime,
                IsCompleted = this.IsCompleted,
                StartDate = DateTime.Now,
                TaskCategory = this.TaskCategory,
                TaskChecklist = this.TaskChecklist,
                TaskPriority = TaskPriority.Medium,
                Timer = new TimeSpan(0),
            };

            _taskDataService.AddTask(newTask);
            ClearFields();
            LoadTasks();
            MainWindowViewModel.newTaskWindow.Close();
        }

        private void ClearFields()
        {
            Name = "";
            Description = "";
            TaskChecklist.Clear();
            UpdateForm();
        }

        private void UpdateForm()
        {
            OnPropertyChanged(Name);
            OnPropertyChanged(Description);
            OnPropertyChanged(nameof(TaskChecklist));
            OnPropertyChanged(nameof(TaskCategory));
        }

        public void UpdateTask(Task updateTask)
        {
            _taskDataService.UpdateTask(updateTask);
            LoadTasks();
        }

        public void DeleteTask(int taskId)
        {
            _taskDataService.DeleteTasks(taskId);
            LoadTasks();
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
