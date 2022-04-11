using System.Text.Json;

namespace Quizz_Correction.classes;

internal class Quiz
{
    public static Display Display = new();

    public List<Question> Questions { get; set; }

    public static int Score { get; set; } = 0;
    public static Dictionary<Question, bool>? QuestionsCount { get; set; } 

    public Quiz()
    {
        Questions = Question.GetQuestion();
        QuestionsCount = new Dictionary<Question, bool>();
    }
    public void Start()
    {
        Display.MainMenu();
        ConsoleKeyInfo mainMenuChoice = Console.ReadKey();

        switch(mainMenuChoice.KeyChar)
        {
            case '1':
                Display.Clear(" demarrage du Quiz ");
                LaunchQuizz();
            break;
            case '2':
                Display.Clear();

                if(Login() is false)
                {
                    Display.Clear(" Vous avez été redirigé car vous avez entré un mauvais mot de passe");
                    Start();
                }

                ManageMenu();
                break;
            default: 
                Display.Clear(" désolé je ne comprends pas votre choix");
                Start();
            break;
        }

    }

    static public void ManageMenu()
    {
        Display.Clear();
        Display.ManagementMenu();

        int userChoice;
        
        if(Int32.TryParse(Console.ReadLine(), out userChoice))
        {
            AdminMenu.ChooseMenuItems(userChoice);
            return; // ici j'indique au programme de sortir de la methode manageMenu
        }

        Display.Clear(" Désolé la commande est invalide tapez un nombre");
        Display.ManagementMenu();

    }
    public bool Login()
    {
        Console.WriteLine("Entrez un mot de passe :");
        string? password = Console.ReadLine();
        
        if(password == "Admin2022")
        {
            return true;
        }

        return false;
    }

    public void LaunchQuizz()
    {
        int i = 1;
        foreach (Question q in Questions)
        {
            Display.DisplayQuery("Question " + i , q);
            string? UserAnswer = Console.ReadLine()!.ToLower() ?? "no answer";

            CheckAnswer(q, UserAnswer);
            Display.Clear();
            i++;
        }

        CalcResult();

        Display.DisplayScore(Score);
   
    }

    public void CalcResult()
    {
        Console.WriteLine();
        int i = 1;
        foreach (KeyValuePair<Question,bool> result in QuestionsCount!)
        {
            ConsoleColor color;
            string message;
            if (result.Value is true)
            {
                color = ConsoleColor.DarkGreen;
                message = "Félicitation la réponse était juste !!";
            }
            else
            {
                color = ConsoleColor.Red;
                message = "Malheuresement la réponse était fausse !! il fallait répondre " + result.Key.GoodAnswer;
            }
            Display.DisplayQuery("Question " + i, result.Key, color, message);
            i++;
        }
    }



    public void CheckAnswer(Question Q, string? UserAnswer)
    {
        bool result = false;

        if(Q.GoodAnswer == UserAnswer)
        {
            Score++;
            result = true;
        }

        QuestionsCount!.Add(Q, result);
    }
}
