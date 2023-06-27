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
using WpfAppForManagers1._0.ViewModels;

namespace WpfAppForManagers1._0.Views
{
    /// <summary>
    /// Логика взаимодействия для MainViewModel.xaml
    /// </summary>
    public partial class MainViewModel : UserControl
    {
        public MainViewModel()
        {
            InitializeComponent();
            jobs = new ObservableCollection<JobViewModel>();
            jobs.Add(new JobViewModel(new() { Id = 1, ClientId = 1, MechanicId = 1, ModelId = 1, ManagerId = 1, Status = "pending", Description = "blablabla", Price = 123, FinishDate = DateTime.Now, IssueDate = DateTime.Now }));
            DataContext = jobs;
        }

        
        public readonly ObservableCollection<JobViewModel> jobs;

        public IEnumerable<JobViewModel> jobViewModels => jobs;
    }
}
