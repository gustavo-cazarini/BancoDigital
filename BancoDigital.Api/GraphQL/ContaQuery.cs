using BancoDigital.Api.Services;

namespace BancoDigital.Api.GraphQL
{
    public class ContaQuery
    {
        private readonly ContaService _service;

        public ContaQuery(ContaService service)
        {
            _service = service;
        }

        public async Task<decimal> Saldo(int conta)
        {
            return await _service.ConsultarSaldoAsync(conta);
        }
    }
}
