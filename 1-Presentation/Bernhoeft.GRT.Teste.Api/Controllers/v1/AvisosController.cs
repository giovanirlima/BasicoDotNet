using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;

namespace Bernhoeft.GRT.Teste.Api.Controllers.v1;

/// <response code="401">Não Autenticado.</response>
/// <response code="403">Não Autorizado.</response>
/// <response code="500">Erro Interno no Servidor.</response>
[AllowAnonymous]
[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/[controller]")]
[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
[ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = null)]
public class AvisosController : RestApiController
{
    /// <summary>
    /// Retorna Todos os Avisos Cadastrados para Tela de Edição.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Lista com Todos os Avisos.</returns>
    /// <response code="200">Sucesso.</response>
    /// <response code="204">Sem Avisos.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<IEnumerable<GetAvisosResponse>>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<object> GetAvisosAsync(CancellationToken cancellationToken) =>
        await Mediator.Send(new GetAvisosRequest(), cancellationToken);

    /// <summary>
    /// Retorna um aviso existente com base no id.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Sucesso.</response>
    /// <response code="400">Solicitação inválida.</response>
    /// <response code="404">Aviso não encontrado.</response>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<GetAvisosResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<object> GetAvisoPorIdAsync([FromRoute] GetAvisoPorIdRequest request, CancellationToken cancellationToken = default) =>
        await Mediator.Send(request, cancellationToken);

    /// <summary>
    /// Adiciona um novo aviso.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="201">Sucesso.</response>
    /// <response code="400">Solicitação inválida.</response>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> AddAvisoAsync([FromBody] AddAvisoRequest request, CancellationToken cancellationToken = default) =>
        await Mediator.Send(request, cancellationToken);

    /// <summary>
    /// Atualiza um aviso existente.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Sucesso.</response>
    /// <response code="400">Solicitação inválida.</response>
    /// <response code="404">Aviso não encontrado.</response>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<object> UpdateAvisoAsync([FromRoute] int id, [FromBody] UpdateAvisoRequest request, CancellationToken cancellationToken = default) =>
        await Mediator.Send(request.SetIdProperty(id), cancellationToken);

    /// <summary>
    /// Inativa um aviso
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="204">Sucesso.</response>
    /// <response code="400">Solicitação inválida.</response>
    /// <response code="404">Aviso não encontrado.</response>
     /// <returns></returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<object> DeleteAvisoAsync([FromRoute] int id, CancellationToken cancellationToken = default) =>
        await Mediator.Send(new DeleteAvisoRequest().SetIdProperty(id), cancellationToken);
}