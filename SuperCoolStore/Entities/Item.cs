namespace SuperCoolStore.Entities
{
	public class Item
	{
		private static int _currentId;

		private static int CurrentId
		{
			get
			{
				_currentId++;
				return _currentId;
			}
		}

		public int Id { get; init; }
		public string Name { get; init; }
		public decimal Price { get; init; }
		public float Weight { get; init; }
		public bool HasDiscountOnCash { get; init; }
		public float DiscountPercentage { get; init; }
	}
}
