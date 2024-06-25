using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.ViewModel;
using TaskManager.Views;
using TaskManager;
using Newtonsoft.Json.Linq;
using TaskManager.Models;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TaskListItem[] Items { get; set; }
        private TaskViewModel viewModel = new TaskViewModel();
        public TaskChecklistItem[] CheckItems { get; set; }

        public Task EditTask { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new TaskViewModel();
            taskListView.DataContext = this;
            checkListView.DataContext = this;
        }

        public void PopulateItems()
        {
            viewModel = new TaskViewModel();
            taskListView.Items.Clear();
            viewModel.LoadTasks();
            //taskListView = new ListView();
            Items = new TaskListItem[viewModel.Tasks.Count];
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = new TaskListItem();
                Items[i].Id = viewModel.Tasks[i].Id;
                Items[i].Title = viewModel.Tasks[i].Name;
                Items[i].Description = viewModel.Tasks[i].Description;
                Items[i].TaskCategory = viewModel.Tasks[i].TaskCategory;
                Items[i].IsCompleted = viewModel.Tasks[i].IsCompleted;
                Items[i].TaskChecklist = viewModel.Tasks[i].TaskChecklist;
                if (Items[i].IsCompleted) 
                {
                    Items[i].taskDescriptionText.TextDecorations = TextDecorations.Strikethrough;
                    Items[i].taskTitleText.TextDecorations = TextDecorations.Strikethrough;
                    Items[i].Background = Brushes.LightGray;
                    Items[i].borderTaskCathegory.Background = Brushes.LightGray;
                }
                switch (Items[i].TaskCategory)
                {
                    case TaskCategory.Work:
                        Items[i].borderTaskCathegory.Background = Brushes.Red; Items[i].textTaskListItemCathegory.Text = "Работа"; break;
                    case TaskCategory.Personal:
                        Items[i].borderTaskCathegory.Background = Brushes.LightBlue; Items[i].textTaskListItemCathegory.Text = "Личное"; break;
                    case TaskCategory.Home:
                        Items[i].borderTaskCathegory.Background = Brushes.Gray; Items[i].textTaskListItemCathegory.Text = "Дом"; break;
                    case TaskCategory.Health:
                        Items[i].borderTaskCathegory.Background = Brushes.Pink; Items[i].textTaskListItemCathegory.Text = "Здоровье"; break;
                    case TaskCategory.Finance:
                        Items[i].borderTaskCathegory.Background = Brushes.LightGreen; Items[i].textTaskListItemCathegory.Text = "Финансы"; break;
                    case TaskCategory.Shopping:
                        Items[i].borderTaskCathegory.Background = Brushes.Green; Items[i].textTaskListItemCathegory.Text = "Покупки"; break;
                    case TaskCategory.Social:
                        Items[i].borderTaskCathegory.Background = Brushes.MediumBlue; Items[i].textTaskListItemCathegory.Text = "Социальное"; break;
                    case TaskCategory.Education:
                        Items[i].borderTaskCathegory.Background = Brushes.Cyan; Items[i].textTaskListItemCathegory.Text = "Обучение"; break;
                    case TaskCategory.Walks:
                        Items[i].borderTaskCathegory.Background = Brushes.Yellow; Items[i].textTaskListItemCathegory.Text = "Прогулки"; break;
                    case TaskCategory.Hobbies:
                        Items[i].borderTaskCathegory.Background = Brushes.ForestGreen; Items[i].textTaskListItemCathegory.Text = "Хобби"; break;
                    case TaskCategory.Birthdates:
                        Items[i].borderTaskCathegory.Background = Brushes.Snow; Items[i].textTaskListItemCathegory.Text = "Дни рождения"; break;
                    case TaskCategory.Projects:
                        Items[i].borderTaskCathegory.Background = Brushes.Brown; Items[i].textTaskListItemCathegory.Text = "Проекты"; break;
                    case TaskCategory.LongTermGoals:
                        Items[i].borderTaskCathegory.Background = Brushes.Goldenrod; Items[i].textTaskListItemCathegory.Text = "Долгосрочные планы"; break;
                    case TaskCategory.Ideas:
                        Items[i].borderTaskCathegory.Background = Brushes.LightYellow; Items[i].textTaskListItemCathegory.Text = "Идеи"; break;
                    case TaskCategory.Games:
                        Items[i].borderTaskCathegory.Background = Brushes.Violet; Items[i].textTaskListItemCathegory.Text = "Игры"; break;
                    case TaskCategory.Holidays:
                        Items[i].borderTaskCathegory.Background = Brushes.Orange; Items[i].textTaskListItemCathegory.Text = "Праздники"; break;
                }

                taskListView.Items.Add(Items[i]);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateItems();
        }

        private void ListView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void taskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                selectedTaskTitle.Text = Items[taskListView.SelectedIndex].Title;
                selectedTaskDescription.Text = Items[taskListView.SelectedIndex].Description;
                selectedTaskCathegory.Text = Items[taskListView.SelectedIndex].TaskCategory.ToString();
                switch (Items[taskListView.SelectedIndex].TaskCategory)
                {
                    case TaskCategory.Work:
                        selectedTaskCathegoryBorder.Background = Brushes.Red; selectedTaskCathegory.Text = "Работа"; break;
                    case TaskCategory.Personal:
                        selectedTaskCathegoryBorder.Background = Brushes.LightBlue; selectedTaskCathegory.Text = "Личное"; break;
                    case TaskCategory.Home:
                        selectedTaskCathegoryBorder.Background = Brushes.Gray; selectedTaskCathegory.Text = "Дом"; break;
                    case TaskCategory.Health:
                        selectedTaskCathegoryBorder.Background = Brushes.Pink; selectedTaskCathegory.Text = "Здоровье"; break;
                    case TaskCategory.Finance:
                        selectedTaskCathegoryBorder.Background = Brushes.LightGreen; selectedTaskCathegory.Text = "Финансы"; break;
                    case TaskCategory.Shopping:
                        selectedTaskCathegoryBorder.Background = Brushes.Green; selectedTaskCathegory.Text = "Покупки"; break;
                    case TaskCategory.Social:
                        selectedTaskCathegoryBorder.Background = Brushes.MediumBlue; selectedTaskCathegory.Text = "Социальное"; break;
                    case TaskCategory.Education:
                        selectedTaskCathegoryBorder.Background = Brushes.Cyan; selectedTaskCathegory.Text = "Обучение"; break;
                    case TaskCategory.Walks:
                        selectedTaskCathegoryBorder.Background = Brushes.Yellow; selectedTaskCathegory.Text = "Прогулки"; break;
                    case TaskCategory.Hobbies:
                        selectedTaskCathegoryBorder.Background = Brushes.ForestGreen; selectedTaskCathegory.Text = "Хобби"; break;
                    case TaskCategory.Birthdates:
                        selectedTaskCathegoryBorder.Background = Brushes.Snow; selectedTaskCathegory.Text = "День рождения"; break;
                    case TaskCategory.Projects:
                        selectedTaskCathegoryBorder.Background = Brushes.Brown; selectedTaskCathegory.Text = "Проекты"; break;
                    case TaskCategory.LongTermGoals:
                        selectedTaskCathegoryBorder.Background = Brushes.Goldenrod; selectedTaskCathegory.Text = "Долгосрочные планы"; break;
                    case TaskCategory.Ideas:
                        selectedTaskCathegoryBorder.Background = Brushes.LightYellow; selectedTaskCathegory.Text = "Идеи"; break;
                    case TaskCategory.Games:
                        selectedTaskCathegoryBorder.Background = Brushes.Violet; selectedTaskCathegory.Text = "Игры"; break;
                    case TaskCategory.Holidays:
                        selectedTaskCathegoryBorder.Background = Brushes.Orange; selectedTaskCathegory.Text = "Праздники"; break;
                }

                viewModel.LoadTasks();
                checkListView.Items.Clear();
                int localId = 0;
                int taskI = -1;
                for (int i = 0; i < viewModel.Tasks.Count; i++)
                {
                    if (viewModel.Tasks[i].Id == Items[taskListView.SelectedIndex].Id)
                    {
                        taskI = i;
                        break;
                    }
                }

                CheckItems = new TaskChecklistItem[viewModel.Tasks[taskI].TaskChecklist.Count];

                for (int i = 0; i < viewModel.Tasks[taskI].TaskChecklist.Count; i++)
                {
                    CheckItems[i] = new TaskChecklistItem();
                    CheckItems[i].Description = viewModel.Tasks[taskI].TaskChecklist[i].Description;
                    CheckItems[i].IsComplete = viewModel.Tasks[taskI].TaskChecklist[i].IsComplete;

                    CheckItems[i].Id = Items[taskListView.SelectedIndex].Id;
                    CheckItems[i].LocalId = localId;
                    localId++;
                    if (CheckItems[i].IsComplete)
                    {
                        CheckItems[i].taskChecklistLabel.TextDecorations = TextDecorations.Strikethrough;
                        CheckItems[i].taskChecklistLabel.Foreground = Brushes.Gray;
                    }
                    checkListView.Items.Add(CheckItems[i]);
                }
            }
            catch (Exception)
            {
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.LoadTasks();
            for (int i = 0; i < viewModel.Tasks.Count; i++)
            {
                if (viewModel.Tasks[i].Id == Items[taskListView.SelectedIndex].Id)
                {
                    viewModel.Tasks[i].IsCompleted = !viewModel.Tasks[i].IsCompleted;
                    viewModel.UpdateTask(viewModel.Tasks[i]);
                    break;
                }
            }
            PopulateItems();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewModel.LoadTasks();
            for (int i = 0; i < viewModel.Tasks.Count; i++)
            {
                if (viewModel.Tasks[i].Id == Items[taskListView.SelectedIndex].Id)
                {
                    viewModel.DeleteTask(viewModel.Tasks[i].Id);
                    break;
                }
            }

            PopulateItems();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            viewModel.LoadTasks();

            for (int i = 0; i < viewModel.Tasks.Count; i++)
            {
                if (viewModel.Tasks[i].Id == Items[taskListView.SelectedIndex].Id)
                {
                    EditTask = viewModel.Tasks[i];
                    break;
                }
            }

            EditTaskWindow editTaskWindow = new EditTaskWindow();
            editTaskWindow.Show();
            editTaskWindow.editTaskWindowTitle.Text = Items[taskListView.SelectedIndex].Title;
            editTaskWindow.editTaskWindowDescription.Text = Items[taskListView.SelectedIndex].Description;
            editTaskWindow.cathegorySelection.SelectedItem = Items[taskListView.SelectedIndex].textTaskListItemCathegory;



            for (int i = 0; i < Items[taskListView.SelectedIndex].TaskChecklist.Count; i++)
            {
                editTaskWindow.listSubtasks.Items.Add(Items[taskListView.SelectedIndex].TaskChecklist[i].Description);
            }
            
        }
    }
}
