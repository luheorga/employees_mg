using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MasGlobal.Employees.Configuration;
using MasGlobal.Employees.Data.Abstractions;
using Microsoft.Extensions.Options;

namespace MasGlobal.Employees.Data
{
    public class EmployeesAPIRepository : IEmployeesRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        private readonly string _apiUrl; 

        public EmployeesAPIRepository(IHttpClientFactory clientFactory, IOptionsSnapshot<ApiConfiguration> optionsSnapshot)
        {
            _clientFactory = clientFactory;
            _apiUrl = optionsSnapshot.Value.EmployeeApiUrl;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
           return await InternalGetEmployees();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return (await InternalGetEmployees())
                .Single(employee => employee.Id == id);
        }

        private async Task<IEnumerable<Employee>> InternalGetEmployees()
        {
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(CreateRequestMessage());
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<Employee>>();
        }

        private HttpRequestMessage CreateRequestMessage()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _apiUrl);
            request.Headers.Add("Accept", "application/json");
            return request;
        }

    }
}