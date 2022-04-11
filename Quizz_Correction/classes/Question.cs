using System.Text.Json;
using System.Text.Json.Serialization;

namespace Quizz_Correction.classes;

class Question
{
    [JsonInclude]
    public string? Query { get; set; }

    [JsonInclude]
    public string[]? Answers { get; set; }

    [JsonInclude]
    public string? GoodAnswer { get; set; }

    public static List<Question> GetQuestion()
    {
        // verifier le fichier 
        // a ajouter : s'il n'y a pas de fichier en créer un vide 

        // ouvrir le fichier 
        string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())))!;
        string fileName = path + @"\" + "Quiz.json";
        // convertir 
        string jsonString = File.ReadAllText(fileName);

        // remplir ma liste
        // je retourne soit ma liste existante soit une liste vide
        return JsonSerializer.Deserialize<List<Question>>(jsonString) ?? new List<Question>();

    }

    public static void InitJSONQuestion(List<Question> questions)
    {
        // j'écrase le contenu de l'ancien fichier par le nouveau
        string fileName = "Quiz.json";
        string path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
        string jsonString = JsonSerializer.Serialize(questions);
        File.WriteAllText(path + "\\" + fileName, jsonString);
    }
}
