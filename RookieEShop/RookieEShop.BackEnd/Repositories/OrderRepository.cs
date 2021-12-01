using Microsoft.EntityFrameworkCore;
using RookieEShop.BackEnd.Data;
using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IStorageService _storageService;

		public OrderRepository(ApplicationDbContext dbContext, IStorageService storageService)
		{
			_dbContext = dbContext;
			_storageService = storageService;
		}

		public async Task<IEnumerable<OrderVm>> GetAddressShipping(string userId)
		{
			var listOrder = await _dbContext.Orderings
									.Include(x => x.OrderDetail).ThenInclude(x => x.Product)
									.Include(x => x.ShippingAddress)
									.Where(x => x.UserId.Equals(userId))
									.AsNoTracking()
									.ToListAsync();

			var listVm = listOrder.Select(x => new OrderVm
			{
				OrderId = x.Id,
				UserId = x.UserId,
				CreatedAt = x.CreatedAt,
				BillDay = x.BillDate,
				Coupon = x.CouponName,
				DeliveryDay = x.DeliveryDate,
				Note = x.OrderNote,
				StatusCart = x.StatusCart,
				TaxAmount = x.TaxAmount,
				ShippingMethod = x.ShippingMethod,
				PaymentFee = x.PaymentFee,
				ShippingFee = x.ShippingFee,
				PaymentMethod = x.PaymentMethod,
				ShippingAddressId = x.ShippingAddressId,
				OrderName = x.OrderName,
				OrderDetail = x.OrderDetail.Select(index => new OrderDetailVm
				{
					Qty = index.Qty,
					Discount = index.Discount,
					ProductId = index.ProductId,
					Price = index.Price,
					ProductName = index.Product.Name,
					ThumbnailImageUrl = _storageService.GetFileUrl(index.Product.ImageFileName)
				}).ToList(),
				OrderAddressForm = new OrderAddressVm
				{
					ContactName = x.ShippingAddress.Name,
					HomeAddress = x.ShippingAddress.Address,
					OrderCity = x.ShippingAddress.City,
					OrderDistrict = x.ShippingAddress.District,
					PhoneNumber = x.ShippingAddress.Phone
				}
			}).ToList();


			return listVm;
		}

		public async Task<bool> AddOrder(Ordering order)
		{
			_dbContext.Orderings.Add(order);

			if (await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public async Task<bool> ChangeStatus(int id, OrderEdit edit)
		{
			if (edit == null)
			{
				return false;
			}

			var order = await _dbContext.Orderings
								.Where(x => x.Id.Equals(id))
								.SingleAsync();

			order.StatusCart = edit.Status;
			order.LastUpdated = DateTime.Now;

			if (await _dbContext.SaveChangesAsync() > 0)
			{
				return true;
			}

			else
			{
				return false;
			}
		}
	}
}
