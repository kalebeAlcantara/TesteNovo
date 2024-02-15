using Application.Web.Models;
using Domain.Interfaces.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Application.Web.Controllers
{
	public class FornecedorController : Controller
	{
		private readonly IFornecedorServico _fornecedorService;

		public FornecedorController(IFornecedorServico fornecedorService)
		{
			_fornecedorService = fornecedorService;
		}

		// GET: FornecedorController
		[Route("Fornecedor")]
		[Route("Fornecedor/{id}")]
		public ActionResult Index(int id = 0)
		{
			ViewBag.QuantMaxLinhasPorPagina = 10;
			var fornView = new FornecedorViewModel();

			//edicao
			if (id > 0)
			{
				var fornecedor = _fornecedorService.GetById(id);
				fornView = new FornecedorViewModel()
				{
					CNPJ = fornecedor.CNPJ,
					Id = fornecedor.Id,
					RazaoSocial = fornecedor.RazaoSocial,
				};
			}

			var fornecedores = _fornecedorService.GetAll();
			fornView.Cadastrados = fornecedores.ToList();

			return View(fornView);
		}

		// POST: FornecedorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("Fornecedor/Edit")]
		[Route("Fornecedor/Edit/{id}")]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				_fornecedorService.Save(id, Convert.ToString(collection["CNPJ"]), Convert.ToString(collection["RazaoSocial"]), true);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ViewBag.Erros = "!";
				return View();
			}
		}


		[Route("Fornecedor/Delete/{id}")]
		public ActionResult Delete(int id)
		{
			try
			{
				_fornecedorService.Save(id, string.Empty, string.Empty, false);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}



		[HttpPost]
		[Route("Fornecedor/Listar")]
		public JsonResult Listar(string Prefix)
		{
			var forn = _fornecedorService.GetAll()
										 .Where(x => x.RazaoSocial.ToUpper().Contains(Prefix.ToUpper()))
										 .Select(x => new { Nome = x.RazaoSocial, Id = x.Id })
										 .ToList();
			return Json(forn);
		}
	}
}
