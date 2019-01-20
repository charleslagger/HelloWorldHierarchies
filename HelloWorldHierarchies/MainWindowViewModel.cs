using HelloWorldHierarchies.Helper;
using HelloWorldHierarchies.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldHierarchies
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private CustomerListViewModel customerListViewModel = new CustomerListViewModel();
        private OrderViewModel orderViewModel = new OrderViewModel();

        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public MyICommand<string> NavCommand
        {
            get;
            private set;
        }

        private void OnNav(string destination)
        {
            switch(destination)
            {
                case "orders":
                    CurrentViewModel = orderViewModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = customerListViewModel;
                    break;
            }
        }
    }
}
