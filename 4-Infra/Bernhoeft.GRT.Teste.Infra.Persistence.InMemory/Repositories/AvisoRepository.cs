using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Attributes;
using Bernhoeft.GRT.Core.EntityFramework.Infra;
using Bernhoeft.GRT.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bernhoeft.GRT.ContractWeb.Infra.Persistence.SqlServer.ContractStore.Repositories;

[InjectService(Interface: typeof(IAvisoRepository))]
public class AvisoRepository : Repository<AvisoEntity>, IAvisoRepository
{
    public AvisoRepository(IServiceProvider serviceProvider) : base(serviceProvider) { }

    public Task<List<AvisoEntity>> ObterTodosAvisosAsync(TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
    {
        var query = tracking is TrackingBehavior.NoTracking ? Set.AsNoTrackingWithIdentityResolution() : Set;

        return query.Where(x => x.Ativo).ToListAsync();
    }

    public async Task<AvisoEntity> ObterAvisoPorIdAsync(int id, TrackingBehavior tracking = TrackingBehavior.Default, CancellationToken cancellationToken = default)
    {
        var query = tracking is TrackingBehavior.NoTracking ? Set.AsNoTrackingWithIdentityResolution() : Set;

        return await query.FirstOrDefaultAsync(x => x.Id == id && x.Ativo, cancellationToken);
    }

    public async Task AdicionarAvisoAsync(string titulo, string mensagem, CancellationToken cancellationToken = default)
    {
        var query = Set;

        await query.AddAsync(new AvisoEntity
        {
            Titulo = titulo,
            Mensagem = mensagem
        }, cancellationToken);

        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAvisoAsync(int id, string mensagem, CancellationToken cancellationToken = default)
    {
        var aviso = await ObterAvisoPorIdAsync(id, TrackingBehavior.Default, cancellationToken);

        aviso.Mensagem = mensagem;
        aviso.AtualizadoEm = DateTime.UtcNow;

        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAvisoAsync(int id, CancellationToken cancellationToken = default)
    {
        var aviso = await ObterAvisoPorIdAsync(id, TrackingBehavior.Default, cancellationToken);

        aviso.Ativo = false;
        aviso.AtualizadoEm = DateTime.UtcNow;

        await Context.SaveChangesAsync(cancellationToken);
    }
}