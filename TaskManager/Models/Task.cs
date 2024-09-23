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
        /// <summary>
        /// Работа, рабочие задачи
        /// </summary>
        Work,
        /// <summary>
        /// Личное, личные дела
        /// </summary>
        Personal,
        /// <summary>
        /// Домашние дела, рутины
        /// </summary>
        Home,
        /// <summary>
        /// Здоровье, упражнения
        /// </summary>
        Health,
        /// <summary>
        /// Финансы, денежные дела, оплаты
        /// </summary>
        Finance,
        /// <summary>
        /// Покупки, список покупок
        /// </summary>
        Shopping,
        /// <summary>
        /// Социальные мероприятия, встречи
        /// </summary>
        Social,
        /// <summary>
        /// Обучение, саморазвитие
        /// </summary>
        Education,
        /// <summary>
        /// Прогулки, походы
        /// </summary>
        Walks,
        /// <summary>
        /// Хобби, увлечения
        /// </summary>
        Hobbies,
        /// <summary>
        /// Дни рождения, годовщины
        /// </summary>
        Birthdates,
        /// <summary>
        /// Проекты
        /// </summary>
        Projects,
        /// <summary>
        /// Долгосрочные планы, общие задачи
        /// </summary>
        LongTermGoals,
        /// <summary>
        /// Идеи, вдохновения
        /// </summary>
        Ideas,
        /// <summary>
        /// Игры
        /// </summary>
        Games,
        /// <summary>
        /// Праздники
        /// </summary>
        Holidays
    }

    public enum TaskPriority
    {
        /// <summary>
        /// Нет приоритета
        /// </summary>
        None,
        /// <summary>
        /// Низкий приоритет, маловажные задачи
        /// </summary>
        Low,
        /// <summary>
        /// Средний приоритет, стандартые задачи, планы средней важности
        /// </summary>
        Medium,
        /// <summary>
        /// Высокий приоритет, важные задачи
        /// </summary>
        High,
        /// <summary>
        /// Критический приоритет, задачи требующие немедленного выполнения
        /// </summary>
        Critical
    }
}
