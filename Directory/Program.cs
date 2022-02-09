CriarDiretorioGlobo();
CriarArquivo();

var origem = Path.Combine(Environment.CurrentDirectory, "brazil.txt");
var destino = Path.Combine(Environment.CurrentDirectory, "globo", "South America", "Brazil", "brazil.txt");

//MoverArquivo(origem, destino);
CopiarArquivo(origem, destino);


static void CopiarArquivo(string pathOrigem, string pathDestino)
{
    if (!File.Exists(pathOrigem))
    {
        Console.WriteLine("Arquivo de origem nao existe.");
        return;
    }
        

    if (File.Exists(pathDestino))
    {
        Console.WriteLine("Arquivo ja existe na pasta de destino.");
        return;
    }
    
    File.Copy(pathOrigem, pathDestino);
}


static void MoverArquivo(string pathOrigem, string pathDestino)
{
    if (!File.Exists(pathOrigem))
    {
        Console.WriteLine("Arquivo de origem nao existe.");
        return;
    }
        

    if (File.Exists(pathDestino))
    {
        Console.WriteLine("Arquivo ja existe na pasta de destino.");
        return;
    }
       
    File.Move(pathOrigem, pathDestino);
}


static void CriarArquivo()
{
    var path = Path.Combine(Environment.CurrentDirectory, "brazil.txt");
    if (!File.Exists(path))
    {
        using var sw = File.CreateText(path);
        sw.WriteLine("Population: 213M");
        sw.WriteLine("IDH: 0,901");
        sw.WriteLine("Dados atualizados em 09/02/2022");
    }
}


static void CriarDiretorioGlobo()
{
    var path = Path.Combine(Environment.CurrentDirectory, "globo");

    if (!Directory.Exists(path))
    {
        var dirGlobo = Directory.CreateDirectory(path);

        var dirNorthAm = dirGlobo.CreateSubdirectory("North America");
        var dirCentralAm = dirGlobo.CreateSubdirectory("Central America");
        var dirSouthAm = dirGlobo.CreateSubdirectory("South America");

        dirNorthAm.CreateSubdirectory("USA");
        dirNorthAm.CreateSubdirectory("Mexico");
        dirNorthAm.CreateSubdirectory("Canada");

        dirCentralAm.CreateSubdirectory("Costa Rica");
        dirCentralAm.CreateSubdirectory("Panama");

        dirSouthAm.CreateSubdirectory("Brazil");
        dirSouthAm.CreateSubdirectory("Argentina");
        dirSouthAm.CreateSubdirectory("Paraguay");
    }
}

