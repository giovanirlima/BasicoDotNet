using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Bernhoeft.GRT.Teste.IntegrationTests.Handlers;

public class AddAvisoHandlerTests
{
    private readonly Mock<IAvisoRepository> _repositoryMock = new();
    private readonly AddAvisoHandler _handler;

    public AddAvisoHandlerTests()
    {
        var services = new ServiceCollection();
        services.AddSingleton(_ => _repositoryMock.Object);

        _handler = new AddAvisoHandler(services.BuildServiceProvider());
    }

    [Fact]
    public async Task Should_Create_Aviso()
    {
        var request = new AddAvisoRequest
        {
            Titulo = "Teste",
            Mensagem = "Mensagem"
        };

        _repositoryMock.Setup(r => r.AdicionarAvisoAsync("Teste", "Mensagem", It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        var result = await _handler.Handle(request, default);

        _repositoryMock.Verify(r => r.AdicionarAvisoAsync("Teste", "Mensagem", It.IsAny<CancellationToken>()), Times.Once);

        Assert.True(result.IsSuccessTypeResult);
        Assert.Null(result.Data);
    }
}