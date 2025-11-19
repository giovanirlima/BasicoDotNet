using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;

public class UpdateAvisoValidation : AbstractValidator<UpdateAvisoRequest>
{
    public UpdateAvisoValidation()
    {
        RuleFor(x => x.Mensagem)
            .NotEmpty()
                .WithMessage("A mensagem do aviso é obrigatória.");
    }
}