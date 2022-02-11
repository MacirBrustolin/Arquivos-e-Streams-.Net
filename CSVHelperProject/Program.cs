using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using CSVHelperProject.Model;
using CSVHelperProject.Mapping;

//LerCSVDynamic();
//LerCsvComClasse();
//LerCsvComOutroDelimitador();
EscreverCsv();

Console.WriteLine("Digite [enter] para finalizar.");
Console.ReadLine();


static void EscreverCsv(){
    var path = Path.Combine(
            Environment.CurrentDirectory,
            "Saida");
            
    var di = new DirectoryInfo(path);

    if (!di.Exists)
        di.Create();

    path = Path.Combine(path, "usuarios.csv");

    var pessoas = new List<Pessoa>(){
        new Pessoa()
        {
            Nome = "Joao da Silva",
            Email = "js@gmail.com",
            Telefone = 1343214314
        },
        new Pessoa()
        {
            Nome = "Maria da Silva",
            Email = "ms@gmail.com",
            Telefone = 1343214314
        },
        new Pessoa()
        {
            Nome = "Macir Brustolin",
            Email = "mb@gmail.com",
            Telefone = 1343214314
        }
    };

    using var sr = new StreamWriter(path);
    var csvConfig = new CsvConfiguration(CultureInfo.InstalledUICulture)
    {
        Delimiter = "|"
    };
    using var csvWriter = new CsvWriter(sr, csvConfig);
    csvWriter.WriteRecords(pessoas);
}

static void LerCsvComOutroDelimitador(){
    var path = Path.Combine(
            Environment.CurrentDirectory,
            "Entrada",
            "Livros-preco-com-virgula.csv"
        );

    var fi = new FileInfo(path);
    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} nao existe");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
        Delimiter = ";"
    };
    using var csvReader = new CsvReader(sr,csvConfig);
    csvReader.Context.RegisterClassMap<LivroMap>();
    var registros = csvReader.GetRecords<Livro>();

    foreach (var registro in registros)
    {
        System.Console.WriteLine($"Titulo: {registro.Titulo}");
        System.Console.WriteLine($"Preco: {registro.Preco}");
        System.Console.WriteLine($"Autor: {registro.Autor}");
        System.Console.WriteLine($"Lancamento: {registro.Lancamento}");
        System.Console.WriteLine("----------");
    }
}

static void LerCsvComClasse(){
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Entrada",
        "novos-usuarios.csv"
    );

    var fi = new FileInfo(path);
    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} nao existe");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr,csvConfig);

    var registros = csvReader.GetRecords<Usuario>();

    foreach (var registro in registros)
    {
        System.Console.WriteLine($"nome: {registro.Nome}");
        System.Console.WriteLine($"marca: {registro.Email}");
        System.Console.WriteLine($"preco: {registro.Telefone}");
        System.Console.WriteLine("----------");
    }
}

static void LerCSVDynamic(){
    var path = Path.Combine(
        Environment.CurrentDirectory,
        "Entrada",
        "Produtos.csv"
    );

    var fi = new FileInfo(path);
    if (!fi.Exists)
        throw new FileNotFoundException($"O arquivo {path} nao existe");

    using var sr = new StreamReader(fi.FullName);
    var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
    using var csvReader = new CsvReader(sr,csvConfig);

    var registros = csvReader.GetRecords<dynamic>();

    foreach (var registro in registros)
    {
        System.Console.WriteLine($"nome: {registro.Produto}");
        System.Console.WriteLine($"marca: {registro.Marca}");
        System.Console.WriteLine($"preco: {registro.Preco}");
        System.Console.WriteLine("----------");
    }
}

