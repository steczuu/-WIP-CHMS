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
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace CHMS.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AvailableCarsView.xaml
    /// </summary>
    public partial class AvailableCarsView : UserControl
    {
        private readonly CarModelContext carModelContext = new CarModelContext();
        private CollectionViewSource availableCarsViewSrc;
        public float _cost;

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

        public void LoadData(CarModel carModel)
        {
            carModelContext.Add(carModel);
            carModelContext.SaveChanges();
            CarsDataGrid.Items.Refresh();
        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            try
            {
                _cost = (float)Convert.ToDouble(CarCostTxt.Text);
            }

            catch
            {
                MessageBox.Show("Invalid input or white space.");
            }

            var car = new CarModel 
            { 
                CarColor = CarColorTxt.Text, 
                CarGearboxType = CarGearboxTxt.Text,
                CarMake = CarMakeTxt.Text,
                CarType = CarTypeTxt.Text,
                Car_Model = CarModelTxt.Text,
                Cost = _cost   
            };

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

        private void CarsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            bool isInvalid = false;
            
            if (CarsDataGrid.SelectedItem != null && NameTxt.Text != null && SurnameTxt.Text != null && LoanPeriodTxt.Text != null)
            {
                
               CarModel selectedCar = (CarModel)CarsDataGrid.SelectedItem;


                RentedCarModel rentedCar = new RentedCarModel
                {
                    RentedCarMake = selectedCar.CarMake,
                    RentedCar_Model = selectedCar.Car_Model,
                    RentedCarType = selectedCar.CarType,
                    RentedCarColor = selectedCar.CarColor,
                    RentedCarGearboxType = selectedCar.CarGearboxType,
                    RentedCost = selectedCar.Cost,
                    RentedDate = DateTime.Now
                };

                rentedCar.Name = NameTxt.Text;
                rentedCar.Surname = SurnameTxt.Text;
                try
                {
                    rentedCar.LoanPeriod = int.Parse(LoanPeriodTxt.Text);
                }

                catch
                {
                    MessageBox.Show("Invalid input or white space.");
                    isInvalid = true;
                }

                if (!isInvalid)
                {
                    carModelContext.Cars.Remove(selectedCar);

                    carModelContext.SaveChanges();
                    CarsDataGrid.Items.Refresh();

                    RentedCarsView rentedCarsView = new RentedCarsView();
                    rentedCarsView.LoadData(rentedCar);
                    rentedCarsView.RentedCarsDataGrid.Items.Refresh();
                }

                NameTxt.Clear();
                SurnameTxt.Clear();
                LoanPeriodTxt.Clear();
            }
            else
            {
                MessageBox.Show("Please, fill the client form!");
            }
        }

        private void LoanPeriodTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
