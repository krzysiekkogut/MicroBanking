using MicroBanking.UI.Models;
using MicroBanking.UI.Models.Dto;
using MicroBanking.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroBanking.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly ITransferService transferService;

        public BankingController(ITransferService transferService)
        {
            this.transferService = transferService;
        }

        [HttpPost]
        public async Task<ActionResult> Transfer([FromBody] TransferViewModel model)
        {
            var dto = new TransferDto
            {
                SourceAccountId = model.SourceAccountId,
                TargetAccountId = model.TargetAccountId,
                Amount = model.Amount
            };
            await transferService.Transfer(dto);

            return Ok();
        }
    }
}