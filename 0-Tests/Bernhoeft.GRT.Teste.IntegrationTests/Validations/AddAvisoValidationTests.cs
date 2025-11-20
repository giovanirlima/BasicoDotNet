using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;
using FluentAssertions;
using Xunit;

namespace Bernhoeft.GRT.Teste.IntegrationTests.Validations;

public class AddAvisoValidationTests
{
    private readonly AddAvisoValidation _validator = new();

    [Fact]
    public void Should_Fail_When_Titulo_Is_Empty()
    {
        var request = new AddAvisoRequest
        {
            Titulo = "",
            Mensagem = "Mensagem válida"
        };

        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Titulo");
    }

    [Fact]
    public void Should_Fail_When_Titulo_Is_Null()
    {
        var request = new AddAvisoRequest
        {
            Titulo = null,
            Mensagem = "Mensagem válida"
        };

        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Titulo");
    }

    [Fact]
    public void Should_Fail_When_Mensagem_Is_Empty()
    {
        var request = new AddAvisoRequest
        {
            Titulo = "Título válido",
            Mensagem = ""
        };

        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Mensagem");
    }

    [Fact]
    public void Should_Fail_When_Mensagem_Is_Null()
    {
        var request = new AddAvisoRequest
        {
            Titulo = "Título válido",
            Mensagem = null
        };

        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Mensagem");
    }

    [Fact]
    public void Should_Pass_When_Request_Is_Valid()
    {
        var request = new AddAvisoRequest
        {
            Titulo = "OK",
            Mensagem = "OK"
        };

        var result = _validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }
}