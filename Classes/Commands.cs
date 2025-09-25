using System;
using System.Collections.Generic;
using CyberDog.Interfaces;

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

    public class CommandItem : IUpdatableItem
    {
        public string Key { get; set; } = Guid.NewGuid().ToString();
        public required string Value { get; set; } 
        public CommandStatus Status { get; set; } = CommandStatus.New;
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? Result { get; set; }
        public string? Errors { get; set; }
        public override string ToString()
        {
            return $"{Key} - {Status}";
        }
    }
}
