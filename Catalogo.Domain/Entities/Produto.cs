using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entities;

public sealed class Produto : Entity
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public string ImagemUrl { get; private set; }
    public int Estoque { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public Produto(string nome, string descricao, decimal preco, string imagemUrl,
        int estoque, DateTime dataCadastro) => ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);

    public void Update(string nome, string descricao, decimal preco, string imagemUrl,
        int estoque, DateTime dataCadastro, int categoriaId)
    {
        ValidateDomain(nome, descricao, preco, imagemUrl, estoque, dataCadastro);
        CategoriaId = categoriaId;
    }

    private void ValidateDomain(string nome, string descricao, decimal preco, string imagemUrl,
        int estoque, DateTime dataCadastro)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obirgatório");
        DomainExceptionValidation.When(nome.Length < 3, "Nome deve ter no mínimo 3 caracteres");

        DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Descrição inválida. A descrição é obirgatória");
        DomainExceptionValidation.When(descricao.Length < 5, "A descrição deve ter no mínimo 5 caracteres");

        DomainExceptionValidation.When(preco < 0, "Valor do preço inválido");

        DomainExceptionValidation.When(imagemUrl?.Length > 250, "O nome da imagem não pode exceder de 250 caracteres");

        DomainExceptionValidation.When(estoque < 0, "Estoque inválido");

        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        ImagemUrl = imagemUrl;
        Estoque = estoque;
        DataCadastro = dataCadastro;
    }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}
