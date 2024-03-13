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

namespace CHMS.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AvailableCarsView.xaml
    /// </summary>
    public partial class AvailableCarsView : UserControl
    {
        private readonly CarModelContext carModelContext = new CarModelContext();
        private CollectionViewSource availableCarsViewSrc;

        public AvailableCarsView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
            availableCarsViewSrc = (CollectionViewSource)FindResource(nameof(availableCarsViewSrc));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            carModelContext.Database.EnsureCreated();   
            carModelContext.Cars.Load();
            

            availableCarsViewSrc.Source = carModelContext.Cars.Local.ToObservableCollection();
        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            float _cost = (float)Convert.ToDouble(CarCostTxt.Text);

            var car = new CarModel { CarColor = CarColorTxt.Text, 
                                     CarGearboxType = CarGearboxTxt.Text,
                                     CarMake = CarMakeTxt.Text,
                                     CarType = CarTypeTxt.Text,
                                     Car_Model = CarModelTxt.Text,
                                     Cost = _cost};

            carModelContext.Cars.Add(car);
            carModelContext.SaveChanges();  
            CarsDataGrid.Items.Refresh();


            CarColorTxt.Clear();
            CarGearboxTxt.Clear();
            CarMakeTxt.Clear();
            CarTypeTxt.Clear(); 
            CarModelTxt.Clear();
            CarCostTxt.Clear(); 
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            carModelContext.SaveChanges();
            CarsDataGrid.Items.Refresh();
        }
    }
}
