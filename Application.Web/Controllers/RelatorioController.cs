using Application.Web.Models;
using Domain.Entities;
using Domain.Interfaces.Entidades;
using Domain.Repositorios.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Application.Web.Controllers
{
	public class RelatorioController : Controller
	{
		private readonly ILogger<RelatorioController> _logger;
		private readonly IMovimentacaoServico _movimentacaoService;

		public RelatorioController(ILogger<RelatorioController> logger, IMovimentacaoServico movimentacaoService)
		{
			_logger = logger;
			_movimentacaoService = movimentacaoService;
		}

		public IActionResult Index()
		{
			var ret = new RelatorioViewModel();
			ret.DataDe = new DateTime(2020,01,01);
			ret.DataAte = DateTime.Today;
			return View(ret);
		}

		[HttpPost]
		public IActionResult Index(RelatorioViewModel model)
		{
			var ret = new RelatorioViewModel();
			ret.Relatorio = new List<DadosRelatorio>();

			//var movimentacoes = _movimentacaoService.GetProc("GerarRelatorio", "@DataDe,@DataAte,@Tipo,@FornecedorId,@MaterialId");
			//var lst = movimentacoes.Select(x => new Items()
			//{
			//	Data = x.Data,
			//	MaterialCodigo = x.MaterialCodigo,

			//	QtdEntrada = x.QtdEntrada,
			//	ValorEntrada = x.ValorEntrada,

			//	QtdSaida = x.QtdSaida,
			//	ValorSaida = x.ValorSaida,

			//	QtdSaldo = x.QtdEntrada - x.QtdSaida,
			//	ValorSaldo = x.ValorEntrada - x.ValorSaida

			//}).ToList();
			var movimentacoes = _movimentacaoService.GetAll()
				.Where(d => (model.TipoMovimentacao == 0 || d.Tipo == model.TipoMovimentacao) &&
						   (model.FornecedorId == 0 || d.Fornecedor?.Id == model.FornecedorId) &&
						   (model.MaterialId == null || d.Material?.Id == model.MaterialId) &&
						   (model.DataDe <= d.Data) &&
						   (model.DataAte >= d.Data))
				.ToList();

			var lst = movimentacoes.Select(x => new Items()
			{
				Data = x.Data,
				MaterialCodigo = x.Material.Codigo,

				QtdEntrada = x.Tipo == Domain.Enums.ETipoMovimentacao.Entrada ? x.Quantidade : 0,
				ValorEntrada = x.Tipo == Domain.Enums.ETipoMovimentacao.Entrada ? x.ValorTotal : 0,

				QtdSaida = x.Tipo == Domain.Enums.ETipoMovimentacao.Saida ? x.Quantidade : 0,
				ValorSaida = x.Tipo == Domain.Enums.ETipoMovimentacao.Saida ? x.ValorTotal : 0,

				QtdSaldo = x.Quantidade,
				ValorSaldo = x.ValorTotal

			}).ToList();



			ret.Relatorio = lst.GroupBy(x => x.MaterialCodigo)
				.Select(X => new DadosRelatorio()
				{
					MaterialCodigo = X.Key,
					QtdTotalEntrada = X.Sum(D => D.QtdEntrada),
					ValorTotalEntrada = X.Sum(D => D.ValorEntrada),
					QtdTotalSaida = X.Sum(D => D.QtdSaida),
					ValorTotalSaida = X.Sum(D => D.ValorSaida),

					QtdTotaldSaldo = X.Sum(D => D.QtdEntrada) - X.Sum(D => D.QtdSaida),
					ValorTotalSaldo = X.Sum(D => D.ValorEntrada) - X.Sum(D => D.ValorSaida),
					MovimentacoesMaterial = X.ToList(),

				}).ToList();

			return View(ret);
		}

		public IActionResult Privacy()
		{
			return View();
		}

	}
}
