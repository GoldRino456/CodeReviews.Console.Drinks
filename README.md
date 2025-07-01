
# Drinks Info

A simple console application that allows the user to access drink recipes from TheCocktailDB.com!

Use the arrow keys on your keyboard to navigate menus and press enter to select an option.
## Features

- Interfaces with TheCocktailDB's public API to fetch:
    - All possible drink categories
    - All drinks for a selected category
    - Information for how to make the drink and needed ingredients

- Easy to use UI with Spectre Console to ensure user is limited to only valid choices



## Tech Stack

**Runtime & Framework:** .NET 8

**REST Client:** RestSharp

**UI:** Spectre.Console


## Lessons Learned

- This was my first exposure to Async methods in C#, which felt quite similar to Unity's coroutines for me. I can see this especially being useful when delving more into multi-threaded code on top of it's use case here, waiting for a response from a given API.

- When starting this project, I did manage to successfully make API calls using the HTTPClient class, but quickly pivoted to RestSharp for simplicity's sake. When it comes to working with APIs, I had more familiarity with this in Python and hadn't done much with APIs in C# up to this point. RestSharp greatly simplified the amount of code needed to make even a basic GET call. I completely see why that package has as many downloads as it does on NuGet. 
## Acknowledgements

 - [The C# Academy](https://www.thecsharpacademy.com/) - Amazing community that's paving the path for others to more easily learn how to use the .NET Framework and beyond.
 - [README Editor](https://readme.so/editor)
 - [Spectre Console](https://spectreconsole.net) 

