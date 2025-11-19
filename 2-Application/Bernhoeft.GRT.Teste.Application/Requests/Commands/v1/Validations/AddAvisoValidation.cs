using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;

public class AddAvisoValidation : AbstractValidator<AddAvisoRequest>
{
    public AddAvisoValidation()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty()
                .WithMessage("O título do aviso é obrigatório.");

        RuleFor(x => x.Mensagem)
            .NotEmpty()
                .WithMessage("A mensagem do aviso é obrigatório.");
    }
}