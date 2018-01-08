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
        private bool _isRectDragInProg = false;
        int row;
        int collum;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void move_Rectangle(object sender, MouseButtonEventArgs e)
        {

            List<int> rows = new List<int>();
            List<int> columns = new List<int>();
            if (_isRectDragInProg == false)
            {
                
                obj = sender as Rectangle;

                Console.WriteLine(obj.Name);
                obj.CaptureMouse();
                _isRectDragInProg = true;

                foreach (UIElement cell in grid.Children)
                {
                    

                    int x = Grid.GetColumn(cell);
                    int y = Grid.GetRow(cell);
                    int xa = Grid.GetColumnSpan(cell);
                    int ya = Grid.GetRowSpan(cell);

                    if (xa > 1)
                    {
                        columns.Add(x + 1);
                        columns.Add(x);
                    }
                    else
                    {
                        columns.Add(x);
                    }

                    if (ya > 1)
                    {
                        rows.Add(y + 1);
                        rows.Add(y);
                    }
                    else
                    {
                        rows.Add(y);
                    }
                }
                int pocetradky = rows.Where(temp => temp.Equals(row))
                        .Select(temp => temp)
                        .Count();
                int pocetsloupce = columns.Where(temp => temp.Equals(collum))
                        .Select(temp => temp)
                        .Count();

                //Console.WriteLine(pocetradky);
                //Console.WriteLine(pocetsloupce);
                Console.WriteLine(pocetsloupce + pocetradky);
                if ((pocetsloupce + pocetradky) < 4)
                {
                    obj.ReleaseMouseCapture();


                    //_isRectDragInProg = false;
                }
                else
                {
                    _isRectDragInProg = true;
                }
                
            }


        }


        /*private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = true;
            obj = sender as Rectangle;
            obj.CaptureMouse();
            
        }

        private void rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = false;
            obj.ReleaseMouseCapture();
        }*/

        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine(_isRectDragInProg);
            if (_isRectDragInProg == true)
            {
                var mousePos = e.GetPosition(grid);
                double left;
                double top;
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

                collum = (int)left;
                if (Grid.GetColumnSpan(obj) == 2 && collum == 8)
                {
                    collum = collum - 1;
                }
                row = (int)top;
                if (Grid.GetRowSpan(obj) == 2 && row == 4)
                {
                    row = row - 1;
                }


                Grid.SetColumn(obj, collum);
                Grid.SetRow(obj, row);
            }
            


             

            
        }
    }
}
