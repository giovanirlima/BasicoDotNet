using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1;

public class AddAvisoHandler : IRequestHandler<AddAvisoRequest, IOperationResult<AvisoResponse>>
{
    private readonly IServiceProvider _serviceProvider;
    private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

    public AddAvisoHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task<IOperationResult<AvisoResponse>> Handle(AddAvisoRequest request, CancellationToken cancellationToken)
    {
        await _avisoRepository.AdicionarAvisoAsync(request.Titulo, request.Mensagem);

        return OperationResult<AvisoResponse>.ReturnCreated();
    }
}