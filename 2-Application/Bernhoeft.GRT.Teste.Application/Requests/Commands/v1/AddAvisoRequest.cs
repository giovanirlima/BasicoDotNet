using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

public class AddAvisoRequest : IRequest<IOperationResult<AvisoResponse>>
{
    public string Titulo { get; set; }
    public string Mensagem { get; set; }
}