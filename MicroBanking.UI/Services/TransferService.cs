using MicroBanking.UI.Models.Dto;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroBanking.UI.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient httpClient;

        public TransferService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5011/api/banking";
            var content = new StringContent(
                JsonConvert.SerializeObject(transferDto),
                Encoding.UTF8,
                "application/json");
            var response = await httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
