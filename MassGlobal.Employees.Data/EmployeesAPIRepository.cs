using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MasGlobal.Employees.Data.Abstractions;

namespace MasGlobal.Employees.Data
{
    public class EmployeesAPIRepository : IEmployeesRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        private const string ApiUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";

        public EmployeesAPIRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
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
            var request = new HttpRequestMessage(HttpMethod.Get, ApiUrl);
            request.Headers.Add("Accept", "application/json");
            return request;
        }

    }
}