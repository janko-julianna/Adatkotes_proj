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
    public ObservableCollection<Book> Books = new ObservableCollection<Book>();
    public ObservableCollection<Book> FilteredBooks = new ObservableCollection<Book>();
    public List<Book> FilteredBooksList = new List<Book>();
    public MainWindow()
    {
        InitializeComponent();
        FileReader("hazikonyvtar.txt");
        LstVBooks.ItemsSource = Books;
    }

    public void FileReader(string FileName)
    {
        string[] dataIn = File.ReadAllLines(FileName);
        foreach (var book in dataIn.Skip(1))
        {
            string[] row = book.Split(';');
            Book NewBook = new Book(row[0], row[1], int.Parse(row[2]));
            Books.Add(NewBook);
        }
    }

    private void BtnSearch_Click(object sender, RoutedEventArgs e)
    {
        string SearchString = TbxSearchField.Text.ToString();
        FilteredBooksList = Books.Where(x => (x.Title).Contains(SearchString)).ToList();
        foreach (var FBook in FilteredBooksList)
        {
            FilteredBooks.Add(FBook);
        }
        LstVSearchedBooks.ItemsSource = FilteredBooks;
    }

    private void BtnNewBook_Click(object sender, RoutedEventArgs e)
    {
        NewBookWindow NBWindow = new NewBookWindow();
        NBWindow.ShowDialog();
    }
}