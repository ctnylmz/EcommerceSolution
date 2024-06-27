using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementation
{
    public class EmployeeRepo : IEmployee
    {
        private readonly AppDbContext _context;

        public EmployeeRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            if (employee == null)
                return new ServiceResponse(false, "User not found");

            _context.Employees.Remove(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }

        public async Task<List<Employee>> GetAsync() => await _context.Employees.AsNoTracking().ToListAsync();
      
        public async Task<Employee> GetByIdAsync(int Id) => await _context.Employees.FindAsync(Id);


        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {

            _context.Employees.Update(employee);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }

        private async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
