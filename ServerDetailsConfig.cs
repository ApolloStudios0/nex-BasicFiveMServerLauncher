using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nex_FiveMServerLauncher
{
    public class ServerDetailsConfig
    {
        // [---------------------------------------]
        // [----------- Server Details ------------]
        // [---------------------------------------]

        // What text to display in the top left corner of the program
        public static string ProgramTitle { get; set; } = "PROGRAM_TITLE_HERE";

        // What text to display as the server title
        public static string ServerName { get; set; } = "SERVER_NAME_HERE";

        // Your Server IP & Port. The below is CMG Roleplay (An Example) This is to load the player names, statistics & ping.
        public static string ServerIPandPort { get; set; } = "IP_HERE"; // Your server IP & Port (https://www.game-state.com/index.php?game=fivem)

        // Server Connection ID (Used for the "Connect" button)
        public static string ServerConnectionID { get; set; } = "ej3qyb";


        // [---------------------------------------]
        // [---------- Discord & Website ----------]
        // [---------------------------------------]

        // Set Discord Join URL (MAKE SURE THIS IS A PERMENANT INVITE)
        public static string DiscordServerJoinUrl { get; set; } = "https://discord.gg/d8Uj6XZA"; // Some Random Example Discord I Found

        // Set Your Website URL
        public static string WebsiteURL { get; set; } = "www.google.com";


        // [---------------------------------------]
        // [--------- Right Side Logging ----------]
        // [---------------------------------------]

        // SQL Connection For Development Updates
        public static string DevelopmentUpdatesURL { get; set; }

        // If you're showing Development Logs change this to "Development Logs" or something similiar
        // If you're showing server rules enter something else like "Server Rules"
        public static string WhatTitleToDisplayForLogs { get; set; } = "Server Rules";

        // Where is your raw text for server rules OR development logs? (Example https://raw.githubusercontent.com/NebulaFX/nex-BasicFiveMServerLauncher/main/ServerLogsExample.txt)
        public static string RawTextSourceURL { get; set; } = "https://raw.githubusercontent.com/NebulaFX/nex-BasicFiveMServerLauncher/main/ServerLogsExample.txt";
    }
}
