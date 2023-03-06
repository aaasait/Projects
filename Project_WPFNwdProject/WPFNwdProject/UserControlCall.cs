using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFNwdProject
{
    public class UserControlCall
    {
        public static void UCCall(StackPanel stPanel,UserControl uc)
        {

            if (stPanel.Children.Count > 0)
            {
                stPanel.Children.Clear();
                stPanel.Children.Add(uc);
            }
            else
            {
                stPanel.Children.Clear();
                stPanel.Children.Add(uc);
            }
        }
    }
}
