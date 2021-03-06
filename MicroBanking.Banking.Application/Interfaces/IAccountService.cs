﻿using MicroBanking.Banking.Application.Models;
using MicroBanking.Banking.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroBanking.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task TransferAsync(AccountTransfer accountTransfer);
    }
}
