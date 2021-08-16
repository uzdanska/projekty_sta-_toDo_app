using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Map;
using toDo.Base;

namespace toDo
{
    class WTasksPageViewModel : BaseViewModel
    {
        public System.Windows.Media.ImageSource Source { get; set; }
        
        RadDateTimePicker radDateTimePicker = new RadDateTimePicker();
        //ObservableCollection dziala jak lista tylko poinformuje jak o się w iej zmieni
        public ObservableCollection<WTaskViewModel> WTaskList { get; set; } = new ObservableCollection<WTaskViewModel>(); // BO NIE MOZNA DODAC DO LISTY NULL WIEC REZERWUJEMY MIEJSCE
        public string AddNewTitle { get; set; }
        public string AddNewDescription { get; set; }
        public ICommand AddNewTaskCommand { get; set; }
        public ICommand DeleteTaskCommand { get; set; }
        public ICommand EditTaskCommand { get; set; }
        
        public WTasksPageViewModel()
        {
            AddNewTaskCommand = new RelayCommand(AddNewTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
            EditTaskCommand = new RelayCommand(EditTask);
        }
        /*public static bool Find(ObservableCollection<WTaskViewModel> Lista, WTaskViewModel task)
        {
            return Lista.Contains(task);
        }*/
        private void AddNewTask()
        {
            var newTask = new WTaskViewModel
            {
                Title = AddNewTitle,
                Description = AddNewDescription,
                createDateTime = DateTime.Now
            };
            WTaskList.Add(newTask);
            AddNewTitle = string.Empty;
            AddNewDescription = string.Empty;

            OnPropertyChanged(nameof(AddNewTitle));
            OnPropertyChanged(nameof(AddNewDescription));
        }
        private void DeleteTask()
        {
            var selectedTask = WTaskList.Where(x => x.IsSelected).ToList(); // ToList() robi kopie
            foreach (var task in selectedTask)
            {
               WTaskList.Remove(task);
            }
          
        }
        private void EditTask()
        {
            var newTask = new WTaskViewModel
            {
                Title = AddNewTitle,
                Description = AddNewDescription,
                createDateTime = DateTime.Now
            };
            var selectedTask = WTaskList.Where(x => x.IsSelected).ToList();
            foreach (var task in selectedTask)
            { 
                int index = WTaskList.IndexOf(task);
                WTaskList.Remove(task);
                WTaskList.Insert(index, newTask);
            }
            
            AddNewTitle = string.Empty;
            AddNewDescription = string.Empty;

            OnPropertyChanged(nameof(AddNewTitle));
            OnPropertyChanged(nameof(AddNewDescription));
        }
        
    }
}
