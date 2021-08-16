using System.Windows.Controls;

namespace toDo
{
    /// <summary>
    /// Interaction logic for WTasksPage.xaml
    /// </summary>
    public partial class WTasksPage : Page
    {
        public WTasksPage()
        {
            InitializeComponent();

            DataContext = new WTasksPageViewModel();
        }

    }
}
