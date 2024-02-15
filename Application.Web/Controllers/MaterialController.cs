using Domain.Interfaces;
using Application.Web.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Entidades;
using Domain.Repositorios.Entidades;

namespace Application.Web.Controllers
{
	public class MaterialController : Controller
	{
		private readonly IMaterialServico _MaterialService;
		private readonly IRepositorio<Material> _MaterialRepository;

		public MaterialController(IMaterialServico materialService,
								  IRepositorio<Material> materialRepository)
		{
			_MaterialService = materialService;
			_MaterialRepository = materialRepository;
		}

		[Route("Material")]
		[Route("Material/{id}")]
		public ActionResult Index(int id = 0)
		{
			ViewBag.QuantMaxLinhasPorPagina = 10;
			var matView = new MaterialViewModel();

			//edicao
			if (id > 0)
			{
				var material = _MaterialRepository.GetById(id);
				matView = new MaterialViewModel()
				{
					Id = id,
					Codigo = material.Codigo,
					Nome = material.Nome,
					UnidadeMedida = material.UnidadeMedida,
				};
			}

			var materiales = _MaterialRepository.GetAll();
			matView.Cadastrados = materiales.ToList();

			return View(matView);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("Material/Edit")]
		[Route("Material/Edit/{id}")]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				_MaterialService.Save(id, Convert.ToString(collection["Codigo"]),
									  Convert.ToString(collection["Nome"]),
									  Convert.ToString(collection["UnidadeMedida"]),
									  true);

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ViewBag.Erros = "!";
				return RedirectToAction(nameof(Index));
			}
		}

		[Route("Material/Delete/{id}")]
		public ActionResult Delete(int id)
		{
			try
			{
				_MaterialService.Save(id, string.Empty, string.Empty, string.Empty, false);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}


		[HttpPost]
		[Route("Material/Listar")]
		public JsonResult Listar(string Prefix)
		{
			var forn = _MaterialService.GetAll()
										 .Where(x => x.Nome.ToUpper().Contains(Prefix.ToUpper()))
										 .Select(x => new { Nome = x.Nome, Id = x.Id })
										 .ToList();
			return Json(forn);
		}
	}
}
