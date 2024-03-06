using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entities;

public sealed class Categoria : Entity
{
    public string Nome { get; private set; }
    public string ImagemUrl { get; private set; }
    public ICollection<Produto> Produtos { get; set; }

    public Categoria(string nome, string imagemUrl) => ValidateDomain(nome, imagemUrl);

    public Categoria(int id, string nome, string imagemUrl)
    {
        DomainExceptionValidation.When(id < 0, "O valor de Id inválido.");
        Id = id;
        ValidateDomain(nome, imagemUrl);
    }

    private void ValidateDomain(string nome, string imagemUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório");
        DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl), "Nome da imagem inválido. O nome é obrigatório");

        DomainExceptionValidation.When(nome.Length < 3, "O nome deve ter no mínimo 3 caracteres");
        DomainExceptionValidation.When(imagemUrl.Length < 5, "Nome da imagem deve ter no mínimo 5 caracteres");

        Nome = nome;
        ImagemUrl = imagemUrl;
    }
}
