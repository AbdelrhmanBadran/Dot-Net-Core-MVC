using Demo.BLL.Interface;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAllDepartments();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            {
                _departmentRepository.Add(department);
                return RedirectToAction("Index");
            }
           return View(department);
        }
        
        public IActionResult Details(int? id)
        {
            if(id is  null)
                return RedirectToAction("Error","Home");
            
            var department = _departmentRepository.GetDepartmentById(id);
            if(department == null)
                return NotFound();
            return View(department);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
                return RedirectToAction("Error", "Home");

            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
                return NotFound();
            return View(department);
        }
        [HttpPost]
        public IActionResult Update(int id,Department department)
        {

            if (id != department.Id)
            {
                return RedirectToAction("Error", "Home");
            }


            try
            {
                if (ModelState.IsValid)
                {
                    _departmentRepository.Update(department);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return View(department);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return RedirectToAction("Error", "Home");

            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
                return NotFound();
            _departmentRepository.Delete(department);
            return RedirectToAction("Index");
        }
    }
}
