using DrinksInfo;
using System.Reflection;

public class DrinksInfoApp
{
    private const string QuitText = "Quit & Return To Desktop";
    private const string GoBackText = "Go Back...";

    public static void Main()
    {
        CocktailApiClient client = CocktailApiClient.Instance;
        
        while(true)
        {
            Category? categoryChoice = DisplayCategories(client);

            if(categoryChoice.StrCategory.Equals(QuitText))
            {
                break;
            }
            

            while(true)
            {
                Drink? drinkChoice = DisplayDrinksInCategory(client, categoryChoice);

                if(drinkChoice.StrDrink.Equals(GoBackText))
                {
                    break;
                }

                DisplayDrinkData(client, drinkChoice);
                DrinksDisplayEngine.PressAnyKeyToContinue();
                DrinksDisplayEngine.ClearScreen();
            }
        }
    }

    private static Category? DisplayCategories(CocktailApiClient client)
    {
        var categories = client.GetCategoryList().Result;
        
        var quitOption = new Category() { StrCategory = QuitText };
        categories.Add(quitOption);

        string[] choices = new string[categories.Count];
        for(int i = 0; i < categories.Count; i++)
        {
            choices[i] = categories[i].StrCategory;
        }

        var selection = DrinksDisplayEngine.PromptUserForStringSelection("Please select a category: ", choices);

        foreach(var category in categories)
        {
            if(category.StrCategory.Equals(selection))
            {
                return category;
            }
        }

        return null;
    }

    private static Drink? DisplayDrinksInCategory(CocktailApiClient client, Category categoryChoice)
    {
        var drinks = client.GetDrinksByCategory(categoryChoice).Result;

        var quitOption = new Drink() { StrDrink = GoBackText };
        drinks.Add(quitOption);

        string[] choices = new string[drinks.Count];
        for (int i = 0; i < drinks.Count; i++)
        {
            choices[i] = drinks[i].StrDrink;
        }

        var selection = DrinksDisplayEngine.PromptUserForStringSelection("Which drink would you like to view?", choices);

        foreach (var drink in drinks)
        {
            if(drink.StrDrink.Equals(selection))
            {
                return drink;
            }
        }

        return null;
    }

    private static void DisplayDrinkData(CocktailApiClient client, Drink drink)
    {
        var drinkDataContainer = client.GetDrinkDataContainer(drink).Result;
        DrinkData drinkData = drinkDataContainer[0];

        List<string[]> displayList = new();
        string formattedName = "";

        foreach (PropertyInfo property in drinkData.GetType().GetProperties())
        {
            if(property.Name.Contains("Str"))
            {
                formattedName = property.Name.Substring(3);
            }

            if (!string.IsNullOrEmpty(property.GetValue(drinkData)?.ToString()))
            {
                displayList.Add([formattedName, property.GetValue(drinkData).ToString()]);
            }

            
        }

        DrinksDisplayEngine.ShowTable(["", ""], displayList);
    }
}