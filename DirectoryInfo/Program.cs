var path = @"C:\Users\mjbru\Desktop\Arquivos e Streams .Net\Directory\globo";
LerDiretorios(path);

System.Console.WriteLine("Digite enter para terminar.");
Console.ReadLine();

static void LerDiretorios(string path)
{   
    if (Directory.Exists(path))
    {
        var diretorios = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
        foreach (var dir in diretorios)
        {
            var dirInfo = new DirectoryInfo(dir);
            System.Console.WriteLine($"[Nome]: {dirInfo.Name}");
            System.Console.WriteLine($"[Raiz]: {dirInfo.Root}");

            if(dirInfo.Parent != null)
                System.Console.WriteLine($"[Pai]: {dirInfo.Parent.Name}");

            System.Console.WriteLine("----------------");
        }
    }
    else
    {
        System.Console.WriteLine($"{path} nao existe");
    }
}