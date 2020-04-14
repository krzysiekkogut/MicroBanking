using MicroBanking.UI.Models.Dto;
using System.Threading.Tasks;

namespace MicroBanking.UI.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }
}
