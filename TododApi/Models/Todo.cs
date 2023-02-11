using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TododApi.Models
{
	public class Todo
	{
		[Key]
		public int todoId { get; set; }

		[ForeignKey("User")]
		public int userId { get; set; }
		public virtual User User { get; set; }

		public string description { get; set; }

		public bool done { get; set; }
	}
}

