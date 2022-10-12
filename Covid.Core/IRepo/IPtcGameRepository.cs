using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid.Core.DBEntities.PTC;

namespace Covid.Core.IRepo
{
   public interface IPtcGameRepository
    {
        void UpadteGameStatusInDB(int GameId, int Status);
         int GetGameStatus(int GameId);
        List<mPTC> GetGames(int Status);
        void InertGameInDB(int GameId, int Status);
    }
}
