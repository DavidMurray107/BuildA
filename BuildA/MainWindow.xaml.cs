using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;

namespace BuildA
{
    

   

    public class IntegerToSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string retString = "";
            try
            {
                
                //if(value is Slider)
                //{
                //    Slider sl = (Slider)value;
                    if ((double)value == 1.0)
                        retString = "./Images/Eyebrow1.png";
                    else if ((double)value == 2.0)
                        retString = "./Images/Eyebrow2.png";
                    else if ((double)value == 3.0)
                        retString = "./Images/Eyebrow3.png";
              //  }
               
            }
            catch (Exception)
            { }
            return retString;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<CheckedListItem<Dude>> dudeList;
        int shirt = 0;
        int eyes = 0;
        int mouth = 0;
        int star = 0;
        int eyebrow = 0;
        public MainWindow()
        {
            InitializeComponent();
            dudeList = new ObservableCollection<CheckedListItem<Dude>>();
           // dudeList.Add


          
            BuildAList.ItemsSource = dudeList;
          
            DataContext = this;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            var item = cb.DataContext;
            BuildAList.SelectedItem = item;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dudeList.Add(new CheckedListItem<Dude>(new Dude(shirt, eyes, mouth, star, eyebrow)));
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (BuildAList.SelectedIndex != -1) 
                dudeList.RemoveAt(BuildAList.SelectedIndex);
        }

        private void ShirtCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).IsChecked.Value)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                if (rb.Name.Equals("rbBlackShirt"))
                    shirt = 1;
                else if (rb.Name.Equals("rbRedShirt"))
                    shirt = 2;
                else if (rb.Name.Equals("rbBlueShirt"))
                    shirt = 3;
            }
        }

        private void EyeCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).IsChecked.Value)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                if (rb.Name.Equals("rbCrazyEyes"))
                    eyes = 1;
                else if (rb.Name.Equals("rbCrazierEyes"))
                    eyes = 2;
                else if (rb.Name.Equals("rbCraziestEyes"))
                    eyes = 3;
            }
        }
       
        private void MouthCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).IsChecked.Value)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                if (rb.Name.Equals("rbMouth1"))
                    mouth = 1;
                else if (rb.Name.Equals("rbMouth2"))
                    mouth = 2;
                else if (rb.Name.Equals("rbMouth3"))
                    mouth = 3;
            }
        }

        private void StarCheckBoxes_CheckedChanged(Object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).IsChecked.Value)
            {
                // This is the correct control.
                RadioButton rb = (RadioButton)sender;
                if (rb.Name.Equals("rbStar1"))
                    star = 1;
                else if (rb.Name.Equals("rbStar2"))
                    star = 2;
                else if (rb.Name.Equals("rbStar3"))
                    star = 3;
            }
        }

        private void SlEyebrow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sl = (Slider)sender;
            eyebrow = (int)sl.Value;
        }

        private void BuildAList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuildAList.SelectedIndex != -1)
            {
                CheckedListItem<Dude> item = (CheckedListItem<Dude>)BuildAList.SelectedItem;
                Dude guy = item.Item;

                shirt = guy.Shirt;
                eyes = guy.Eyes;
                mouth = guy.Mouth;
                star = guy.Star;
                eyebrow = guy.Eyebrow;

                if (shirt == 1)
                    rbBlackShirt.IsChecked = true;
                else if (shirt == 2)
                    rbRedShirt.IsChecked = true;
                else if (shirt == 3)
                    rbBlueShirt.IsChecked = true;

                switch (eyes)
                {
                    case 1:
                        rbCrazyEyes.IsChecked = true;
                        break;
                    case 2:
                        rbCrazierEyes.IsChecked = true;
                        break;
                    case 3:
                        rbCraziestEyes.IsChecked = true;
                        break;
                }
                switch (mouth)
                {
                    case 1:
                        rbMouth1.IsChecked = true;
                        break;
                    case 2:
                        rbMouth2.IsChecked = true;
                        break;
                    case 3:
                        rbMouth3.IsChecked = true;
                        break;
                }
                switch (star)
                {
                    case 1:
                        rbStar1.IsChecked = true;
                        break;
                    case 2:
                        rbStar2.IsChecked = true;
                        break;
                    case 3:
                        rbStar3.IsChecked = true;
                        break;
                }
                switch (eyebrow)
                {
                    case 1:
                        SlEyebrow.Value = 1.0;
                        break;
                    case 2:
                        SlEyebrow.Value = 2.0;
                        break;
                    case 3:
                        SlEyebrow.Value = 3.0;
                        break;
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog flesv = new SaveFileDialog();
            flesv.InitialDirectory = Directory.GetCurrentDirectory();
            flesv.RestoreDirectory = true;
            flesv.DefaultExt = ".txt";
            flesv.ShowDialog();

            if (File.Exists(flesv.FileName))
            {
                StreamWriter output = new StreamWriter(flesv.FileName);
                foreach (CheckedListItem<Dude> chkL in dudeList)
                {
                    if (chkL.IsChecked)
                        output.WriteLine(JsonConvert.SerializeObject(chkL));
                    else
                        break;
                }
                output.Close();
            }
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {

            OpenFileDialog fleop = new OpenFileDialog();
            fleop.InitialDirectory = Directory.GetCurrentDirectory();
            fleop.RestoreDirectory = true;
            fleop.DefaultExt = ".txt";
            fleop.ShowDialog();

            StreamReader input;
            if (File.Exists(fleop.FileName))
            {
                input = new StreamReader(fleop.FileName);
                dudeList.Clear();

                string line;
                while ((line = input.ReadLine()) != null)
                    dudeList.Add(JsonConvert.DeserializeObject<CheckedListItem<Dude>>(line));
            }

        }

 

    }

    
}
