var path = @"C:\Users\mjbru\Desktop\Arquivos e Streams .Net\Directory\globo";
LerArquivos(path);

System.Console.WriteLine("Digite enter para terminar.");
Console.ReadLine();

static void LerArquivos(string path)
{   
    if (Directory.Exists(path))
    {
        var arquivos = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        foreach (var arquivo in arquivos)
        {
            var arqInfo = new FileInfo(arquivo);
            System.Console.WriteLine($"[Nome]: {arqInfo.Name}");
            System.Console.WriteLine($"[Tamanho]: {arqInfo.Length}");
            System.Console.WriteLine($"[Ultimo Acesso]: {arqInfo.LastAccessTime}");
            System.Console.WriteLine($"[Pasta]: {arqInfo.DirectoryName}");
            System.Console.WriteLine("----------------");
        }
    }
    else
    {
        System.Console.WriteLine($"{path} nao existe");
    }
}