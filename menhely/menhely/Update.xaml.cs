using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public Animal animal { get; set; } = new Animal();
        public Update(Animal animal)
        {
            InitializeComponent();
            this.animal = animal;
            cbAdoptable.IsChecked = animal.Adoptable;
            tbName.Text = animal.Name;
            tbAge.Text = $"{animal.Age}";
            tbType.Text = animal.Type;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            animal.Name = tbName.Text;
            animal.Age = int.Parse(tbAge.Text);
            animal.Type = tbType.Text;
            animal.Adoptable = (bool)cbAdoptable.IsChecked;
            this.Close();
        }
    }
}
