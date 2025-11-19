using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.Core.Enums;

namespace Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;

public interface IAvisoRepository
{
    Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
    Task<AvisoEntity> ObterAvisoPorIdAsync(int id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default);
    Task AdicionarAvisoAsync(string titulo, string mensagem, CancellationToken cancellationToken = default);
    Task UpdateAvisoAsync(int id, string mensagem, CancellationToken cancellationToken = default);
    Task DeleteAvisoAsync(int id, CancellationToken cancellationToken = default);
}