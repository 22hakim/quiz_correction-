using System.Text.Json;

namespace Quizz_Correction.classes;

class AdminMenu
{
    public static  Display Display = new ();
    public static void ChooseMenuItems(int menuNumber)
    {
        switch (menuNumber)
        {
            case 1:
                AddQuestion();
                break;
            case 2:
                RemoveQuestion();
                break;
            default:
                Display.Clear(" Erreur la valeur ne correspond a aucun choix");
                Quiz.ManageMenu();
                break;
        }
    }

    static void AddQuestion()
    {
        Display.Clear();

        // je récupère toutes les informations liées à la nouvelle question 
        Console.WriteLine(" Ajoutez un intitulé a la question :");
        string? query = Console.ReadLine();

        Console.WriteLine(" Listez les 4 réponses possibles séparées par une virgule");
        string? answers = Console.ReadLine();

        Console.WriteLine(" Indiquez la bonne réponse :");
        string? goodAnswer = Console.ReadLine();

        // je récupere mon ancienne liste 
        List<Question> questions = Question.GetQuestion();

        // j'ajoute ma nouvelle question à l'ancienne liste 
        questions.Add(new Question { Query = query, Answers = answers.Split(','), GoodAnswer = goodAnswer });

        // je met a jour mon fichier jSON 
        Question.InitJSONQuestion(questions);
    }

    static void RemoveQuestion()
    {
        Display.Clear();
        ContentStyle.TitleText(" suppression d'une question");

        // je récupère les questions
        List<Question> questions = Question.GetQuestion();

        // je les affiche 
        foreach (Question q in questions)
        {
            int index = questions.IndexOf(q);
            Console.WriteLine("Question numéro :{0}, intitulé {1}", index+1, q.Query);
        }

        // je récupère le numéro de la question que je veux supprimer 
        Console.WriteLine(" indiquez la valeur de la question que vous voulez supprimer:");
        int? numQuestion = Int32.Parse(Console.ReadLine()!);

        // je supprime 
        questions.RemoveAt((int)(numQuestion - 1));

        // je met a jour mon fichier jSON 
        Question.InitJSONQuestion(questions);

        Display.Clear(" La question à bien été supp");
        Console.ResetColor();

    }
}
