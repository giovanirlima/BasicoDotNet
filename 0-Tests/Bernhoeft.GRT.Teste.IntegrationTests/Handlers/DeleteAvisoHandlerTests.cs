using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Bernhoeft.GRT.Teste.IntegrationTests.Handlers;

public class DeleteAvisoHandlerTests
{
    private readonly Mock<IAvisoRepository> _repositoryMock = new();
    private readonly DeleteAvisoHandler _handler;

    public DeleteAvisoHandlerTests()
    {
        var services = new ServiceCollection();
        services.AddSingleton(_ => _repositoryMock.Object);

        _handler = new DeleteAvisoHandler(services.BuildServiceProvider());
    }

    [Fact]
    public async Task Should_Update_Aviso()
    {
        var request = new DeleteAvisoRequest().SetIdProperty(1);

        _repositoryMock.Setup(r => r.ObterAvisoPorIdAsync(request.Id, It.IsAny<TrackingBehavior>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AvisoEntity
            {
                Titulo = "Titulo",
                Mensagem = "Antiga",
                CriadoEm = DateTime.UtcNow,
                AtualizadoEm = DateTime.UtcNow
            });

        _repositoryMock.Setup(r => r.DeleteAvisoAsync(request.Id, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        var result = await _handler.Handle(request, default);

        _repositoryMock.Verify(r => r.DeleteAvisoAsync(request.Id, It.IsAny<CancellationToken>()), Times.Once);

        Assert.True(result.IsSuccessTypeResult);
        Assert.Null(result.Data);
    }
}