using Bogus;
using ProjetoEdicaoEndereco.Models.Enums;
using SistemaAtulizarEndereco.Models;

namespace ProjetoEdicaoEndereco.Data;

public static class DadosFicticios
{
    public static void GerarDados(ProjetoEdicaoEnderecoContext context)
    {
        if (!context.Estado.Any())
        {
            GerarEstados(context);
        }

        if (!context.Cidade.Any())
        {
            GerarCidades(context);
        }

        if (!context.Individuo.Any())
        {
            GerarIndividuos(context);
        }

        if (!context.Carro.Any())
        {
            GerarCarros(context, context.Individuo.ToList());
        }

        if (!context.IndividuoContato.Any())
        {
            GerarContatos(context, context.Individuo.ToList());
        }

        if (!context.IndividuoEndereco.Any())
        {
            GerarEnderecos(context, context.Individuo.ToList(), context.Cidade.ToList(), context.Estado.ToList());
        }
    }

    private static void GerarEstados(ProjetoEdicaoEnderecoContext context)
    {
        var estados = new[]
        {
            new Estado { Id = 1, Nome = "São Paulo", Uf = "SP", Pais = "Brasil"},
            new Estado { Id = 2,Nome = "Rio de Janeiro", Uf = "RJ", Pais = "Brasil"},
            new Estado { Id = 3, Nome = "Minas Gerais", Uf = "MG", Pais = "Brasil"},
            new Estado { Id = 4, Nome = "Bahia", Uf = "BA", Pais = "Brasil"},
            new Estado { Id = 5,Nome = "Paraná", Uf = "PR", Pais = "Brasil" }
        };

        context.Estado.AddRange(estados);
        context.SaveChanges();
    }

    private static void GerarCidades(ProjetoEdicaoEnderecoContext context)
    {
        var cidades = new[]
        {
            new Cidade { Nome = "São Paulo", Uf = "SP", EstadosId = 1 },
            new Cidade { Nome = "Guarulhos", Uf = "SP", EstadosId = 1 },
            new Cidade { Nome = "Rio de Janeiro", Uf = "RJ", EstadosId = 2 },
            new Cidade { Nome = "Duque de Caxias", Uf = "RJ", EstadosId = 2 },
            new Cidade { Nome = "Belo Horizonte", Uf = "MG", EstadosId = 3},
            new Cidade { Nome = "Betim", Uf = "MG", EstadosId = 3},
            new Cidade { Nome = "Salvador", Uf = "BA", EstadosId = 4},
            new Cidade { Nome = "Itabuna", Uf = "BA", EstadosId = 4},
            new Cidade { Nome = "Curitiba", Uf = "PR", EstadosId = 5},
            new Cidade { Nome = "Adrianópolis", Uf = "PR", EstadosId = 5}
        };

        context.Cidade.AddRange(cidades);
        context.SaveChanges();
    }

    private static void GerarIndividuos(ProjetoEdicaoEnderecoContext context)
    {
        var individuos = new Faker<Individuo>("pt_BR")
            .RuleFor(i => i.Nome, f => f.Person.FullName)
            .RuleFor(i => i.Documento, f => f.Random.Replace("###.###.###-##"))
            .RuleFor(i => i.DataNascimento, f => f.Date.Past(50, DateTime.Now.AddYears(-18)))
            .Generate(10);

        context.Individuo.AddRange(individuos);
        context.SaveChanges();
    }

    private static void GerarCarros(ProjetoEdicaoEnderecoContext context, System.Collections.Generic.List<Individuo> individuo)
    {
        var individuos = context.Individuo.ToList();

        var carros = new List<Carro>();
        var faker = new Faker<Carro>("pt_BR");

        foreach (var individuoAtual in individuos)
        {
            var carro = faker
                .RuleFor(c => c.Placa, static f => f.Random.Replace("???-####"))
                .RuleFor(c => c.Categoria, f => f.Vehicle.Type())
                .RuleFor(c => c.Modelo, f => f.Vehicle.Model())
                .RuleFor(c => c.Ano, f => f.Random.Number(1990, 2023))
                .RuleFor(e => e.IndividuoId, individuoAtual.Id)
                .Generate();

            carros.Add(carro);
        }

        context.Carro.AddRange(carros);
        context.SaveChanges();
    }

    private static void GerarContatos(ProjetoEdicaoEnderecoContext context, System.Collections.Generic.List<Individuo> individuo)
    {
        var individuos = context.Individuo.ToList();

        var contatos = new List<IndividuoContato>();
        var faker = new Faker<IndividuoContato>("pt_BR");

        foreach (var individuoAtual in individuos)
        {
            var contato = faker
            .RuleFor(c => c.Ddi, f => "55")
            .RuleFor(c => c.Ddd, f => f.Random.Number(11, 99).ToString())
            .RuleFor(c => c.Telefone, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.Whatsapp, f => (WhatsappEnum)f.Random.Number(0, 1))
            .RuleFor(c => c.TipoContato, f => (TipoContatoEnum)f.Random.Number(0, 1))
            .RuleFor(e => e.IndividuoId, individuoAtual.Id)
            .Generate();

            contatos.Add(contato);
        }

        context.IndividuoContato.AddRange(contatos);
        context.SaveChanges();
    }

    private static void GerarEnderecos(ProjetoEdicaoEnderecoContext context, System.Collections.Generic.List<Individuo> individuo, System.Collections.Generic.List<Cidade> cidades, System.Collections.Generic.List<Estado> estados)
    {
        var individuos = context.Individuo.ToList();

        var enderecos = new List<IndividuoEndereco>();
        var faker = new Faker<IndividuoEndereco>("pt_BR");

        foreach (var individuoAtual in individuos)
        {
            var estadoId = estados.OrderBy(e => Guid.NewGuid()).First().Id;
            var cidadesDoEstado = cidades.Where(c => c.EstadosId == estadoId).ToList();

            var endereco = faker
                .RuleFor(e => e.Cep, f => f.Address.ZipCode())
                .RuleFor(e => e.Logradouro, f => f.Address.StreetName())
                .RuleFor(e => e.Bairro, f => f.Address.StreetAddress())
                .RuleFor(e => e.Numero, f => f.Address.BuildingNumber())
                .RuleFor(e => e.Complemento, f => f.Lorem.Word())
                .RuleFor(e => e.IndividuoId, individuoAtual.Id)
                .RuleFor(e => e.EstadoId, estadoId)
                .RuleFor(e => e.CidadeId, f => cidadesDoEstado.OrderBy(c => Guid.NewGuid()).First().Id)
                .Generate();

            enderecos.Add(endereco);
        }

        context.IndividuoEndereco.AddRange(enderecos);
        context.SaveChanges();
    }
}
