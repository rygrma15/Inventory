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
        bool isFilled = false;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void move_Rectangle(object sender, MouseButtonEventArgs e)
        {
            int[,] pozice = new int[100,2];
            /*while (true)
            {*/
            if (_isRectDragInProg == false)
                {
                    _isRectDragInProg = true;
                    obj = sender as Rectangle;

                    //Console.WriteLine(obj.Name);
                    
                    obj.CaptureMouse();
                    



                    //Console.WriteLine(pocetradky);
                    //Console.WriteLine(pocetsloupce);


                }
                else if (_isRectDragInProg == true)
                {
                List<Pozice> fill = new List<Pozice>();
                List<Pozice> akt = new List<Pozice>();

                foreach (UIElement cell in grid.Children)
                    {
                    int x = Grid.GetColumn(cell);
                    //Console.WriteLine("Pozice-sloupec:" + x);
                    int y = Grid.GetRow(cell);
                    //Console.WriteLine("Pozice-radek:" + y);
                    int xa = Grid.GetColumnSpan(cell);
                    //Console.WriteLine("Delka-sloupec:" + xa);
                    int ya = Grid.GetRowSpan(cell);
                    //Console.WriteLine("Delka-radek:" + ya);


                    if (cell.GetValue(NameProperty).ToString() == obj.Name)
                        {
                            Console.WriteLine(cell.GetValue(NameProperty));
                            Console.WriteLine(obj.Name);
                        if (xa == 2)
                        {

                            akt.Add(new Pozice(x + 1, y));
                            akt.Add(new Pozice(x, y));
                        }
                        else
                        {
                            akt.Add(new Pozice(x, y));
                        }

                        if (ya == 2)
                        {
                            akt.Add(new Pozice(x, y + 1));
                            akt.Add(new Pozice(x, y));
                        }
                        else
                        {
                            akt.Add(new Pozice(x, y));
                        }

                    }
                        else
                        {
                            Console.WriteLine(cell.GetValue(NameProperty));
                        
                            
                            if (xa == 2)
                            {
                                
                                fill.Add(new Pozice(x + 1,y));
                                fill.Add(new Pozice(x,y));
                            }
                            else
                            {
                            fill.Add(new Pozice(x,y));
                            }

                            if (ya == 2)
                            {
                                fill.Add(new Pozice(x, y + 1));
                                fill.Add(new Pozice(x,y));
                            }
                            else
                            {
                                fill.Add(new Pozice(x,y));
                            }
                            
                        }
                    
                }
                foreach (var o in fill)
                {
                    Console.WriteLine(o.x+", "+o.y);
                }
                foreach (var d in akt)
                {
                    Console.WriteLine(d.x + ", " + d.y);
                }

                foreach(var o in akt)
                {
                    
                    foreach(var d in fill)
                    {
                        if (d.x == o.x && d.y == o.y)
                        {
                            isFilled = true;
                            Console.WriteLine(isFilled);
                        }
                        

                    }
                    
                }
                if (isFilled == true)
                {
                    _isRectDragInProg = true;
                    
                }
                else
                {
                    obj.ReleaseMouseCapture();
                    _isRectDragInProg = false;
                }
                isFilled = false;
                /*{



                    //break;
                }
                else
                {
                    obj.ReleaseMouseCapture();
                    _isRectDragInProg = false;
                    _isRectDragInProg = true;
                }*/

            }
            //}



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
            //Console.WriteLine(_isRectDragInProg);
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
