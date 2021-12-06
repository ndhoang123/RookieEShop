using RookieEShop.Shared;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public interface ICheckOutRepository
	{
		Task<DeliveryInformationVm> GetShipping(string userId);
	}
}
