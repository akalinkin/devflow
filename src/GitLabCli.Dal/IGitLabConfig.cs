using System;

namespace GitLabCli.Dal 
{
    public interface IGitLabConfig
    {
        Uri GitLabUrl { get; set; }
        string GitLabPersonalAccessToken { get; set; }
    }
}
