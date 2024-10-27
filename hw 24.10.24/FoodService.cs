using hw_24._10._24.Models;

namespace hw_24._10._24
{
	public class FoodService : IFoodService
	{
		private List<Food> _foodList;

        public FoodService()
        {
            _foodList = new List<Food>()
			{
				new Food() { Title = "Apple", Weight = 0.2, Price = 0.5 },
				new Food() { Title = "Banana", Weight = 0.15, Price = 0.3 },
				new Food() { Title = "Bread", Weight = 0.5, Price = 1.2 },
				new Food() { Title = "Milk", Weight = 1.0, Price = 0.9 },
				new Food() { Title = "Cheese", Weight = 0.3, Price = 2.5 }
			};
		}

        public Task<IEnumerable<Food>> GetFoodList()
		{
			return Task.FromResult<IEnumerable<Food>>(_foodList);
		}

		public Task AddFood(Food food)
		{
			_foodList.Add(food);

			return Task.CompletedTask;
		}
	}
}
