using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
	public class DevFreelaDbContext
	{
		public DevFreelaDbContext()
		{
			Projects = new List<Project>
			
			{
				new Project("Asp.Net Core Web Application Clean Architecture", "All about Asp.net Core and patterns", 1, 1, 1000),	
				new Project("Html, Css and Javascript - make your first web page", "Make responsive page webs", 1, 1, 2000)	
			};
			
			Users = new List<User>
			
			{
				new User("Paulo Ricardo", "paulo@devweb.com", new DateTime(1996, 06, 04), true),	
				new User("Martin", "martin@devweb.com", new DateTime(1979, 01, 30), true),	
			};
			
			Skills = new List<Skill>
			
			{
				new Skill("C#"),	
				new Skill("SQL Server"),	
				new Skill("JavaScript"),	
			};
		}
		
		
		public List<Project> Projects { get; set; }
		public List<User> Users { get; set; }
		public List<Skill> Skills { get; set; }
	}
}