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

        public List<ToolStripItem>? ContextMenuItems { get; set; }
    }
}
