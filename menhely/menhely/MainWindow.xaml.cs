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
using System.DirectoryServices.ActiveDirectory;

namespace menhely;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Animal> Animals = new ObservableCollection<Animal>();
    public ObservableCollection<Animal> FilteredAnimals = new ObservableCollection<Animal>();
    public List<Animal> FilteredAnimalsList = new List<Animal>();
    public Animal ModAnimal { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        FileReader("allatok.txt");
        LstVAnimals.Items.Clear();
        LstVAnimals.ItemsSource = Animals;
        DataContext = this;
    }

    public void FileReader(string FileName)
    {
        string[] dataIn;
        if (!File.Exists(FileName))
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            FileName = System.IO.Path.Combine(projectRoot, FileName);
        }

        if (File.Exists(FileName))
        {
            dataIn = File.ReadAllLines(FileName);
        }
        else
        {
            Console.WriteLine("A megadott fájl nem található: " + FileName);
            dataIn = Array.Empty<string>();
        }
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

    private void LstVAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Update update = new Update(ModAnimal);
        update.ShowDialog();
        LstVAnimals.Items.Refresh();
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        string valami = "";
        foreach (var item in Animals)
        {
            valami += $"{item.Name};{item.Type};{item.Age};{item.Adoptable}\n";
        }
        File.WriteAllText("allatok.txt", valami);
    }
}