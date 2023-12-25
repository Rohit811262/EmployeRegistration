using Microsoft.AspNetCore.Mvc;
using Repository.DBEntities;
using Services.Interface;
using Entities.BizEntites;

namespace EmployeRegistration.Controllers
{
    public class EmployeController : Controller
    {
        public IEmploye _employeService;
        private readonly ILogger<EmployeController> _logger;
        private readonly IConfiguration _configuration;
        private EmployeRegistrationTestDbContext _dbContext;

        [ActivatorUtilitiesConstructor]
        public EmployeController(
            IEmploye employeService,
            ILogger<EmployeController> logger,
            IConfiguration configuration,
            EmployeRegistrationTestDbContext dbContext)
        {
            _employeService = employeService;
            _logger = logger;
            _configuration = configuration;
            _dbContext = dbContext;
        }

     
        public async Task<IActionResult> Index()
        {
            IEnumerable<BizEmployeInfo> employeEntity = await _employeService.GetAll();
            return View(employeEntity);
        }
        public async Task<IActionResult> Create(int? id)
        {
            if (id != null && id > 0)
            {
                var _Eentity = await _employeService.GetById((int)id);
                return View(_Eentity);
            }
            else
            {

                return View(null);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BizEmployeInfo Emp)
        {

            if (ModelState.IsValid)
            {
                if (Emp.EmpId > 0)
                {
                    await _employeService.Update(Emp);
                }
                else
                {
                    await _employeService.Create(Emp);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _employeService.Delete(id);
                return RedirectToAction("Index");
            }

            // Handle invalid ID (optional)
            // You may want to add some error handling or redirect to an error page.
            return RedirectToAction("Index");
        }


    }
}

