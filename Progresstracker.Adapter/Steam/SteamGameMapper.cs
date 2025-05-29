using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Adapter.Steam
{
    public class SteamGameMapper
    {
        public static Game MapToGame(SteamGameInfo info)
        {
            return new Game
            {
                Id = Guid.NewGuid(),
                Title = info.Name,
                ExternalIds = new List<GameSourceIdentifier>
            {
                new() { Source = "Steam", ExternalId = info.AppId }
            }
            };
        }
    }

}
