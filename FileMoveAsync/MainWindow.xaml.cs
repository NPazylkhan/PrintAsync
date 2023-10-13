using System.IO;
using System.Windows;

namespace FileMoveAsync
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string startDirectory = @"c:\Temp\start",
                   endDirectory = @"c:\Temp\end";

            foreach (string fileName in Directory.EnumerateFiles(startDirectory))
            {
                using FileStream sourceStream = File.Open(fileName, FileMode.Open);
                using FileStream destinationStream = File.Create(Path.Combine(endDirectory, Path.GetFileName(fileName)));
                await sourceStream.CopyToAsync(destinationStream);
            }
        }
    }
}
