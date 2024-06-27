using Application.DTOs;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IEmployee
    {
        Task<ServiceResponse> AddAsync(Employee employee);
        Task<ServiceResponse> UpdateAsync(Employee employee);
        Task<ServiceResponse> DeleteAsync(int Id);
        Task<List<Employee>> GetAsync();
        Task<Employee> GetByIdAsync(int Id);
    }
}
