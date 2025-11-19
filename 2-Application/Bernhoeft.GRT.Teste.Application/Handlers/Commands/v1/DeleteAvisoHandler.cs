using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1;

public class DeleteAvisoHandler : IRequestHandler<DeleteAvisoRequest, IOperationResult<AvisoResponse>>
{
    private readonly IServiceProvider _serviceProvider;
    private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();

    public DeleteAvisoHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task<IOperationResult<AvisoResponse>> Handle(DeleteAvisoRequest request, CancellationToken cancellationToken)
    {
        var response = await _avisoRepository.ObterAvisoPorIdAsync(request.Id, TrackingBehavior.NoTracking, cancellationToken);

        if (response is null)
            return OperationResult<AvisoResponse>.ReturnNotFound();

        await _avisoRepository.DeleteAvisoAsync(request.Id, cancellationToken);

        return OperationResult<AvisoResponse>.ReturnNoContent();
    }
}