using System;
using System.Collections.Generic;

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
        public List<(Rectangle bounds, string label)> clickableBadges = new(); 

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Command { get; set; } 
        public CommandStatus Status { get; set; } = CommandStatus.New;
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? Result { get; set; }
        public string? Errors { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Status}";
        }
    }
}
