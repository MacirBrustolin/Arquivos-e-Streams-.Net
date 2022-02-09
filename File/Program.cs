Console.WriteLine("Digite o nome do arquivo:");
var nome = Console.ReadLine();

nome = LimparNome(nome);

var path = Path.Combine(Environment.CurrentDirectory, $"{nome}.txt");

CriarArquivo(path);

System.Console.WriteLine("Digite enter para finalizar.");
Console.ReadLine();

static string LimparNome(string nome)
{
    foreach(var @char in Path.GetInvalidFileNameChars())
    {
        nome = nome.Replace(@char, '-');
    }
    return nome;
}

static void CriarArquivo(string path)
{
    try
    {
        using var sw = File.CreateText(path);
        sw.WriteLine("Esta e a linha 1 do arquivo.");
        sw.WriteLine("Esta e a linha 2 do arquivo.");
        sw.WriteLine("Esta e a linha 3 do arquivo.");
        sw.WriteLine("Esta e a linha 4 do arquivo.");
    } 
    catch
    {
        System.Console.WriteLine("O nome do arquivo e invalido.");
    }
    
}