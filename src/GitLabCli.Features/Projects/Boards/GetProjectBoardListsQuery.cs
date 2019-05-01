using System.Collections.Generic;
using GitLabCli.Dal.Projects.Boards;
using MediatR;

namespace GitLabCli.Features.Projects.Boards
{
    public class GetProjectBoardListQuery : IRequest<IEnumerable<BoardList>>
    {
        public uint ProjectId { get; set; }
        public uint BoardId { get; set; }
    }
}
