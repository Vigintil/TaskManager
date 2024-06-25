using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.ViewModel;

namespace TaskManager.Views
{
    /// <summary>
    /// Логика взаимодействия для TaskChecklistItem.xaml
    /// </summary>
    public partial class TaskChecklistItem : UserControl
    {
        public TaskChecklistItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public int Id { get; set; }
        public int LocalId { get; set; }
        private TaskViewModel viewModel = new TaskViewModel();

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            viewModel.LoadTasks();
            for (int i = 0; i < viewModel.Tasks.Count; i++)
            {
                if (viewModel.Tasks[i].Id == Id)
                {
                    IsComplete = true;
                    viewModel.Tasks[i].TaskChecklist[LocalId].IsComplete = true;
                    viewModel.UpdateTask(viewModel.Tasks[i]);
                    taskChecklistLabel.TextDecorations = TextDecorations.Strikethrough;
                    taskChecklistLabel.Foreground = Brushes.Gray;
                    break;
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            viewModel.LoadTasks();
            for (int i = 0; i < viewModel.Tasks.Count; i++)
            {
                if (viewModel.Tasks[i].Id == Id)
                {
                    IsComplete = false;
                    viewModel.Tasks[i].TaskChecklist[LocalId].IsComplete = false;
                    viewModel.UpdateTask(viewModel.Tasks[i]);
                    taskChecklistLabel.TextDecorations = TextDecorations.Baseline;
                    taskChecklistLabel.Foreground = Brushes.Black;
                    break;
                }
            }
        }
    }
}
