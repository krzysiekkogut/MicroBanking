using MicroBanking.Transfer.Application.Interfaces;
using MicroBanking.Transfer.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Transfer.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService transferService;

        public TransferController(ITransferService transferService)
        {
            this.transferService = transferService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransferLog>>> GetAllTransferLogsAsync()
        {
            return Ok(await transferService.GetAllAsync());
        }
    }
}