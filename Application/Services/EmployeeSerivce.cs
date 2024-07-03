using Application.Contracts;
using Application.DTOs;
using Domain.Entitites;
using System;
using System.Net.Http.Json;

namespace Application.Services
{
    public class EmployeeSerivce : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeSerivce(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(Employee employee)
        {
            var data = await _httpClient.PostAsJsonAsync("https://localhost:7283/api/employee", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteAsync(int Id)
        {
            var data = await _httpClient.DeleteAsync($"api/employee/{Id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<List<Employee>> GetAsync() =>
            await _httpClient.GetFromJsonAsync<List<Employee>>("api/employee")!;


        public async Task<Employee> GetByIdAsync(int Id) =>
            await _httpClient.GetFromJsonAsync<Employee>($"api/employee/{Id}")!;


        public async Task<ServiceResponse> UpdateAsync(Employee employee)
        {
            var data = await _httpClient.PutAsJsonAsync("api/employee", employee);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}