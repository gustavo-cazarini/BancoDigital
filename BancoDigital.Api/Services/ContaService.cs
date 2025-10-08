using BancoDigital.Api.Models;
using BancoDigital.Api.Repositories;

namespace BancoDigital.Api.Services
{
    public class ContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<ContaModel> SacarAsync(int numeroConta, decimal valor)
        {
            var conta = await _contaRepository.GetPorNumeroAsync(numeroConta);

            if (conta == null)
                throw new GraphQLException("Conta não encontrada.");

            if (conta.Saldo < valor)
                throw new GraphQLException("Saldo insuficiente.");

            conta.Saldo -= valor;

            await _contaRepository.UpdateContaAsync(conta);

            return conta;
        }

        public async Task<ContaModel> DepositarAsync(int numeroConta, decimal valor)
        {
            var conta = await _contaRepository.GetPorNumeroAsync(numeroConta);

            if (conta == null)
                throw new GraphQLException("Conta não encontrada.");

            conta.Saldo += valor;

            await _contaRepository.UpdateContaAsync(conta);

            return conta;
        }

        public async Task<decimal> ConsultarSaldoAsync(int numeroConta)
        {
            var conta = await _contaRepository.GetPorNumeroAsync(numeroConta);

            return conta?.Saldo ?? 0;
        }
    }
}
