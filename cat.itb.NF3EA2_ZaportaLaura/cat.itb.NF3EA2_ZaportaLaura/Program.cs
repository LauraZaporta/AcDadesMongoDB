using System.Runtime.CompilerServices;
using cat.itb.NF3EA2_ZaportaLaura.cruds;

public class Program
{
    public static void Main()
    {
        const string selectOption = "\n Opció seleccionada: ";
        const string menu = "\n MENÚ DE SELECCIÓ D'EXERCICIS" +
            "\n ---------------------------------" +
            "\n [1] - ImportCollections()" +
            "\n [2] - SELECTS / CONSULTES" +
            "\n [3] - UPDATES / ACTUALITZACIONS" +
            "\n [4] - DELETES / ELIMINACIONS" +
            "\n [5] - DropCollection() - Es pot eliminar una col·lecció de la base de dades" +
            "\n [0] - EXIT";
        const string menuSelects = "\n MENÚ DE SELECCIÓ DE SELECTS" +
            "\n ---------------------------------" +
            "\n [a] - SelectPopulationByCountries() - Mostra la població de cada país d'Europa" +
            "\n [b] - SelectCapitalPopulationAndLatlng() - Mostra la capital, la població i el contingut de latlang de Madagascar" +
            "\n [c] - SelectTitlePagesAndCategoriesOfAll() - Mostra el títol, número de pàgines i les categories de tots els llibres" +
            "\n [d] - SelectNameAndCuisineByZipcode() - Mostra el nom i el tipus de cuina dels restaurants d'x codi postal" +
            "\n [e] - SelectAllByBoroughAndCuisine() - Mostra totes les dades dels restaurants de menjar xinès del Bronx" +
            "\n [f] - SelectTitlePagesAndAuthorsByLessThanXPages() - Mostra les dades especificades dels llibres amb menys d'x pàgines" +
            "\n [g] - SelectFriendsByPersonName() - Mostra els amics d'una persona; Caroline Webster" +
            "\n [0] - Exit - Sortir del programa";
        const string menuUpdates = "\n MENÚ DE SELECCIÓ D'UPDATES" +
            "\n ---------------------------------" +
            "\n [a] - UpdateZipcodeByStreet() - Actualitza el codi postal del carrer Driggs Avenue a 10443" +
            "\n [b] - UpdateNewStockminimForPlusXPrice() - Afegeix stockminim als productes amb un preu superior a 2000" +
            "\n [c] - UpdateAddAuthorToTitle() - Afegeix l'autor Sam Watters al llibre Code Generation in Action" +
            "\n [d] - UdpateNewGamaField() - Afegeix el camp gama a tots els productes" +
            "\n [e] - UpdateCategorieFromMacBookPro() - Subtitueix la categoria notebook per ipad dels MacBooks Pro" +
            "\n [f] - UpdateStockForPriceBetweenXAndY() - Actualitza l'stock dels productes amb preu dintre d'un rang" +
            "\n [g] - UpdateAddCallingCodeToCountry() - Afegeix un callingCode a Iceland" +
            "\n [0] - Exit - Sortir del programa";
        const string menuDeletes = "\n MENÚ DE SELECCIÓ DE DELETES" +
            "\n ---------------------------------" +
            "\n [a] - DeleteFromXBorough() - Elimina els restaurants de Manhattan" +
            "\n [b] - DeleteFirstCategoryFromXName() - Elimina la priemra categoria de l'iPhone 7" +
            "\n [c] - DeleteIfPagesInRange() - Elimina els llibres que tenen entre 0 i 100 pàgines" +
            "\n [d] - DeleteByName() - Elimina el producte Apple TV" +
            "\n [e] - DeleteLastCategoryFromXISBN() - Elimina l'última categoria del llibre amb isbn 1933988177" +
            "\n [f] - DeleteByCategory() - Elimina els productes amb la categoria phone" +
            "\n [g] - DeleteTagsFromTeachers() - Elimina el camp tags de tots els professors" +
            "\n [h] - DeleteIfThereIsXLanguage() - Elimina el país si en aquest es parla espanyol" +
            "\n [0] - Exit - Sortir del programa";

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
                    try
                    {
                        BooksCRUD.LoadBooksCollection();
                        CountriesCRUD.LoadCountriesCollection();
                        GradesCRUD.LoadGradesCollection();
                        PeopleCRUD.LoadPeopleCollection();
                        ProductsCRUD.LoadProductsCollection();
                        RestaurantsCRUD.LoadRestaurantsCollection();
                        StudentsCRUD.LoadStudentsCollection();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n Error: {ex.Message}");
                    }
                    break;
                case "2":
                    DisplaySelectsMenu(menuSelects, selectOption, ref exit);
                    break;
                case "3":
                    DisplayUpdatesMenu(menuUpdates, selectOption, ref exit);
                    break;
                case "4":
                    DisplayDeletesMenu(menuDeletes, selectOption, ref exit);
                    break;
                case "5":
                    GeneralCRUD.DropCollection("itb", "grades");
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
    private static void DisplaySelectsMenu(string menu, string selectOption, ref bool exit)
    {
        string menuOption = string.Empty;

        Console.WriteLine(menu);
        Console.Write(selectOption);
        menuOption = Console.ReadLine();

        switch (menuOption)
        {
            case "a":
                CountriesCRUD.SelectPopulationByCountries("Europe");
                break;
            case "b":
                CountriesCRUD.SelectCapitalPopulationAndLatln("Madagascar");
                break;
            case "c":
                BooksCRUD.SelectTitlePagesAndCategoriesOfAll();
                break;
            case "d":
                string zipcode = "11226";
                RestaurantsCRUD.SelectNameAndCuisineByZipcode(zipcode);
                break;
            case "e":
                string borough = "Bronx";
                string cuisine = "Chinese";
                RestaurantsCRUD.SelectAllByBoroughAndCuisine(borough, cuisine);
                break;
            case "f":
                int numPages = 130;
                BooksCRUD.SelectTitlePagesAndAuthorsByLessThanXPages(numPages);
                break;
            case "g":
                string name = "Caroline Webster";
                PeopleCRUD.SelectFriendsByPersonName(name);
                break;
            case "0":
                exit = true;
                break;
            default:
                Console.WriteLine("\n Aquesta opció no és vàlida!");
                break;
        }
    }
    private static void DisplayUpdatesMenu(string menu, string selectOption, ref bool exit)
    {
        string menuOption = string.Empty;

        Console.WriteLine(menu);
        Console.Write(selectOption);
        menuOption = Console.ReadLine();

        switch (menuOption)
        {
            case "a":
                string street = "Driggs Avenue";
                string zip = "10443";
                RestaurantsCRUD.UpdateZipcodeByStreet(street, zip);
                break;
            case "b":
                ProductsCRUD.UpdateNewStockminimForPlusXPrice(2000, 20);
                break;
            case "c":
                string title = "Code Generation in Action";
                string author = "Sam Watters";
                BooksCRUD.UpdateAddAuthorToTitle(title, author);
                break;
            case "d":
                ProductsCRUD.UdpateNewGamaField();
                break;
            case "e":
                string name = "MacBook Pro";
                string oldCat = "notebook";
                string newCat = "ipad";
                ProductsCRUD.UpdateCategorieFromMacBookPro(name, oldCat, newCat);
                break;
            case "f":
                int min = 800;
                int max = 1000;
                int newStock = 60;
                ProductsCRUD.UpdateStockForPriceBetweenXAndY(min, max, newStock);
                break;
            case "g":
                string countryName = "Iceland";
                int newCallingCode = 356;
                CountriesCRUD.UpdateAddCallingCodeToCountry(countryName, newCallingCode);
                break;
            case "0":
                exit = true;
                break;
            default:
                Console.WriteLine("\n Aquesta opció no és vàlida!");
                break;
        }
    }
    private static void DisplayDeletesMenu(string menu, string selectOption, ref bool exit)
    {
        string menuOption = string.Empty;

        Console.WriteLine(menu);
        Console.Write(selectOption);
        menuOption = Console.ReadLine();

        switch (menuOption)
        {
            case "a":
                string borough = "Manhattan";
                RestaurantsCRUD.DeleteFromXBorough(borough);
                break;
            case "b":
                string prodName = "iPhone 7";
                ProductsCRUD.DeleteFirstCategoryFromXName(prodName);
                break;
            case "c":
                int min = 0;
                int max = 100;
                BooksCRUD.DeleteIfPagesInRange(min, max);
                break;
            case "d":
                string name = "Apple TV";
                ProductsCRUD.DeleteByName(name);
                break;
            case "e":
                string isbn = "1933988177";
                BooksCRUD.DeleteLastCategoryFromXISBN(isbn);
                break;
            case "f":
                string cat = "phone";
                ProductsCRUD.DeleteByCategory(cat);
                break;
            case "g":
                PeopleCRUD.DeleteTagsFromTeachers();
                break;
            case "h":
                string lang = "Spanish";
                CountriesCRUD.DeleteIfThereIsXLanguage(lang);
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