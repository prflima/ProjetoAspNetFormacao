using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
	public class ProjectViewModel
	{
		public ProjectViewModel(int id, string title, string description, DateTime createdAt)
		{
			Id = id;
			Title = title;
			Description = description;
			CreatedAt = createdAt;
		}
		
		public int Id { get; set; }
		public string Title { get; private set; }
		public string Description { get; private set; }
		public DateTime CreatedAt { get; private set; }
	}
}