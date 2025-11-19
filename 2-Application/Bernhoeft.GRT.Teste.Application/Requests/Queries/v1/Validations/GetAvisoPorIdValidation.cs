using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations;

public class GetAvisoPorIdValidation : AbstractValidator<GetAvisoPorIdRequest>
{
    public GetAvisoPorIdValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
                .WithMessage("O Id do aviso deve ser maior que zero.");
    }
}