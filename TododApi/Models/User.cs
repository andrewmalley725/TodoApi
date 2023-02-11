using System;
using System.ComponentModel.DataAnnotations;

namespace TododApi.Models
{
	public class User
	{
		[Key]
		[Required]
		public int userId { get; set; }

		public string username { get; set; }
	}
}

