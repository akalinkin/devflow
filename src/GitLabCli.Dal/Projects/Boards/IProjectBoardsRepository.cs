using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitLabCli.Dal.Projects.Boards
{
    public interface IProjectBoardsRepository
    {
        Task<IEnumerable<BoardList>> GetLists(uint projectId, uint boardId);
    }
}
