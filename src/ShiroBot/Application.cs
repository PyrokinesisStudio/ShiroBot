﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord.Commands;
using Discord.WebSocket;
using NLog;

namespace ShiroBot
{
    public class Application
    {

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly Configuration _configuration;

        private readonly DiscordSocketClient _discordClient;

        private readonly CommandService _commandService;

        private readonly EventHandler _eventHandler;

        public Application(Configuration configuration)
        {
            _configuration = configuration;
            var dependencyMap = new DependencyMap();
            _discordClient = new DiscordSocketClient(new DiscordSocketConfig
            {
                AudioMode = AudioMode.Disabled, // Disabled for now k.
                MessageCacheSize = 10,
                LogLevel = LogSeverity.Debug,
                ShardId = 1,
                TotalShards = 1
            });
            _commandService = new CommandService();
            _eventHandler = new EventHandler(_discordClient, _commandService, dependencyMap);

            dependencyMap.Add(_commandService);
            dependencyMap.Add(_eventHandler);
            dependencyMap.Add(_discordClient);
        }

        public async Task Run()
        {
            // Authenticate
            await _discordClient.LoginAsync(TokenType.Bot, _configuration.BotToken);
            // Connect
            await _discordClient.ConnectAsync();
            // Download all users so we don't have to do that later
            await _discordClient.DownloadAllUsersAsync();

            // Discover all of the commands in this assembly and load them.
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly());

            // Show information
            Logger.Info("Succesfully connected to Discord.");
            Logger.Info($"{"Username:",-10} {_discordClient.CurrentUser.Username}");
            Logger.Info($"{"Guilds:",-10} {_discordClient.Guilds.Count}");
            Logger.Info($"{"Commands:",-10} {_commandService.Commands.Count()}");

            // Register events
            // _discordClient.Log += _eventHandler.DiscordClientOnLog;
            _discordClient.MessageReceived += _eventHandler.DiscordClientOnMessageReceived;
        }

        public async Task Stop()
        {
            await _discordClient.DisconnectAsync();
        }

    }
}
