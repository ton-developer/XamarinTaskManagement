using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskManagement.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewMaster : ContentPage
    {
        public Xamarin.Forms.ListView ListView;

        public MainViewMaster()
        {
            InitializeComponent();

            BindingContext = new MainViewMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainViewMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainViewMenuItem> MenuItems { get; set; }

            public MainViewMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainViewMenuItem>(new[]
                {
                    new MainViewMenuItem { Id = 0, Title = "Add Task", TargetType = typeof(AddTaskView)},
                    new MainViewMenuItem { Id = 1, Title = "Pending Tasks", TargetType = typeof(PendingTaskView) },
                    new MainViewMenuItem { Id = 2, Title = "OnGoing Tasks", TargetType = typeof(OnGoingTaskView) },
                    new MainViewMenuItem { Id = 3, Title = "Finished Tasks", TargetType = typeof(FinishedTaskView) },
                    new MainViewMenuItem { Id = 3, Title = "All Tasks", TargetType = typeof(AllTaskView) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}