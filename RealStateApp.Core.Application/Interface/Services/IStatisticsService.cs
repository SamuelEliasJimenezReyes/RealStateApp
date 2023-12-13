using RealStateApp.Core.Application.ViewModels.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealStateApp.Core.Application.Interface.Services
{
    public interface IStatisticsService
    {
        Task<DashBoard> GetDashBoard();
    }
}
