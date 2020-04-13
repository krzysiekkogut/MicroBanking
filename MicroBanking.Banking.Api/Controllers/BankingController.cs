using System.Collections.Generic;
using System.Threading.Tasks;
using MicroBanking.Banking.Application.Interfaces;
using MicroBanking.Banking.Application.Models;
using MicroBanking.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroBanking.Banking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService accountService;

        public BankingController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllAcountsAsync()
        {
            return Ok(await accountService.GetAllAsync());
        }

        [HttpPost]
        public ActionResult PostAccountTransfre([FromBody] AccountTransfer accountTransfer)
        {
            accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}