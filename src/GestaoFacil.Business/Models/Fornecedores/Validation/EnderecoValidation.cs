using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFacil.Business.Models.Fornecedores.Validation
{
    public class EnderecoValidation :AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O campo{PropertyName} precisa ser fornecidto")
                .Length(2, 200).WithMessage("O campo {} precisa ter entre {MinLength} e{MaxLength} caracteres");

            RuleFor(c => c.Bairro)
               .NotEmpty().WithMessage("O campo{PropertyName} precisa ser fornecidto")
               .Length(2, 200).WithMessage("O campo {} precisa ter entre {MinLength} e{MaxLength} caracteres");


            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("O campo{PropertyName} precisa ser fornecidto")
                .Length(8).WithMessage("O campo {} precisa ter entre {MinLength} e{MaxLength} caracteres");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("O campo{PropertyName} precisa ser fornecidto")
                .Length(2, 100).WithMessage("O campo {} precisa ter entre {MinLength} e{MaxLength} caracteres");

            RuleFor(c => c.Estado)
              .NotEmpty().WithMessage("O campo{PropertyName} precisa ser fornecidto")
              .Length(2, 50).WithMessage("O campo {} precisa ter entre {MinLength} e{MaxLength} caracteres");



        }
    }
}
