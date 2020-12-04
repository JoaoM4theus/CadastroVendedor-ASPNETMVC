using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasProjetoFbUni.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasProjetoFbUni.Services
{
    public class DepartmentService
    {
        private readonly VendasProjetoFbUniContext _context;

        public DepartmentService(VendasProjetoFbUniContext context)
        {
            _context = context;
        }
        
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
