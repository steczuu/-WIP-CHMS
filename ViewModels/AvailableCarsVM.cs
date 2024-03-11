using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHMS.Models;
using CHMS.Resources;

namespace CHMS.ViewModels
{
    class AvailableCarsVM : ViewModelBase
    {
        private readonly TestModel _testModel;
        public int CarId 
        {
            get { return _testModel.Id; }
            set { _testModel.Id = value; OnPropertyChanged();} 
        }

        public AvailableCarsVM()
        {
            _testModel = new TestModel();
            CarId = 16486;
        }
    }
}
