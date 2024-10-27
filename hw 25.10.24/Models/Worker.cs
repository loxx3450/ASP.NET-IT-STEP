using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace hw_25._10._24.Models
{
	public class Worker
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public int Salary { get; set; }

		// Path to the file that is saved in wwwroot
        public string? PicturePath { get; set; }
	}
}
