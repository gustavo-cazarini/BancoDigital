using BancoDigital.Api.Models;

namespace BancoDigital.Api.Repositories
{
    public interface IContaRepository
    {
        Task<ContaModel?> GetPorNumeroAsync(int numero);
        Task UpdateContaAsync(ContaModel conta);
    }
}
