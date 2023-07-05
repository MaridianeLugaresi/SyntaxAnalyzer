using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SyntaxAnalyzer.Objects
{
    public class Message
    {
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Configuration", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}