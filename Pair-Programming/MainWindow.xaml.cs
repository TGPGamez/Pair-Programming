using Microsoft.Win32;
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

namespace Pair_Programming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PictureTimer Timer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Pictures_Manager.LoadPictures();
            pictures_in_gui.ItemsSource = Pictures_Manager.PicturePaths;
            Timer = new PictureTimer();
            Timer.Start();

            //Background_Handler.SetBackground(@"C:\Users\Tobias\Desktop\Backgrounds\test.png");
        }

        private void Add_picture_btnclick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openDialog.ShowDialog().Value)
            {
                //Create model out from recieved Dialog object
                PictureModel pictureModel = new PictureModel(openDialog.SafeFileName, openDialog.FileName);
                //Add to list
                Pictures_Manager.AddPicture(pictureModel);

            }
        }

        private void Remove_picture_btnclick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openDialog.ShowDialog().Value)
            {
                //Create model out from recieved Dialog object
                PictureModel pictureModel = new PictureModel(openDialog.SafeFileName, openDialog.FileName);
                //Remove model from list
                Pictures_Manager.RemovePicture(pictureModel);

            }

        }
    }
}
