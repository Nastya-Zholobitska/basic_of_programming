using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using static System.String;
using System.IO;
using System.Linq;

namespace Lab_2_First_App
{
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List <Ellipse>();
        static PointCollection pC = new PointCollection();
        static double minleng = 0;
        static List<int[]> parents = new List<int[]>();

        public MainWindow()
        {
            dT = new DispatcherTimer();

            InitializeComponent();
            InitPoints();
            InitPolygon();

            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }

        private void InitPoints()
        {
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();
           

            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75*MainWin.Width)-3*Radius);
                p.Y = rnd.Next(Radius, (int)(0.90*MainWin.Height-3*Radius));                
                pC.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            { 
                Ellipse el = new Ellipse();
                BrushConverter conv = new BrushConverter();
                ImageBrush im = new ImageBrush();

                el.StrokeThickness = 2;           
                el.Height = el.Width = Radius;
                el.Stroke = (Brush)conv.ConvertFromString("#212027");

                if (i == 0)
                    el.Fill = new ImageBrush(new BitmapImage(new Uri(Directory.GetCurrentDirectory()+@"\3235.jpg", UriKind.Relative)));
                else
                    el.Fill = (Brush)conv.ConvertFromString("#9C2736");

                EllipseArray.Add(el); 
            }            
        }

        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;            
            myPolygon.StrokeThickness = 2;            
        }

        private void PlotPoints()
        {            
            for (int i=0; i<PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius/2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius/2);
                MyCanvas.Children.Add(EllipseArray[i]);
                Canvas.SetZIndex(MyCanvas.Children[MyCanvas.Children.Count - 1], 1);
            }     
        }


        private void PlotWay(int [] BestWayIndex)
        {
            PointCollection Points = new PointCollection();

            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(pC[BestWayIndex[i]]);

            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }


        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (VelCB.SelectedItem == one)
            {
                res.Content = "Результуючий шлях: ";
                MyCanvas.Children.Clear();
                InitPoints();
                PlotPoints();
              PlotWay( GetBestWay_Greedy(pC));
                res.Content += " "+Convert.ToString(minleng);
                minleng = 0;
            }
            else
            {
                if (dT.IsEnabled)
                {
                    dT.Stop();
                    BrushConverter conv = new BrushConverter();
                    StopStart.Background = (Brush)conv.ConvertFromString("#212027");
                    StopStart.Foreground = Brushes.White;
                    StopStart.Content = "Запустити";
                    NumElemCB.IsEnabled = true;
                    pop.IsEnabled = true;
                    mut.IsEnabled = true;
                }
                else
                {
                    BrushConverter conv2 = new BrushConverter();
                    NumElemCB.IsEnabled = false;
                    StopStart.Background = Brushes.White;
                    StopStart.Foreground = (Brush)conv2.ConvertFromString("#212027");
                    StopStart.Content = "Зупинити";
                    pop.IsEnabled = false;
                    mut.IsEnabled = false;
                    dT.Start();
                }
            }
        }
      

        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
            PlotPoints();
            PlotWay(GetBestWay_Genetic(pC));
            res.Content = "Результуючий шлях: ";
            res.Content += " " + Convert.ToString(minleng);
        }

        private int[] GetBestWay_Genetic(PointCollection pC)
        {
            Random rnd = new Random();
            var children = new List<int[]>();
            int[] way = new int [pC.Count+1];
            var x = new List<int>();
            double[,] lengths = Make_Lenght_Massive(pC);
            int count_p = Convert.ToInt32(pop.Text);
            int counter = 0;

            if (parents.Count == 0)
            {
                for (int i = 0; i < count_p; i++)
                {
                    var one = new int[pC.Count];
                    while (counter < pC.Count)
                    {
                        int ind = rnd.Next(0, pC.Count);
                        while (x.Contains(ind))
                        {
                            ind = rnd.Next(0, pC.Count);
                        }
                        one[counter] = ind;
                        x.Add(ind);
                        counter++;
                    }
                    parents.Add(one);
                    counter = 0;
                    x.Clear();
                }

            }
            int P1, P2, del, rand;
            for (int i = 0; i < count_p; i++)
            {
                P1 = rnd.Next(0, count_p);
                P2 = rnd.Next(0, count_p);
                while (P2 == P1)
                {
                    P2 = rnd.Next(0, count_p);
                }
                int[] parent1 = new int[pC.Count];
                parents[P1].CopyTo(parent1, 0);
                int[] parent2 = new int[pC.Count];
                parents[P2].CopyTo(parent2, 0);
                int[] ans1 = new int[pC.Count * 2];
                int[] ans2 = new int[pC.Count * 2];
                parents[P1].CopyTo(ans1, 0);
                parents[P2].CopyTo(ans2, 0);

                del = rnd.Next(1, pC.Count - 1);
                rand = rnd.Next(0, 2);
                
                Array.Copy(parent1, 0, ans2, 0, del+1);
                Array.Copy(parent2, 0, ans1, 0, del+1);

                var child = new int [ans1.Length + ans2.Length];

                if (rand == 0)
                    child = ans1.Union(ans2).Distinct().ToArray();
                else
                    child = ans2.Union(ans1).Distinct().ToArray();

                double mutation;
                mutation = rnd.Next(0, 1);
                if (mutation < Convert.ToDouble(mut.Text))
                {
                    int d1 = rnd.Next(0, child.Length);
                    int d2 = rnd.Next(0, child.Length);

                    if (d2>d1)
                    Array.Reverse(child, d1, d2-d1);
                    else if (d1>d2) Array.Reverse(child, d2, d1-d2);
                }

                children.Add(child);
            }

            var dict = new Dictionary<int[], double>();
            for (int i = 0; i < 2 * parents.Count; i++)
            {
                int[] elem = new int[pC.Count];
                if (i < count_p)
                    elem = parents[i];
                else elem = children[i - count_p];

                double lengt = 0;
                for (int j = 1; j < pC.Count; j++)
                {
                    lengt += lengths[elem[j - 1], elem[j]];
                }
                lengt += lengths[elem[pC.Count - 1], elem[0]];
                dict.Add(elem, lengt);
            }

           dict= dict.OrderBy(y => y.Value).ToDictionary(y => y.Key, y => y.Value);

            minleng = dict.FirstOrDefault().Value;
           dict.FirstOrDefault().Key.CopyTo(way, 0);
            way[pC.Count] = way[0];

            parents.Clear();
           foreach (var elem in dict)
                if (parents.Count == count_p)
                    break;
                else
                {
                    parents.Add(elem.Key);
                    counter++;
                }
            return way;
        }

        private int[] GetBestWay_Greedy(PointCollection pC)
        {
            int[] way2 = new int[PointCount+1];
            minleng = 0;
            int ind=0;
            List<double> zn = new List<double>();

            double[,] lengths = Make_Lenght_Massive(pC);

            int counter=0;
            int k = 0;
            double min = 1000;
            zn.Add(0);
            while (counter < PointCount-1)
            {
                for (int j = 0; j < PointCount; j++)
                {
                    if (j == k || zn.Contains(j)) continue;
                    else if (lengths[k, j] < min)
                    {
                        min = lengths[k, j];
                        ind = j;
                    }
                }
                zn.Add(ind);
                way2[counter] = ind;
                k = ind;
                minleng += min;
                min = 1000;                
                counter++;
            }
            way2[PointCount] = 0;
            minleng += lengths[ind, 0];
            return way2;
        }

        private double[,] Make_Lenght_Massive(PointCollection pC)
        {
            double[,] lengths = new double[PointCount, PointCount];
            double s;
            for (int i = 0; i < PointCount; i++)
            {
                for (int j = 0; j < PointCount; j++)
                {
                    if (i == j) s = 0;
                    else s = Math.Sqrt(Math.Pow((pC[j].X - pC[i].X), 2) + Math.Pow((pC[j].Y - pC[i].Y), 2));
                    lengths[i, j] = s;
                }
            }
            return lengths;
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            parents.Clear();
            InitPoints();
            InitPolygon();
        }


        private void VelCB_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (VelCB.SelectedItem == one)
            {
                VelCB1.IsEnabled = false;
                pop.IsEnabled = false;
                mut.IsEnabled = false;
            }
            else
            {
                VelCB1.IsEnabled = true;
                pop.IsEnabled = true;
                mut.IsEnabled = true;
            }
        }

        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            dT.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }
    }
}