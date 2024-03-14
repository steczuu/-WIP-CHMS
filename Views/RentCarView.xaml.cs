using System;
using System.Collections.Generic;
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
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using CHMS.Models;
using System.Runtime.ConstrainedExecution;

namespace CHMS.Views
{
    /// <summary>
    /// Logika interakcji dla klasy RentCarView.xaml
    /// </summary>
    public partial class RentCarView : UserControl
    {
        private readonly ClientModelContext clientModelContext = new ClientModelContext();
        private readonly CarModelContext carModelContext = new CarModelContext();   
        private CollectionViewSource availableCarsViewSrc;
        private CollectionViewSource rentCarsClientSrc;

        public RentCarView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            availableCarsViewSrc = (CollectionViewSource)FindResource(nameof(availableCarsViewSrc));
            rentCarsClientSrc = (CollectionViewSource)FindResource(nameof (rentCarsClientSrc));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            carModelContext.Database.EnsureCreated();
            carModelContext.Cars.Load();

            clientModelContext.Database.EnsureCreated();
            clientModelContext.Clients.Load();

            rentCarsClientSrc.Source = clientModelContext.Clients.Local.ToObservableCollection();
            availableCarsViewSrc.Source = carModelContext.Cars.Local.ToObservableCollection();
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            int loanPeriodInput = Convert.ToInt32(LoanPeriodTxt.Text);
            int _totalCost = loanPeriodInput;

            var client = new ClientModel
            {
                Name = NameTxt.Text,
                Surname = SurnameTxt.Text,
                PhoneNumber = PhoneTxt.Text,
                Email = EmailTxt.Text,
                LoanPeriod = _totalCost
            };

            clientModelContext.Clients.Add(client);
            clientModelContext.SaveChanges();
            ClientsDataGrid.Items.Refresh();
        }

        private void SaveClient(object sender, RoutedEventArgs e)
        {
            clientModelContext.SaveChanges();
        }

    }
}
