using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp5.Abstract_Factory;
using WpfApp5.Commands;
using static WpfApp5.Abstract_Factory.VictorianSofa;

namespace WpfApp5.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public string SelectedItem { get; set; }
        public ComboBox Affa { get; set; }
        private string imageChair;

        public string ImageChair
        {
            get { return imageChair; }
            set { imageChair = value; OnPropertyChanged(); }
        }
        private string imageTable;

        public string ImageTable
        {
            get { return imageTable; }
            set { imageTable = value; OnPropertyChanged(); }
        }
        private string imageSofa;

        public string ImageSofa
        {
            get { return imageSofa; }
            set { imageSofa = value; OnPropertyChanged(); }
        }

        private IFurnitureFactory furnitureFactory { get; set; }
        public RelayCommand SelectedChanged { get; set; }
        public AppViewModel()
        {
            SelectedChanged = new RelayCommand((sender) =>
              {
                  var item = sender as ComboBoxItem;
                  string data = item.Content.ToString();
                  ComboChangeAk(data);
              });
        }
        public void ComboChangeAk(string data2)
        {
            if (data2 == "Modern")
            {
                furnitureFactory = new ModernFurnitureFactory();
                ImageChair = furnitureFactory.createChair().getImageChair();
                ImageTable = furnitureFactory.createTable().getImageTable();
                ImageSofa = furnitureFactory.createSofa().GetImageSofa();
            }

            else if (data2 == "Victorian")
            {
                furnitureFactory = new VictorianFurnitureFactory();
                ImageChair = furnitureFactory.createChair().getImageChair();
                ImageTable = furnitureFactory.createTable().getImageTable();
                ImageSofa = furnitureFactory.createSofa().GetImageSofa();

            }

            else if (data2 == "ArtDeco")
            {
                furnitureFactory = new ArtDecoFurnitureFactory();
                ImageChair = furnitureFactory.createChair().getImageChair();
                ImageTable = furnitureFactory.createTable().getImageTable();
                ImageSofa = furnitureFactory.createSofa().GetImageSofa();
            }
        }
    }

}
