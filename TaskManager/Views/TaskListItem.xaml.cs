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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Models;
using TaskManager.ViewModel;

namespace TaskManager.Views
{
    /// <summary>
    /// Логика взаимодействия для TaskListItem.xaml
    /// </summary>
    public partial class TaskListItem : UserControl
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public string TaskCategoryS { get { return nameof(TaskCategory); } set { TaskCategoryS = value.ToString(); } }
        public bool IsCompleted { get; set; }
        public ObservableCollection<TaskChecklist> TaskChecklist { get; set; }


        public TaskListItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
