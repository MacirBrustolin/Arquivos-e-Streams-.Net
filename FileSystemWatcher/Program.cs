var path = @"C:\Users\mjbru\Desktop\Arquivos e Streams .Net\Directory\globo";

using var fsw = new FileSystemWatcher(path);

fsw.Created += OnCreated;
fsw.Renamed += OnRenamed;
fsw.Deleted += OnDeleted;

fsw.EnableRaisingEvents = true;
fsw.IncludeSubdirectories = true;

System.Console.WriteLine("Digite [enter] para finalizar a aplicação.");
Console.ReadLine();

void OnCreated(object sender, FileSystemEventArgs e)
{
    System.Console.WriteLine($"Foi criado o arquivo {e.Name}");
}

void OnDeleted(object sender, FileSystemEventArgs e)
{
    System.Console.WriteLine($"Foi excluido o arquivo {e.Name}");
}

void OnRenamed(object sender, RenamedEventArgs e)
{
    System.Console.WriteLine($"O arquivo {e.OldName} foi renomeado para {e.Name}");
}