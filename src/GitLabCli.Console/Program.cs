using System;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using GitLabCli.Features.Projects.Boards;
using GitLabCli.Dal.Projects.Boards;
using System.Linq;
using GitLabCli.Dal;

namespace GitLabCli.Console
{
    partial class Program
    {
        private static ILogger _logger;
        private static Config _config;
        private static IMediator _mediator;
        public static async Task<int> Main(string[] args)
        {
            // Figgle.FiggleFonts.Standard.Render("GitLab CLI");

            IConfiguration configuration = new ConfigurationBuilder()
                                        .AddEnvironmentVariables()
                                        .Build();
            _config = new Config(configuration);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);

            using (var serviceProvider = serviceCollection.BuildServiceProvider()) 
            {
                _logger = serviceProvider.GetService<ILogger<Program>>();
                _logger.LogDebug("Start GitLab CLI console");

                
                _logger.LogDebug($"Config: {JsonConvert.SerializeObject(_config)}");

                _mediator = serviceProvider.GetService<IMediator>();

                var cmd = "GetProjectBoardsLists";
                _logger.LogDebug($"Command: {cmd}");
                switch (cmd) {
                    case "GetProjectBoardsLists":
                        var projectId = (uint)3;
                        var boardId = (uint)1;
                        var command = new GetProjectBoardListQuery() {
                            ProjectId = projectId,
                            BoardId = boardId
                        };
                        var result = await _mediator.Send(command);
                        _logger.LogDebug($"GetProjectBoardsLists: {JsonConvert.SerializeObject(result)}");

                        PrintOutput(result);
                        PrintBoard(result);
                        break;
                    default:
                        throw new Exception($"Unknown command {cmd}");
                }
            }

            return await Task.FromResult(0);
        }

        public static void PrintOutput(IEnumerable<BoardList> data)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("{0,6} {1,-20} {2,-40}", 
                "Id", "Name", "Description");
            
            foreach(var item in data) {
                System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine("{0,6:D} {1,-20} {2,-40}", 
                    item.Id, item.Label.Name, item.Label.Description);
            }
            System.Console.ResetColor();
            System.Console.WriteLine();
        }

        public static void PrintBoard(IEnumerable<BoardList> data)
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine(
                "\tConsole width: " + System.Console.WindowWidth + 
                "\tConsole height: " +  System.Console.WindowHeight
            );
            System.Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("\tGoal: Do something usefull\n");
            System.Console.ResetColor();

            var names = new List<string>();
            foreach(var item in data) {
                names.Add(item.Label.Name);
            }
            var namesArray = names.ToArray();

            System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine("{0,-20} {1,-20} {2,-20} {3,-20}", 
                    names[0],names[1],names[2],names[3]);
            System.Console.ResetColor();
            System.Console.WriteLine();
        }

        private static void ConfigureServices(IServiceCollection services, 
                                            IConfiguration configuration)
        {
            ConfigureLogging(services, configuration);
            // Define one of the command or handler to get Assembly with all Commands/Queries/Handlers
            services.AddMediatR(typeof(GitLabCli.Features.Exceptions.NotFoundException).Assembly);
            // Config for repositories
            services.AddSingleton<IGitLabConfig>(_config.GitLabConfig);
            // Repositories
            services.AddScoped<IProjectBoardsRepository,ProjectBoardsRepository>();
        }

        private static void ConfigureLogging(IServiceCollection s, 
                                            IConfiguration c) 
        {
            s.AddLogging(configure => configure.AddConsole())                    
                .AddTransient<Program>();

            if (c["LOG_LEVEL"] != null) 
            {
                var level = LogLevelExtensions.FromString(c["LOG_LEVEL"]);
                s.Configure<LoggerFilterOptions>(
                    options => options.MinLevel = level
                );
            } 
            else
            {
                s.Configure<LoggerFilterOptions>(
                    options => options.MinLevel = LogLevel.Debug
                );
            }
        }
    }
}
