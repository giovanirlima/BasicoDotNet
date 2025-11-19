using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

public class DeleteAvisoRequest : IRequest<IOperationResult<AvisoResponse>>
{
    public int Id { get; private set; }

    public DeleteAvisoRequest SetIdProperty(int id)
    {
        Id = id;
        return this;
    }
}