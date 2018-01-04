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

namespace Inventar
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle obj;
        private bool _isRectDragInProg;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = true;
            obj = sender as Rectangle;
            
            obj.CaptureMouse();
        }

        private void rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = false;
            obj.ReleaseMouseCapture();
        }

        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isRectDragInProg) return;
            // get the position of the mouse relative to the Canvas
            var mousePos = e.GetPosition(grid);
            double left;
            double top;
            // center the rect on the mouse
            if (mousePos.X < 0)
            {
                left = 0;
            }
            else if (mousePos.X > 450)
            {
                left = 8; 
            }
            else
            {
                left = mousePos.X / 50;
            }

            if (mousePos.Y < 0)
            {
                top = 0;
            }
            else if (mousePos.Y > 250)
            {
                top = 4;
            }
            else
            {
                top = mousePos.Y / 50;
            } 

            int collum = (int)left;
            if (Grid.GetColumnSpan(obj) == 2 && collum == 8)
            {
                collum = collum - 1;
            }
            int row = (int)top;
            if (Grid.GetRowSpan(obj) == 2 && row == 4)
            {
                row = row - 1;
            }
            Grid.SetColumn(obj, collum);
            Grid.SetRow(obj, row);

             

            
        }
    }
}
