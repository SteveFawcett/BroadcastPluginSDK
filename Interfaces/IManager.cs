using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BroadcastPluginSDK.Interfaces
{
    public interface IManager
    {
        public event EventHandler<bool> TriggerRestart;

        public event EventHandler<UserControl> ShowScreen;

        public event EventHandler WriteConfiguration;

        public bool Locked { get; set; } // True if the manager is locked and the application should not allow restart.

        public List<ToolStripItem>? ContextMenuItems { get; set; }
    }
}
