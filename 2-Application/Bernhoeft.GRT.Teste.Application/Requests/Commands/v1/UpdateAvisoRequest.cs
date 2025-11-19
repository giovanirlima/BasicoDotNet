using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

public class UpdateAvisoRequest : IRequest<IOperationResult<AvisoResponse>>
{
    public int Id { get; private set; }
    public string Mensagem { get; set; }

    public UpdateAvisoRequest SetIdProperty(int id)
    {
        Id = id;
        return this;
    }
}