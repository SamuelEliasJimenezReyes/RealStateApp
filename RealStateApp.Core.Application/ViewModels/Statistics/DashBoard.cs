using RealStateApp.Core.Application.Dtos.User;
using RealStateApp.Core.Application.ViewModels.Agents;
using RealStateApp.Core.Application.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateApp.Core.Application.ViewModels.Statistics
{
    public class DashBoard
    {
        public int Propierties { get; set; }
        public int ActiveAgents { get; set; }
        public int InActiveAgents { get; set; }
        public int ActiveClients { get; set; }
        public int InActiveClients { get; set; }
        public int ActiveDeveloper { get; set; }
        public int InActiveDeveloper { get; set; }

    }
}
