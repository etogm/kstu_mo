using System;
using System.Windows;

namespace OptimizationMethodApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        static double Func(double x) => 0.1 * Math.Pow(x, 3) - 2 * Math.Pow(x, 2) + 10 * x;

        static string GetReport(int i, double x, double f) => $"i = {i + 1}\tX = {x}\tF({x}) = {f}";

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            double x;
            double step;
            double f;
            double fNext;
            int    i = 0;
            reportTb.Text = string.Empty;

            if (!double.TryParse(leftBorderTb.Text, out x) || !double.TryParse(stepTb.Text, out step))
            {
                MessageBox.Show($"Неверные данные");
                return;
            }

            do
            {
                f = Func(x);
                fNext = Func(x + step);

                reportTb.Text += GetReport(i, x, f) + "\n";

                x += step;
                i++;
            }
            while (fNext > f);

            resultTb.Text = GetReport(i, x, f);
        }
    }
}
