using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MemeMaker
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model DataModel 
        {
            get { return this.Resources["Foto"] as Model; }
        }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            BitmapEncoder encoder = new JpegBitmapEncoder();
            //ImgFinal --> Grid aconvertir
            RenderTargetBitmap rtb = this.DataModel.RenderVisaulToBitmap(grid, (int)grid.ActualWidth, (int)grid.ActualHeight);
            MemoryStream file = new MemoryStream();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            encoder.Save(file);

            if (file != null)
            {
                SaveFileDialog fdlg = new SaveFileDialog
                {
                    DefaultExt = "jpg",
                    Title = "/datos",
                    Filter = "*Jpeg files|.jpg|Bmp Files|*.bmp|PNG Files|*.png|Tiff Files|*.tif|Gif Files|*.gif"
                };
                bool? result = fdlg.ShowDialog();
                if (result.HasValue && result.Value)
                {
                    using (FileStream fstream = File.OpenWrite(fdlg.FileName))
                    {
                        file.WriteTo(fstream);
                        fstream.Flush();
                        fstream.Close();
                    }
                }
            }
        }
    }

}
