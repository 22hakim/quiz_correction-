namespace Quizz_Correction.classes;

internal class Display
{
    public void MainMenu()
    {
        ContentStyle.TitleText("Bienvenue sur ce Quiz");
        ContentStyle.LineText("Veuillez choisir un des choix suivants : ");
        ContentStyle.UnordoredList("1 - Réaliser le QCM");
        ContentStyle.UnordoredList("2 - Gérer le QCM");
        Console.ResetColor();
    }

    public void ManagementMenu()
    {
        ContentStyle.TitleText("Gestion du Quiz", ConsoleColor.Green);
        ContentStyle.LineText("Veuillez choisir un des choix suivants : ");
        ContentStyle.UnordoredList("1 - Ajouter une question");
        ContentStyle.UnordoredList("2 - Supprimer une question");
        ContentStyle.UnordoredList("3 - Information");
        ContentStyle.UnordoredList("4 - Revenir au menu principal");
        Console.ResetColor();
    }

    public void DisplayQuery(string NumQuestion, 
                             Question query,
                             ConsoleColor color = ConsoleColor.White,
                             string? Message = null)
    {
        ContentStyle.TitleText(NumQuestion, color);
        ContentStyle.LineText(query.Query);
        foreach  (string prop in query.Answers)
        {
            ContentStyle.UnordoredList(prop);
        }
        Console.ResetColor();
        if(Message != null)
        {
            Console.WriteLine(Message);
        }
    }

    public void DisplayScore(int score)
    {
        
        ConsoleColor consoleColor = ConsoleColor.Red;
        if(score > 7)
            consoleColor = ConsoleColor.Green;
        else if(score > 4)
            consoleColor = ConsoleColor.Yellow;

        ContentStyle.TitleText(" Votre QCM est maintenant terminé ", consoleColor);
        ContentStyle.LineText("Vous obtenez le résultat de "+score+"/10\n", consoleColor);

    }

    public void Clear(string? message = null)
    {
        Console.Clear();
        Console.WriteLine(message);
    }

}

