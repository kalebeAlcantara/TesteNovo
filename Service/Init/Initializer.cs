using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositorios.Entidades;
using Infra.Context;
using Infra.Repositorios;
using Infra.Repositorios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aplication.Init
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<SQLContext>(options => options.UseSqlServer(conection));

            //injeção de dependencias
            services.AddScoped(typeof(IRepositorio<Fornecedor>), typeof(FornecedorRepositorio));
            services.AddScoped(typeof(IRepositorio<Material>), typeof(MaterialRepositorio));
            services.AddScoped(typeof(IRepositorio<Movimentacao>), typeof(MovimentacaoRepositorio));

			services.AddScoped(typeof(Domain.Interfaces.Entidades.IFornecedorServico), typeof(FornecedorServico));
			services.AddScoped(typeof(Domain.Interfaces.Entidades.IMaterialServico), typeof(Domain.Repositorios.Entidades.MaterialServico));
			services.AddScoped(typeof(Domain.Interfaces.Entidades.IMovimentacaoServico), typeof(Domain.Repositorios.Entidades.MovimentacaoServico));

			services.AddScoped(typeof(FornecedorServico));
            services.AddScoped(typeof(MaterialServico));
            services.AddScoped(typeof(MovimentacaoServico));

            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
			

		}
    }
}
