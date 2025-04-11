using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace menhely
{
    /// <summary>
    /// Interaction logic for AddAnimal.xaml
    /// </summary>
    public partial class AddAnimal : Window
    {
        ObservableCollection<Animal> animals;
        public AddAnimal(ObservableCollection<Animal> list)
        {
            InitializeComponent();
            animals = list;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string adoptable = "Igen";
            if (cbAdoptable.IsChecked == true)
            {
                adoptable = "Igen";
            }
            else
            {
                adoptable = "Nem";
            }
            int age = 0;
            try
            {
                age = int.Parse(tbAge.Text);
            }
            catch 
            {
                age = 1;
            }

            animals.Add(new Animal(tbName.Text, tbType.Text, age, adoptable));
            string output = $"\n{tbName.Text};{tbType.Text};{age};{adoptable}";
            File.AppendAllText("allatok.txt", output);
            this.Close();
        }
    }
}
