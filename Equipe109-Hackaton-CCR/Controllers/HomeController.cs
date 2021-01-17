using Equipe109_Hackaton_CCR.Data;
using Equipe109_Hackaton_CCR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Equipe109_Hackaton_CCR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context,ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            List<VagasModel> vModel = new List<VagasModel>();
            var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                var userId = claim.Value;
                var EmpresaLogin = await _context.EmpresaLogin.ToListAsync();
                var isTrue = EmpresaLogin.Where(x => x.Id == userId).FirstOrDefault();


                if (isTrue.isEmpresa)
                    vModel = await _context.VagasModel.ToListAsync();

                Home home = new Home { vagasModels = vModel, Id = Guid.NewGuid() };
                return View(home);
            }
            Home homebk = new Home { vagasModels = vModel, Id = Guid.NewGuid() };
            return View(homebk);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
