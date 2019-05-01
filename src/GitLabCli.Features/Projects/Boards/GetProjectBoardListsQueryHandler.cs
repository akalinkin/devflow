using System.Collections.Generic;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using GitLabCli.Features.Exceptions;
using System.Linq;
using System;
using GitLabCli.Dal.Projects.Boards;

namespace GitLabCli.Features.Projects.Boards
{
    public class GetProjectBoardListQueryHandler : 
        IRequestHandler<GetProjectBoardListQuery, IEnumerable<BoardList>>
    {
        private readonly IProjectBoardsRepository _repo;

        public GetProjectBoardListQueryHandler(IProjectBoardsRepository projectBoardsRepository)
        {
            _repo = projectBoardsRepository ?? throw new ArgumentNullException(nameof(projectBoardsRepository));
        }

        public async Task<IEnumerable<BoardList>> Handle(
            GetProjectBoardListQuery request, 
            CancellationToken cancellationToken)
        {

            return await _repo.GetLists(request.ProjectId, request.BoardId);  
        }
    }
}
