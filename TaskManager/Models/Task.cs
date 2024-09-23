using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskManager.Models;

namespace TaskManager.Models
{
    public class Task
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
        public ObservableCollection<TaskChecklist> TaskChecklist { get; set; }
    }

    

    public enum TaskCategory
    {

        Work,

        Personal,

        Home,

        Health,

        Finance,

        Shopping,

        Social,

        Education,

        Walks,

        Hobbies,

        Birthdates,

        Projects,

        LongTermGoals,

        Ideas,

        Games,

        Holidays
    }

    public enum TaskPriority
    {

        None,

        Low,

        Medium,

        High,

        Critical
    }
}
