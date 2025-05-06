using System.Runtime.CompilerServices;
using cat.itb.NF3EA4_CognomNom.cruds;
using cat.itb.NF3EA4_CognomNom.model;
using EA1.model.countriesCollection;
using EA1.model.restaurantsCollection;

public class Program()
{
    public static void Main()
    {
        const string selectOption = "\n Opció seleccionada: ";
        const string menu = "\n MENÚ DE SELECCIÓ D'EXERCICIS" +
            "\n ---------------------------------" +
            "\n [1] - Import Countries, Products and Restaurants collection" +
            "\n [2a] - SelectHowManyCountriesWithLanguage() - Mostra el número de països que parlen x llengua" +
            "\n [2b] - SelectRegionWithMoreCountries() - Mostra el continent que té més països" +
            "\n [2c] - SelectAllSubregionsWithNumCountries() - Mostra totes les subregions i el seu nombre de països" +
            "\n [2d] - SelectCountryWithMoreLanguages() - Mostra el país amb més llengües" +
            "\n [2e] - SelectNumTimesEachScore() - Mostra el nombre de vegades que apareix cada puntuació" +
            "\n [2f] - SelectZipcodesFromBoroughs() - Mostra els codis postals de cada barri" +
            "\n [2g] - SelectByCuisineDesc() - Mostra els tipus de cuina i el seu nombre de restaurants (Desc)" +
            "\n [2h] - SelectNumGrades() - Mostra el número de grades d'un restaurant junt amb el nom d'aquest" +
            "\n [2i] - SelectCuisinesByBorough() - Mostra el tipus de cuina de cada barri" +
            "\n [2j] - SelectMaxScoreForEach() - Mostra la puntuació màxima de cada restaurant" +
            "\n [2k] - SelectNumCategories() - Mostra el número de categories de cada producte" +
            "\n [2l] - SelectCategoriesNoRep() - Mostra totes les categories sense repeticions" +
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
                    GeneralCRUD.LoadObjectCollection<Product>("products", "Product");
                    GeneralCRUD.LoadObjectArrayCollection<Country>("countries", "Country");
                    GeneralCRUD.LoadObjectCollection<Restaurant>("restaurants", "Restaurant");
                    break;
                case "2a":
                    string lang = "English";
                    CountriesCRUD.SelectHowManyCountriesWithLanguage(lang);
                    break;
                case "2b":
                    CountriesCRUD.SelectRegionWithMoreCountries();
                    break;
                case "2c":
                    CountriesCRUD.SelectAllSubregionsWithNumCountries();
                    break;
                case "2d":
                    CountriesCRUD.SelectCountryWithMoreLanguages();
                    break;
                case "2e":
                    RestaurantsCRUD.SelectNumTimesEachScore();
                    break;
                case "2f":
                    RestaurantsCRUD.SelectZipcodesFromBoroughs();
                    break;
                case "2g":
                    RestaurantsCRUD.SelectByCuisineDesc();
                    break;
                case "2h":
                    RestaurantsCRUD.SelectNumGrades();
                    break;
                case "2i":
                    RestaurantsCRUD.SelectCuisinesByBorough();
                    break;
                case "2j":
                    RestaurantsCRUD.SelectMaxScoreForEach();
                    break;
                case "2k":
                    ProductsCRUD.SelectNumCategories();
                    break;
                case "2l":
                    ProductsCRUD.SelectCategoriesNoRep();
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