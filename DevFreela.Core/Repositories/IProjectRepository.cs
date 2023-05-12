using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
	public interface IProjectRepository
	{
		Task<List<Project>> GetAll();
		Task<Project> GetById(int id);
	}
}