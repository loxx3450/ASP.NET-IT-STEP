using hw_24._10._24.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw_24._10._24.Controllers
{
	public class FoodController : Controller
	{
		private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public async Task<IActionResult> GetFoodList()
		{
			return View(await _foodService.GetFoodList());
		}

		public IActionResult AddFood()
		{
			return View();
		}

		public IActionResult ReturnBack()
		{
			return RedirectToAction(nameof(GetFoodList));
		}

		[HttpPost]
		public async Task<IActionResult> AddFood(Food food)
		{
			await _foodService.AddFood(food);

			return RedirectToAction(nameof(GetFoodList));
		}
	}
}
