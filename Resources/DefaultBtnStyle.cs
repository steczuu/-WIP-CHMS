using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CHMS.Resources
{
    public class DefaultBtnStyle : RadioButton
    {
        static DefaultBtnStyle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DefaultBtnStyle), new FrameworkPropertyMetadata(typeof(DefaultBtnStyle)));
        }
    }
}
