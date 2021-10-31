using FluentValidation;

namespace GestaoFacil.Business.Models.Fornecedores.Validation
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2,200)
                .WithMessage("Campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            //When(f => f.TipoFornecedor == TipoFornecedor.PessoalFisica, () =>
            //{
            //    RuleFor(f => f.Documento.Length).Equal(CpfValidation.Tamanho)
            //    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");

            //    RuleFor(f => CpfValidation>IValidationRule(f.Documento)).Equal(true)
            //    .WithMessage("Documento invalido;");

            //});
            //When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            //{
            //    RuleFor(f => f.Documento.Length).Equal(CnpjValidation.Tamanho)
            //   .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");
            //});

        }
    }
}
