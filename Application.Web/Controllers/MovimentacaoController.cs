using Application.Web.Models;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Entidades;
using Domain.Repositorios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Web.Controllers
{
	public class MovimentacaoController : Controller
	{
		private readonly IMovimentacaoServico _MovimentacaoService;
		private readonly IRepositorio<Movimentacao> _MovimentacaoRepository;

		public MovimentacaoController(IMovimentacaoServico MovimentacaoService,
									IRepositorio<Movimentacao> MovimentacaoRepository)
		{
			_MovimentacaoService = MovimentacaoService;
			_MovimentacaoRepository = MovimentacaoRepository;
		}

		// GET: MovimentacaoController
		[Route("Movimentacao")]
		[Route("Movimentacao/{id}")]
		public ActionResult Index(int id = 0)
		{
			ViewBag.QuantMaxLinhasPorPagina = 10;
			ViewBag.Tipos = new List<SelectListItem>() { new SelectListItem("Entrada", "1"), new SelectListItem("Saida", "2") };
			var movView = new MovimentacaoViewModel();

			//edicao
			if (id > 0)
			{
				var movimentacao = _MovimentacaoRepository.GetById(id);
				movView = new MovimentacaoViewModel()
				{
					Id = id,
					Data = movimentacao.Data,
					FornecedorId = movimentacao.Fornecedor.Id,
					FornecedorNome = movimentacao.Fornecedor.RazaoSocial,
					MaterialId = movimentacao.Material.Id,
					MaterialNome = movimentacao.Material.Nome,
					Quantidade = movimentacao.Quantidade,
					Tipo = movimentacao.Tipo,
					ValorTotal = movimentacao.ValorTotal,
					ValorUnitario = movimentacao.ValorUnitario,
				};
			}

			var Movimentacaoes = _MovimentacaoRepository.GetAll();
			movView.Cadastrados = Movimentacaoes.ToList();

			return View(movView);
		}

		// POST: MovimentacaoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("Movimentacao/Edit")]
		[Route("Movimentacao/Edit/{id}")]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				_MovimentacaoService.Save(id,
										 Convert.ToDateTime(collection["Data"]),
										 Convert.ToInt32(collection["Tipo"]),
										 Convert.ToInt32(collection["FornecedorId"]),
										 Convert.ToInt32(collection["MaterialId"]),
										 Convert.ToDecimal(collection["Quantidade"]),
										 Convert.ToDecimal(collection["ValorUnitario"]),
										 Convert.ToDecimal(collection["ValorTotal"])
										 );
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ViewBag.Erros = "!";
				return View();
			}
		}

		[Route("Movimentacao/Delete/{id}")]
		public ActionResult Delete(int id)
		{
			try
			{
				_MovimentacaoService.Delete(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

	}
}
