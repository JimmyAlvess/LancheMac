using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LanchesMac.Areas.Servicos
{
    public class RelatorioLanchesService
    {
        private readonly ConfigurationImagens _myConfig;

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly AppDbContext _context;
        public RelatorioLanchesService(IWebHostEnvironment hostingEnvironment,
            IOptions<ConfigurationImagens> myConfiguration, AppDbContext contexto)
        {
            _hostingEnvironment = hostingEnvironment;
            _myConfig = myConfiguration.Value;
            _context = contexto;
        }

        public async Task<IEnumerable<Lanche>> GetLanchesReport()
        {
            var lanches = await _context.Lanches.ToListAsync();

            if(lanches is null)
            {
                return default(IEnumerable<Lanche>);
            }
            return lanches;
        }
        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var categorias = await _context.Categorias.ToListAsync();

            if (categorias is null)
            {
                return default(IEnumerable<Categoria>);
            }
            return categorias;
        }
    }
}
