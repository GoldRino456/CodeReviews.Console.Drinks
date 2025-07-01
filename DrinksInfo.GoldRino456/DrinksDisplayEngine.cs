using Spectre.Console;

namespace DrinksInfo
{
    internal static class DrinksDisplayEngine
    {
        public static void ShowTable(string[] columns, List<string[]> rows)
        {
            var table = new Table();

            table.AddColumns(columns);
            foreach (var row in rows)
            {
                table.AddRow(row);
            }

            AnsiConsole.Write(table);
        }

        public static string PromptUserForStringSelection(string promptText, string[] choices)
        {
            return AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title(promptText)
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to see additional options)[/]")
                .AddChoices(choices));
        }

        public static void ClearScreen()
        {
            AnsiConsole.Clear();
        }

        public static void PressAnyKeyToContinue()
        {
            AnsiConsole.Write("Press Any Key To Return...");
            AnsiConsole.Console.Input.ReadKey(false);
        }
    }
}
