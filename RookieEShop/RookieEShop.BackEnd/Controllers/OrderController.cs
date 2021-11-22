using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RookieEShop.BackEnd.Models;
using RookieEShop.BackEnd.Services;
using RookieEShop.Shared;
using System;
using System.Threading.Tasks;

namespace RookieEShop.BackEnd.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize("Bearer")]
	public class OrderController : Controller
	{
		private readonly IOrderService _IOrderService;
		private readonly IOrderAddressService _IOrderAddress;

		public OrderController (IOrderService IOrderService, IOrderAddressService IOrderAddress)
		{
			_IOrderService = IOrderService;
			_IOrderAddress = IOrderAddress;
		}

		[HttpGet("{id}")]
		[AllowAnonymous]
		public async Task<ActionResult> GetList(string id)
		{
			var listOrder = await _IOrderService.GetAddressShipping(id);

			return Ok(listOrder);
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<ActionResult> AddOrder(OrderVm order)
		{
			var orders = new Ordering
			{
				CreatedAt = DateTime.Now,
				UserId = order.UserId,
				TaxAmount = order.TaxAmount,
				DeliveryDate = order.DeliveryDay,
				BillDate = order.BillDay,
				CouponName = order.Coupon,
				OrderNote = order.Note,
				ShippingMethod = order.ShippingMethod,
				ShippingFee = order.ShippingFee,
				PaymentFee = order.PaymentFee,
				PaymentMethod = order.PaymentMethod
			};

			foreach(var i in order.OrderDetail)
			{
				orders.OrderDetail.Add(new OrderDetail 
				{ 
					ProductId = i.ProductId, 
					Discount = i.Discount,
					Price = i.Price,
					Qty = i.Qty
				});
			}

			if (_IOrderAddress.GetCurrentAddress(order.ShippingAddressId) == null)
			{
				orders.ShippingAddress.Address = order.OrderAddressForm.HomeAddress;
				orders.ShippingAddress.City = order.OrderAddressForm.OrderCity;
				orders.ShippingAddress.District = order.OrderAddressForm.OrderDistrict;
				orders.ShippingAddress.Name = order.OrderAddressForm.ContactName;
				orders.ShippingAddress.Phone = order.OrderAddressForm.PhoneNumber;
			}

			else
			{
				orders.ShippingAddressId = order.ShippingAddressId;
			}

			if (await _IOrderService.AddOrder(orders))
			{
				return StatusCode(201);
			}

			else
			{
				return StatusCode(400);
			}
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> ChangeOrderStatus(int id, OrderEdit edit)
		{
			if (id <= 0) return StatusCode(400);
			
			if(await _IOrderService.ChangeStatus(id, edit))
			{
				return StatusCode(204);
			}

			else
			{
				return StatusCode(404);
			}
		}
	}
}
