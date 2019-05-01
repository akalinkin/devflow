using System;
using GitLabCli.Dal;
using Microsoft.Extensions.Configuration;

namespace GitLabCli.Console
{
    public class Config 
    {
        public GitLabConfig GitLabConfig { get; set; }

        public Config(IConfiguration configuration) {
            GitLabConfig = new GitLabConfig();
            // TODO: SetValuesFromConfigFile`
            SetValuesFromEnvironment(configuration);
        }

        private void SetValuesFromEnvironment(IConfiguration c) {
            if (c[GitLabConfig.CONFIG_VAR_FDQN] != null) 
                GitLabConfig.GitLabUrl = new Uri(c[GitLabConfig.CONFIG_VAR_FDQN]);
            if (c[GitLabConfig.CONFIG_VAR_PERSONAL_ACCESS_TOKEN] != null) 
                GitLabConfig.GitLabPersonalAccessToken = c[GitLabConfig.CONFIG_VAR_PERSONAL_ACCESS_TOKEN];
        }
    }

    public class GitLabConfig : IGitLabConfig
    {
        public const string CONFIG_VAR_FDQN = "GITLAB_FQDN";
        public const string CONFIG_VAR_PERSONAL_ACCESS_TOKEN = 
            "GITLAB_PERSONAL_ACCESS_TOKEN";

        /// <summary>
        /// FDQN to GitLab instance
        /// </summary>
        /// <value>http://gitlab.yourbdomain.com:443</value>
        public Uri GitLabUrl { get; set; }

        /// <summary>
        /// GitLab Personal Access Token
        /// </summary>
        /// <see href="https://docs.gitlab.com/ee/user/profile/personal_access_tokens.html" />
        /// <value>tokenvalue</value>
        public string GitLabPersonalAccessToken { get; set; }
    }
}
