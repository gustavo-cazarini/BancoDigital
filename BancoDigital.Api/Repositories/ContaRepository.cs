using BancoDigital.Api.Data;
using BancoDigital.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoDigital.Api.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ContaRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ContaModel?> GetPorNumeroAsync(int numero)
        {
            using var context = _contextFactory.CreateDbContext();

            var contaEncontrada = await context.Contas.FirstOrDefaultAsync(c => c.Conta == numero);

            return contaEncontrada;
        }

        public async Task UpdateContaAsync(ContaModel conta)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Contas.Update(conta);

            await context.SaveChangesAsync();
        }
    }
}
