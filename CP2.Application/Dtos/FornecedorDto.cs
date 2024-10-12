using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Nome)} deve ter no mínimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} não pode ser vazio");

            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.CNPJ)} não pode ser vazio");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Endereco)} não pode ser vazio");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Telefone)} não pode ser vazio");

            RuleFor(x => x.Email)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Email)} deve ter no mínimo 5 caracteres")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Email)} não pode ser vazio");

            RuleFor(x => x.CriadoEm)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.CriadoEm)} não pode ser vazio");
        }
    }
}
