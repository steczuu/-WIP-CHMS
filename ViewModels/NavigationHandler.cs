using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CHMS.Resources;

namespace CHMS.ViewModels
{
    public class NavigationHandler: ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand AvailableCarsCommand { get; set; }
        public ICommand RentInfoCommand { get; set; }
        public ICommand RentCarCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void AvailableCars(object obj) => CurrentView = new AvailableCarsVM();
        private void RentInfo(object obj) => CurrentView = new RentedCarsVM();
        private void RentCar(object obj) => CurrentView = new RentCarVM();

        public NavigationHandler() { 
            HomeCommand = new RelayCommand(Home);
            AvailableCarsCommand = new RelayCommand(AvailableCars);
            RentInfoCommand = new RelayCommand(RentInfo);
            RentCarCommand = new RelayCommand(RentCar);

            CurrentView = new HomeViewModel();
        }

    }
}
