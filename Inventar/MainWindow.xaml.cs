using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.IO;


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
        Rectangle imgbg = new Rectangle();
        

        public MainWindow()
        {

            InitializeComponent();
            posLoad();
            this.Closing += MainWindow_Closing;


        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            posSave();
        }

        private void move_Rectangle(object sender, MouseButtonEventArgs e)
        {

            if (_isRectDragInProg == false)
            {
                _isRectDragInProg = true;
                obj = sender as Rectangle;
                Panel.SetZIndex(obj, 100);
                imgbgAtr(obj);
                grid.Children.Add(imgbg);



                /*string plus = "drag";
                string path = @"C:\Users\Alena\Desktop\Nová složka\"+imgFile+"_" + plus + ".png";
                obj.Fill = new ImageBrush(new BitmapImage(
                new Uri(path, UriKind.Relative)));*/

                obj.CaptureMouse();

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

                    //Console.WriteLine("vybraný objekt: " + obj.Name);
                    if (cell.GetValue(NameProperty).ToString() == obj.Name)
                    {
                        //Console.WriteLine("bunka a objekt se shoduji");
                        //Console.WriteLine("cyklus bunkou: " + cell.GetValue(NameProperty));
                        //Console.WriteLine(cell.GetValue(NameProperty));
                        //Console.WriteLine(obj.Name);
                        for (int ctrColumn = x; ctrColumn < x + xa; ctrColumn++)
                        {
                            akt.Add(new Pozice(ctrColumn, y, cell.GetValue(NameProperty).ToString()));

                            //Console.WriteLine(ctrColumn + "; "+ y);
                            for (int ctrRow = y; ctrRow < y + ya; ctrRow++)
                            {

                                akt.Add(new Pozice(ctrColumn, ctrRow, cell.GetValue(NameProperty).ToString()));

                                //Console.WriteLine(ctrColumn + "; " + ctrRow);

                            }
                        }




                        /*if (xa == 2)
                        {

                            akt.Add(new Pozice(x + 1, y));

                        }
                        else
                        {
                            akt.Add(new Pozice(x, y));
                        }*/

                        /*if (ya == 2)
                        {
                            akt.Add(new Pozice(x, y + 1));
                            akt.Add(new Pozice(x, y));
                        }
                        else
                        {
                            akt.Add(new Pozice(x, y));
                        }*/

                    }
                    else if (cell.GetValue(NameProperty).ToString() == imgbg.Name)
                    {

                    }
                    else
                    {
                        //Console.WriteLine("cyklus bunkou: "+cell.GetValue(NameProperty));

                        for (int ctrColumn = x; ctrColumn < x + xa; ctrColumn++)
                        {
                            fill.Add(new Pozice(ctrColumn, y, cell.GetValue(NameProperty).ToString()));

                            //Console.WriteLine(op + "; " + y);
                            for (int ctrRow = y; ctrRow < y + ya; ctrRow++)
                            {
                                fill.Add(new Pozice(ctrColumn, ctrRow, cell.GetValue(NameProperty).ToString()));

                                //Console.WriteLine(ctrColumn + "; " + xd);
                            }
                        }
                    }


                    /*if (xa == 2)
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
                    }*/
                }




                /*foreach (var o in fill)
                {
                    Console.WriteLine(o.x + ", " + o.y + " - "+o.name);
                }

                foreach (var d in akt)
                {
                    Console.WriteLine("*"+d.x + ", " + d.y + " - " + d.name);
                }*/

                foreach (var o in akt)
                {

                    foreach (var d in fill)
                    {

                        if (d.x == o.x && d.y == o.y)
                        {

                            isFilled = true;


                        }


                    }

                }
                if (isFilled == true)
                {
                    /*string plus = "wrong";
                    string path = @"C:\Users\Alena\Desktop\Nová složka\" + imgFile + "_" + plus + ".png";
                    obj.Fill = new ImageBrush(new BitmapImage(
                    new Uri(path, UriKind.Relative)));*/
                    imgbg.Fill = Brushes.Red;
                    _isRectDragInProg = true;
                    isFilled = false;

                }
                else
                {

                    /*string plus = "def";
                    string path = @"C:\Users\Alena\Desktop\Nová složka\" + imgFile + "_" + plus + ".png";
                    obj.Fill = new ImageBrush(new BitmapImage(
                    new Uri(path, UriKind.Relative)));*/

                    obj.ReleaseMouseCapture();

                    Panel.SetZIndex(obj, 0);
                    grid.Children.Remove(imgbg);
                    _isRectDragInProg = false;

                }
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

        }

        private void rect_MouseMove(object sender, MouseEventArgs e)
        {

            if (_isRectDragInProg == true)
            {
                /*string plus = "drag";
                string path = @"C:\Users\Alena\Desktop\Nová složka\" + imgFile + "_" + plus + ".png";
                obj.Fill = new ImageBrush(new BitmapImage(
                new Uri(path, UriKind.Relative)));*/
                var mousePos = e.GetPosition(grid);
                imgbg.Fill = Brushes.CadetBlue;
                double left;
                double top;

                if (mousePos.X < 0)
                {
                    left = 0;
                }
                else if (mousePos.X > (grid.ColumnDefinitions.Count() * 50) - (Grid.GetColumnSpan(obj) * 50))
                {
                    left = grid.ColumnDefinitions.Count - Grid.GetColumnSpan(obj);
                }
                else
                {
                    left = mousePos.X / 50;
                }

                if (mousePos.Y < 0)
                {
                    top = 0;
                }
                else if (mousePos.Y > (grid.RowDefinitions.Count() * 50) - (Grid.GetRowSpan(obj) * 50))
                {
                    top = grid.RowDefinitions.Count() - Grid.GetRowSpan(obj);
                }
                else
                {
                    top = mousePos.Y / 50;
                }

                collum = (int)left;
                row = (int)top;
                /*if (Grid.GetColumnSpan(obj) == 2 && collum == 8)
                {
                    collum = collum - 1;
                }
                
                if (Grid.GetRowSpan(obj) == 2 && row == 4)
                {
                    row = row - 1;
                }*/


                Grid.SetColumn(obj, collum);
                Grid.SetRow(obj, row);
                Grid.SetColumn(imgbg, collum);
                Grid.SetRow(imgbg, row);
            }

        }
        private void posSave()
        {
            var save = new List<PoziceSave>();
            var engine = new FileHelperEngine<PoziceSave>();
            foreach (UIElement cell in grid.Children)
            {
                int x = Grid.GetColumn(cell);

                int y = Grid.GetRow(cell);

                string name = cell.GetValue(NameProperty).ToString();

                save.Add(new PoziceSave()
                {
                    x = x,
                    y = y,
                    name = name,
                });

            }
            engine.WriteFile("Output.Txt", save);
        }

        private void posLoad()
        {
            var engine = new FileHelperEngine<PoziceSave>();
            var load = engine.ReadFile("Output.txt");
            foreach (UIElement cell in grid.Children)
            {
                foreach (var objekt in load)
                {
                    if (objekt.name == cell.GetValue(NameProperty).ToString())
                    {
                        Grid.SetColumn(cell, objekt.x);
                        Grid.SetRow(cell, objekt.y);
                    }
                }
            }
        }
        /*private string imgFileName(Rectangle obj)
        {
            var img = (ImageBrush)obj.Fill;
            string defpath = img.ImageSource.ToString();
            int defpathindex = defpath.LastIndexOf('/');
            defpath = defpath.Substring(defpathindex + 1);
            defpath = defpath.Split('_')[0];
            return defpath;
        }*/
        private void imgbgAtr(Rectangle rectangle)
        {
            Grid.SetColumn(imgbg, Grid.GetColumn(rectangle));
            Grid.SetRow(imgbg, Grid.GetRow(rectangle));
            Grid.SetColumnSpan(imgbg, Grid.GetColumnSpan(rectangle));
            Grid.SetRowSpan(imgbg, Grid.GetRowSpan(rectangle));
            imgbg.Width = rectangle.Width;
            imgbg.Height = rectangle.Height;
            imgbg.Fill = Brushes.CadetBlue;
            //imgbg.Opacity = 0.5;
            Panel.SetZIndex(imgbg, -100);
            imgbg.Name = "imgbg";

        }

    }
}
