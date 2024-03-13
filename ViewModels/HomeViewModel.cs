using CHMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHMS.Resources;

namespace CHMS.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly TestModel _testModel;
        public string Example
        {
            get { return _testModel.Name; }
            set { _testModel.Name = value; OnPropertyChanged(); }
        }

        public HomeViewModel()
        {
            _testModel = new TestModel();
            Example = "HOMEEE";
        }
    }
}
