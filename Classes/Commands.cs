using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadcastPluginSDK.Classes
{
    public enum CommandStatus
    {
        New,
        Queued,
        InProgress,
        Completed,
        Failed
    }

    public class CommandItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string Command { get; set; } = string.Empty;
        public CommandStatus Status { get; set; } = CommandStatus.New;
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? Result { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Status}";
        }
    }
}
