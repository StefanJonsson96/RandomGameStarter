string startFolder = @"E:\SteamLibrary\steamapps";
// Ändra startmappen för att passa din dator.

System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);
IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

var queryMatchingFiles =
    from file in fileList
    where file.Extension == ".acf"
    let fileText = GetFileText(file.DirectoryName)
    select file.FullName;

List<string> games = new List<string>(); // Skapar en tom lista.

foreach (var filename in queryMatchingFiles) 
{
    games.Add(filename); // Stoppar in alla appmanifest.acf filer i listan.

}
List<string> gameIds = new List<string>(); // Skapar ny lista för att hålla alla game Ids.

foreach (var game in games)
{
    var test = game.Substring(game.IndexOf('_') +1); 
    var test2 = test.Remove(test.IndexOf('.'));   
    gameIds.Add(test2);
    // Stränghantering, t.ex "appmanifest_205100.acf" blir "205100", alltså gameId.
}

var random = new Random();
int randomGame = random.Next(gameIds.Count); // Slumpar ett spels gameid ur listan.
Console.WriteLine("Startar spelet med gameid: " + gameIds[randomGame]);

string cmdText = "/K D:&cd Steam& steam steam://run/" + gameIds[randomGame];
System.Diagnostics.Process.Start("CMD.exe", cmdText);
//Startar CMD och startar spelet med det slumpade game:id

static string GetFileText(string name)
    {
        string fileContents = String.Empty;

     
        if (System.IO.File.Exists(name))
        {
            fileContents = System.IO.File.ReadAllText(name);
        }
        return fileContents;
    }