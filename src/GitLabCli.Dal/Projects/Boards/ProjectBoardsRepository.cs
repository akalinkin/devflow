using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitLabCli.Dal.Projects.Boards
{
    public class ProjectBoardsRepository : IProjectBoardsRepository
    {
        private readonly IGitLabConfig _config;

        public ProjectBoardsRepository(IGitLabConfig config) {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        public async Task<IEnumerable<BoardList>> GetLists(uint projectId, uint boardId) {
            var endpoint = $"{_config.GitLabUrl}/api/v4/projects/{projectId}/boards/{boardId}/lists";
            using (HttpClient client = new HttpClient()) {
                client.BaseAddress = _config.GitLabUrl;
                client.Timeout = TimeSpan.FromSeconds(30);
                var httpRequestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(endpoint),
                    Headers = { 
                        { "PRIVATE-TOKEN", _config.GitLabPersonalAccessToken }
                    }
                };


                using (HttpResponseMessage response = await client.SendAsync(httpRequestMessage))
                using (HttpContent content = response.Content)
                {
                    string requestResult = await content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<BoardList>>(requestResult);
                }
            }
            
            // TODO: Move this code to Test HttpCliend Mock responce
            // var result = new List<BoardList>() {
            //     new BoardList() {
            //         Id = 1,
            //         Label = new Label() {
            //             Id = 21,
            //             Name = "List 1",
            //             Color = "#CC0000",
            //             Description = "Some description"

            //         },
            //         Position = 0
            //     },
            //     new BoardList() {
            //         Id = 2,
            //         Label = new Label() {
            //             Id = 22,
            //             Name = "List 2",
            //             Color = "#FF0000",
            //             Description = null
            //         },
            //         Position = 1
            //     }
            // };

            // return await Task.FromResult(result);
        }
    }
}
