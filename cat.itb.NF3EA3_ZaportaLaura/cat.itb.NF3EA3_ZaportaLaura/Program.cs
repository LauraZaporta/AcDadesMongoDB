using cat.itb.NF3EA3_ZaportaLaura.cruds;

public class Program()
{
    public static void Main()
    {
        const string selectOption = "\n Opció seleccionada: ";
        const string menu = "\n MENÚ DE SELECCIÓ D'EXERCICIS" +
            "\n ---------------------------------" +
            "\n [1] - Import Books and Products collection" +
            "\n [2] - DropCollection() example (with books)" +
            "\n [3a] - SelectNameAndPriceFromMostExpensive() - Mostra el nom i el preu del producte més car" +
            "\n [3b] - SelectStockSum() - Suma tot l'stock dels productes i el mostra" +
            "\n [3c] - SelectTitleAuthorsAndPageCountByRangePagesAndCategory()" +
            "\n [3d] - SelectTitleAndAuthorsByAuthors() - Mostra el títol i autors dels llibres que continguin x autors" +
            "\n [3e] - SelectTitleAndStatus() - Mostra el títol i l'estatus de tots els llibres" +
            "\n [3f] - SelectTitleAndCategoriesDescPages() - Mostra el títol i categories de tots els llibres descendent per nombre de pàgines" +
            "\n [3h] - SelectIfContainsCategoryButNotXAuthorAscTitle() - Mostra els llibres amb X categoria però saltant els amb X autor" +
            "\n [0] - EXIT";

        bool exit = false;
        string menuOption = string.Empty;

        while (!exit)
        {
            Console.WriteLine(menu);
            Console.Write(selectOption);
            menuOption = Console.ReadLine();

            switch (menuOption)
            {
                case "1":
                    BooksCRUD.LoadBooksObjectCollection();
                    ProductsCRUD.LoadProductsObjectCollection();
                    break;
                case "2":
                    string database = "itb";
                    string collection = "books";
                    GeneralCRUD.DropCollection(database, collection);
                    break;
                case "3a":
                    ProductsCRUD.SelectNameAndPriceFromMostExpensive();
                    break;
                case "3b":
                    ProductsCRUD.SelectStockSum();
                    break;
                case "3c":
                    int min = 300;
                    int max = 350;
                    string category = "Java";
                    BooksCRUD.SelectTitleAuthorsAndPageCountByRangePagesAndCategory(min, max, category);
                    break;
                case "3d":
                    string[] authors = { "Charlie Collins", "Robi Sen" };
                    BooksCRUD.SelectTitleAndAuthorsByAuthors(authors);
                    break;
                case "3e":
                    BooksCRUD.SelectTitleAndStatus();
                    break;
                case "3f":
                    BooksCRUD.SelectTitleAndCategoriesDescPages();
                    break;
                case "3h":
                    string cat = "Java";
                    string author = "Vikram Goyal";
                    BooksCRUD.SelectIfContainsCategoryButNotXAuthorAscTitle(cat, author);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\n Aquesta opció no és vàlida!");
                    break;
            }
        }
    }
}