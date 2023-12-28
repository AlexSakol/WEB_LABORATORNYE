using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Data;
using WEB.Data;
using Microsoft.EntityFrameworkCore;
using Serilog.Data;

namespace WEB.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context;
        //ILogger<ProductController> _logger;

        private int _pageSize;

        public ProductController(ApplicationDbContext dbContext/*, ILogger<ProductController> logger*/)
        {
            context = dbContext;
            _pageSize = 3;
            //_logger = logger;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public async Task<IActionResult> Index(int? section, int pageNo = 1)
        {
            var goodsFiltered = context.Goods.Where(g => !section.HasValue || g.SectionId == section.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = await context.Sections.ToListAsync();
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = section ?? 0;
            //_logger.LogInformation($"info: section={section}, page={pageNo}");
            return View(ListViewModel<Good>
            .GetModel(goodsFiltered, pageNo, _pageSize));
        }  
        
    }
}
