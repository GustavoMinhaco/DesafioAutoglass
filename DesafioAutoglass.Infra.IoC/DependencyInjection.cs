using DesafioAutoglass.Application.Interfaces;
using DesafioAutoglass.Domain.Interfaces;
using DesafioAutoglass.Infra.Data.Context;
using DesafioAutoglass.Infra.Data.Repositories;
using DesafioAutoglass.Application.Mapeamentos;
using DesafioAutoglass.Application.Servicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMVC.Infra.IoC
{

    //Cross Cutting
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration)
        {

            /* - registrando o contexto ApplicationDbContext
             * - definindo o provedor do banco de dados
             * - definindo a string de conexão
             * - informando que a migração vai ficar na mesma pasta definido o arquivo de contexto, no Projeto Infra.Data
            */
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // registrando os repositórios
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            // registrando os serviços
            services.AddScoped<IProdutoService, ProdutoService>();

            // registrando AutoMapper
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
