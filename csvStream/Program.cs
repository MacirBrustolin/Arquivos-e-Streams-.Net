
CriarCSV();

Console.WriteLine("\n\nPressione [enter] para finalizar");
Console.ReadLine();

static void CriarCSV()
{
    var path = Path.Combine(Environment.CurrentDirectory, 
                            "Saida");

    var pessoas = new List<Pessoa>(){
        new Pessoa()
        {
            Nome = "Jose da Silva",
            Email = "js@gmail.com",
            Telefone = 123456,
            Nascimento = new DateOnly(year: 1970, month: 2, day: 14)
        },
        new Pessoa()
        {
            Nome = "Carla Morael",
            Email = "cm@gmail.com",
            Telefone = 987654,
            Nascimento = new DateOnly(year: 2000, month: 7, day: 20)
        }
    };

    var di = new DirectoryInfo(path);
    if (!di.Exists)
    {
        di.Create();
        path = Path.Combine(path, "usuarios.csv");
    }
    using var sw = new StreamWriter(path);
    sw.WriteLine("nome, email, telefone, nascimento");
    foreach (var pessoa in pessoas)
    {
        var linha = $"{pessoa.Nome},{pessoa.Email},{pessoa.Telefone},{pessoa.Nascimento}";
        sw.WriteLine(linha);
    }
}

static void LerCSV()
{
    var path = Path.Combine(Environment.CurrentDirectory, "Entrada", "usuarios-exportacao.csv");

    if (File.Exists(path))
    {
        using var sr = new StreamReader(path);

        var cabecalho = sr.ReadLine()?.Split(',');

        while(true)
        {
            var registro = sr.ReadLine()?.Split(',');
            if(registro == null) break;
            if (cabecalho?.Length != registro.Length)
            {
                Console.WriteLine("Arquivo fora do padrao.");
            }
            for (int i = 0; i < registro.Length; i++)
            {
                System.Console.WriteLine($"{cabecalho?[i]}:{registro[i]}");
            }
            System.Console.WriteLine("-----------");
        }
    }
    else
    {
        Console.WriteLine("O arquivo nao existe no caminho infomrmado.");
    }
}

class Pessoa 
{
    public string Nome {get; set;}
    public string Email { get; set; }
    public int Telefone { get; set; }
    public DateOnly Nascimento { get; set; }
}