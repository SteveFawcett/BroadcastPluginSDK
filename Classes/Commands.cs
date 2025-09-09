using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastPluginSDK.Classes
{
    public enum Commands
    {
        START_FLIGHT_SIMULATOR,
        SHUTDOWN_SERVER,
    }
    public enum CommandStatus
    {
        New = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3
    }

    public class CommandItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Commands Command { get; set; } = Commands.START_FLIGHT_SIMULATOR;
        public CommandStatus Status { get; set; } = CommandStatus.New;
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? Result { get; set; }
    }
}
