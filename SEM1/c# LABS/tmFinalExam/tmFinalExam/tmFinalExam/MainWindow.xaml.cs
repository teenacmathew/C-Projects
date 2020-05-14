using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace tmFinalExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Item> itemList = new List<Item>();
        private bool handle = true;
        private string selectedItem = "";

        public MainWindow()
        {
            InitializeComponent();
            DisplayElements();
            HideControlButton();
        }

        private void DisplayElements()
        {
            HideTireDetails();
            HideBatteryDetails();
            HideWiperDetails();          
        }

        private void ShowControlButton()
        {
            buttonLoad.Visibility = Visibility.Visible;
            buttonSave.Visibility = Visibility.Visible;
            buttonSubmit.Visibility = Visibility.Visible;
            labelItemName.Visibility = Visibility.Visible;
            tbItemName.Visibility = Visibility.Visible;
        }

        private void HideControlButton()
        {
            buttonLoad.Visibility = Visibility.Hidden;
            buttonSave.Visibility = Visibility.Hidden;
            buttonSubmit.Visibility = Visibility.Hidden;
            labelItemName.Visibility = Visibility.Hidden;
            tbItemName.Visibility = Visibility.Hidden;
            labelError.Visibility = Visibility.Hidden;
        }

        private void ShoWiperDetails()
        {
            labelLength.Visibility = Visibility.Visible;
            cbLength.Visibility = Visibility.Visible;
            labelShippingModeWiper.Visibility = Visibility.Visible;
            cbShippingModeWiper.Visibility = Visibility.Visible;
            ShowControlButton();
        }
        public void HideWiperDetails()
        {
            labelLength.Visibility = Visibility.Hidden;
            cbLength.Visibility = Visibility.Hidden;
            labelShippingModeWiper.Visibility = Visibility.Hidden;
            cbShippingModeWiper.Visibility = Visibility.Hidden;
        }
        public void ShowTireDetails()
        {
            labelName.Visibility = Visibility.Visible;
            cbModel.Visibility = Visibility.Visible;
            labelDiameter.Visibility = Visibility.Visible;
            cbDiameter.Visibility = Visibility.Visible;
            ShowControlButton();
        }
        public void HideTireDetails()
        {
            labelName.Visibility = Visibility.Hidden;
            cbModel.Visibility = Visibility.Hidden;
            labelDiameter.Visibility = Visibility.Hidden;
            cbDiameter.Visibility = Visibility.Hidden;
        }
        public void ShowBatteryDetails()
        {
            labelVoltage.Visibility = Visibility.Visible;
            cbVoltage.Visibility = Visibility.Visible;
            labelShippingModeBattery.Visibility = Visibility.Visible;
            cbShippingModeBattery.Visibility = Visibility.Visible;
            ShowControlButton();
        }
        public void HideBatteryDetails()
        {
            labelVoltage.Visibility = Visibility.Hidden;
            cbVoltage.Visibility = Visibility.Hidden;
            labelShippingModeBattery.Visibility = Visibility.Hidden;
            cbShippingModeBattery.Visibility = Visibility.Hidden;
        }
        private void ButtonBattery_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = "battery";
            ShowBatteryDetails();
            HideTireDetails();
            HideWiperDetails();
            buttonBattery.Foreground = Brushes.White;
            buttonBattery.Background = Brushes.Black;
            buttonWiper.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));
            buttonWiper.Foreground = Brushes.Black;
            buttonTire.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));
            buttonTire.Foreground = Brushes.Black;
            ShowControlButton();
        }

        private void ButtonWiper_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = "wiper";
            ShoWiperDetails();
            HideTireDetails();
            HideBatteryDetails();
            buttonWiper.Foreground = Brushes.White;
            buttonWiper.Background = Brushes.Black;
            buttonBattery.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));
            buttonBattery.Foreground = Brushes.Black;
            buttonTire.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));
            buttonTire.Foreground = Brushes.Black;
            ShowControlButton();
        }

        private void ButtonTire_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = "tire";
            ShowTireDetails();
            HideBatteryDetails();
            HideWiperDetails();
            buttonTire.Foreground = Brushes.White;
            buttonTire.Background = Brushes.Black;
            buttonBattery.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));
            buttonBattery.Foreground = Brushes.Black;
            buttonWiper.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));
            buttonWiper.Foreground = Brushes.Black;
            ShowControlButton();

        }

        private void CbDiameter_DropDownClosed(object sender, EventArgs e)
        {
            handle = true;
        }

        private void CbDiameter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (tbItemName.Text == "")
            {
                labelError.Visibility = Visibility.Visible;
                labelError.Content = "ENTER ITEM NAME";
            }
            else
            {
                labelError.Visibility = Visibility.Hidden;
                labelError.Content = "";
                switch (selectedItem)
                {
                    case "battery":
                        string ship = cbShippingModeBattery.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                        string voltage = cbVoltage.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                        Battery battery = new Battery(Int32.Parse(voltage), bool.Parse(ship), tbItemName.Text);
                        itemList.Add(battery);
                        flag = true;
                        break;
                    case "wiper":
                        string shipWiper = cbShippingModeWiper.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                        string length = cbLength.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                        Wiper wiper = new Wiper(Int32.Parse(length), bool.Parse(shipWiper), tbItemName.Text);
                        itemList.Add(wiper);
                        flag = true;
                        break;
                    case "tire":
                        string diameter = cbDiameter.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last();
                        Tire tire = new Tire(cbModel.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last(), Int32.Parse(diameter), tbItemName.Text);
                        itemList.Add(tire);
                        flag = true;
                        break;
                    default:
                        break;
                }
                if (flag)
                {
                    String message = "ITEM PURCHASED SUCCESSFULLY!!!";
                    MessageBoxResult result = MessageBox.Show(message + "\n To continue press OK.",
                                                        "INFORMATION OF SEATS RESERVED",
                                                        MessageBoxButton.OK,
                                                        MessageBoxImage.Information);
                    CalculateTotalAmount();
                }
            }
        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadFromXML();
                labelError.Visibility = Visibility.Hidden;
                labelError.Content = "";
            }
            catch (Exception exception)
            {
                labelError.Visibility = Visibility.Visible;
                labelError.Content = "PLEASE SAVE!";
            }
            CalculateTotalAmount();

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                labelError.Visibility = Visibility.Hidden;
                labelError.Content = "";
                WriteToXML();
                CalculateTotalAmount();
            }
            catch (Exception exception)
            {
                labelError.Visibility = Visibility.Visible;
                labelError.Content = "PLEASE SAVE!";
            }
        }

        private void WriteToXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));
            TextWriter writer = new StreamWriter("Item.xml");
            serializer.Serialize(writer, itemList);
            writer.Close();
        }

        private void ReadFromXML()
        {
            string filePath = "Item.xml";

            if (!File.Exists(filePath))
            {
                MessageBox.Show(string.Format("File {0} does not exist or is not a text file", filePath));
            }
            else
            {
                this.itemList = null;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));
                StreamReader reader = new StreamReader(filePath);
                itemList = (List<Item>)serializer.Deserialize(reader);
                reader.Close();
            }
        }

        private void LoadMostPurchasedItems()
        {
            var query = from item in itemList
                        group item by item.GetType().Name into itemGroup
                        select new
                        {
                           ItemName = itemGroup.Key,
                           Count = itemGroup.Count(),
                        };

            if (query.Count() == 0)
            {
                string message = "SORRY NO ITEMS HAVE BEEN PURCHASED!!";
                AlertResult(message);
            }
            else
            {
                string message = "ITEM : COUNT \n";
                int count = 0;
                foreach (var item in query)
                {
                    if (item.Count > count)
                    {
                        count = item.Count;
                    }
                }
                foreach (var item in query)
                {
                    if (item.Count == count)
                    {
                        message += item.ItemName + " : " + item.Count + "\n";
                    }
                }
                AlertResult(message);
            }
        }

        private void ButtonMostPurchased_Click(object sender, RoutedEventArgs e)
        {
            LoadMostPurchasedItems();
        }

        private void AlertResult(string message)
        {
            MessageBoxResult result = MessageBox.Show(message + "\n To continue press OK.",
                                                     "INFORMATION OF MOST PURCHASED ITEMS",
                                                     MessageBoxButton.OK,
                                                     MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void CalculateTotalAmount()
        {
            int total = 0;
            foreach (Item item in itemList)
            {
                total += item.Cost;
                if(item is Battery && (item as Battery).Ship)
                {
                    total += (item as Battery).ShipItem();
                }
                if (item is Wiper && (item as Wiper).Ship)
                {
                    total += (item as Wiper).ShipItem();
                }
            }
            labelTotal.Content = "TOTAL : " + total;
        }

        private void ButtonHistory_Click(object sender, RoutedEventArgs e)
        {
            var query = from item in itemList
                        group item by item.GetType().Name into itemGroup
                        select new
                        {
                            ItemName = itemGroup.Key,
                            Count = itemGroup.Count(),
                        };

            if (query.Count() == 0)
            {
                string message = "SORRY NO ITEM HAVE BEEN PURCHASED";
                AlertResult(message);
            }
            else
            {
                string message = "ITEM : COUNT \n";
                foreach (var item in query)
                {
                    message += item.ItemName + " : " + item.Count + "\n";
                }

                AlertResult(message);
            }
        }

        private void TbItemName_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelError.Visibility = Visibility.Hidden;
            labelError.Content = "";
        }
    }
}
