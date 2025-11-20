using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;
using FluentAssertions;
using Xunit;

namespace Bernhoeft.GRT.Teste.IntegrationTests.Validations;

public class UpdateAvisoValidationTests
{
    private readonly UpdateAvisoValidation _validator = new();

    [Fact]
    public void Should_Fail_When_Mensagem_Is_Empty()
    {
        var request = new UpdateAvisoRequest().SetIdProperty(1);
        request.Mensagem = "";

        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Mensagem");
    }

    [Fact]
    public void Should_Fail_When_Mensagem_Is_Null()
    {
        var request = new UpdateAvisoRequest().SetIdProperty(1);
        request.Mensagem = null;

        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Mensagem");
    }

    [Fact]
    public void Should_Pass_When_Request_Is_Valid()
    {
        var request = new UpdateAvisoRequest().SetIdProperty(1);
        request.Mensagem = "Mensagem válida";

        var result = _validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }
}