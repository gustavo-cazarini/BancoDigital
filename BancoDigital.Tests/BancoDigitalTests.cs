using BancoDigital.Api.Models;
using BancoDigital.Api.Repositories;
using BancoDigital.Api.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BancoDigital.Tests
{
    public class BancoDigitalTests
    {
        [Fact]
        public async Task Sacar_DeveDiminuirSaldo_QuandoSaldoSuficiente()
        {
            var conta = new ContaModel { Conta = 123, Saldo = 200 };
            var repoMock = new Mock<IContaRepository>();

            repoMock.Setup(r => r.GetPorNumeroAsync(123)).ReturnsAsync(conta);
            repoMock.Setup(r => r.UpdateContaAsync(It.IsAny<ContaModel>())).Returns(Task.CompletedTask);

            var service = new ContaService(repoMock.Object);
            var result = await service.SacarAsync(123, 50);

            result.Saldo.Should().Be(150);
            repoMock.Verify(r => r.UpdateContaAsync(It.Is<ContaModel>(c => c.Saldo == 150)), Times.Once);
        }

        [Fact]
        public async Task Depositar_DeveAumentarSaldo()
        {
            var conta = new ContaModel { Conta = 123, Saldo = 50 };
            var repoMock = new Mock<IContaRepository>();

            repoMock.Setup(r => r.GetPorNumeroAsync(123)).ReturnsAsync(conta);
            repoMock.Setup(r => r.UpdateContaAsync(It.IsAny<ContaModel>())).Returns(Task.CompletedTask);

            var service = new ContaService(repoMock.Object);
            var result = await service.DepositarAsync(123, 50);

            result.Saldo.Should().Be(100);
            repoMock.Verify(r => r.UpdateContaAsync(It.Is<ContaModel>(c => c.Saldo == 100)), Times.Once);
        }

        [Fact]
        public async Task Sacar_DeveLancarErro_QuandoSaldoInsuficiente()
        {
            var conta = new ContaModel { Conta = 123, Saldo = 20 };
            var repoMock = new Mock<IContaRepository>();

            repoMock.Setup(r => r.GetPorNumeroAsync(123)).ReturnsAsync(conta);

            var service = new ContaService(repoMock.Object);
            await Assert.ThrowsAsync<HotChocolate.GraphQLException>(() => service.SacarAsync(123, 50));
        }

        [Fact]
        public async Task Consultar_DeveRetornarSaldo()
        {
            var conta = new ContaModel { Conta = 123, Saldo = 50 };
            var repoMock = new Mock<IContaRepository>();

            repoMock.Setup(r => r.GetPorNumeroAsync(123)).ReturnsAsync(conta);

            var service = new ContaService(repoMock.Object);

            var result = await service.ConsultarSaldoAsync(123);

            result.Should().Be(50);
            repoMock.Verify(r => r.GetPorNumeroAsync(123), Times.Once);
            repoMock.VerifyNoOtherCalls();
        }
    }
}
