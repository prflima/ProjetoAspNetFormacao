using System;

namespace DevFreela.Core.Exceptions

{
	public class ProjectAlreadyStatusException : Exception
	
	{
		public ProjectAlreadyStatusException() : base("Project is already in Started status")
		{
			
		}
	}
}