using BancoDigital.Api.Models;
using BancoDigital.Api.Services;

namespace BancoDigital.Api.GraphQL
{
    public class ContaMutation
    {
        private readonly ContaService _service;

        public ContaMutation(ContaService service)
        {
            _service = service;
        }

        public async Task<ContaModel> Sacar(int conta, decimal valor)
        {
            return await _service.SacarAsync(conta, valor);
        }

        public async Task<ContaModel> Depositar(int conta, decimal valor)
        {
            return await _service.DepositarAsync(conta, valor);
        }
    }
}
