using System;
using System.Linq;
using System.Collections.Generic;

namespace SuperCoolStore.Entities
{
	public class Order
	{
		private readonly List<Item> _items = new();
		private readonly float _orderDistance;
		private readonly decimal _shippingFee;

		public IReadOnlyList<Item> Items => _items.AsReadOnly();

		public Order(float distance, IEnumerable<Item> items, decimal shippingFee)
		{
			_items.AddRange(items);
			_orderDistance = distance;
			_shippingFee = shippingFee;
		}

		public decimal GetSubtotal()
		{
			return _items.Aggregate(
				decimal.Zero,
				(result, item) => result + item.Price,
				result => result
			);
		}

		public decimal GetShippingFee()
		{
			return _items.Aggregate(
				decimal.One,
				(result, item) => result + CalculateShippingFee(_orderDistance, item.Weight, _shippingFee),
				result => result
			);
		}

		public decimal GetTotal()
		{
			var subtotal = GetSubtotal();

			if (subtotal > 200m)
				return subtotal;

			return GetShippingFee() + subtotal;
		}

		public static decimal CalculateShippingFee(float distance, float weight, decimal feePerKilometer)
		{
			const float minimumWeight = 20f;

			if (weight < minimumWeight)
				return 0;

			if (weight > minimumWeight)
            {
				feePerKilometer *= (int)Math.Ceiling(weight - minimumWeight);
            }

			return feePerKilometer * (int)Math.Ceiling(distance);
		}
	}
}
