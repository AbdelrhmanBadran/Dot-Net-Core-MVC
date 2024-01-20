using Demo.BLL.Interface;
using Demo.DAL.Context;
using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MVCdbContext context;

        public DepartmentRepository(MVCdbContext context)
        {
            this.context = context;
        }
        public int Add(Department department)
        {
           context.Departments.Add(department); return context.SaveChanges();
        }

        public int Delete(Department department)
        {
            context.Departments.Remove(department); return context.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartments()
        => context.Departments.ToList();

        public Department GetDepartmentById(int? id)
        {
         
            return context.Departments.FirstOrDefault(x => x.Id == id);
        }
        

        public int Update(Department department)
        {
            context.Departments.Update(department);
            return context.SaveChanges();
        }
    }
}
