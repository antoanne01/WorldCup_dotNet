using CupInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCup_WinForm.Events
{
    public class FavoriteTeamEvents : EventArgs
    {
        public Team FavoriteTeam { get; set; }
    }
}
