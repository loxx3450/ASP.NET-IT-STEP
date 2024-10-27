using hw_24._10._24.Models;

namespace hw_24._10._24
{
	public interface IFoodService
	{
		Task<IEnumerable<Food>> GetFoodList();
		Task AddFood(Food food);
	}
}
