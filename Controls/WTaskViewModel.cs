using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using toDo.Base;

namespace toDo 
{
    class WTaskViewModel: BaseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime createDateTime { get; set; }

        public bool IsSelected { get; set; }
    }
}
