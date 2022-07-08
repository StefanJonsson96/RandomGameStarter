string startFolder = @"E:\SteamLibrary\steamapps\common";
// Ändra startmappen för att passa din dator.

System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
string searchTerm = @""; // Om du vill filtrera efter filnamn kommentera ut "where"



var queryMatchingFiles =
    from file in fileList
    where file.Extension == ".exe"
    let fileText = GetFileText(file.DirectoryName)
    //where fileText.Contains(searchTerm)
    select file.FullName;

List<string> games = new List<string>(); // Skapar en tom lista.

foreach (var filename in queryMatchingFiles) 
{
    games.Add(filename); // Stoppar in alla file paths i en lista.

}
var random = new Random();
int randomGame = random.Next(games.Count); // Slumpar ett spels filepath ur listan.
Console.WriteLine(games[randomGame]);
System.Diagnostics.Process.Start(games[randomGame]); // Startar den exe filen vi slumpat fram.

     
    static string GetFileText(string name)
    {
        string fileContents = String.Empty;

     
        if (System.IO.File.Exists(name))
        {
            fileContents = System.IO.File.ReadAllText(name);
        }
        return fileContents;
    }