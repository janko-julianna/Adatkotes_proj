using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.CompilerServices;

namespace menhely;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Animal> Animals = new ObservableCollection<Animal>();
    public ObservableCollection<Animal> FilteredAnimals = new ObservableCollection<Animal>();
    public List<Animal> FilteredAnimalsList = new List<Animal>();
    public MainWindow()
    {
        InitializeComponent();
        FileReader("allatok.txt");
        LstVAnimals.ItemsSource = Animals;
    }

    public void FileReader(string FileName)
    {
        string[] dataIn = File.ReadAllLines(FileName);
        foreach (var animal in dataIn.Skip(1))
        {
            string[] row = animal.Split(';');
            Animal NewAnimal = new Animal(row[0], row[1], int.Parse(row[2]), row[3]);
            Animals.Add(NewAnimal);
        }
    }

    private void BtnSearch_Click(object sender, RoutedEventArgs e)
    {
        FilteredAnimals.Clear();
        string SearchString = TbxSearchField.Text.ToString();
        FilteredAnimalsList = Animals.Where(x => (x.Name.ToUpper()).StartsWith(SearchString.ToUpper())).ToList();
        foreach (var FAnimal in FilteredAnimalsList)
        {
            FilteredAnimals.Add(FAnimal);
        }
        LstVSearchedAnimals.ItemsSource = FilteredAnimals;
    }

    private void BtnNewAnimal_Click(object sender, RoutedEventArgs e)
    {
        AddAnimal NBWindow = new AddAnimal(Animals);
        NBWindow.ShowDialog();
    }
}