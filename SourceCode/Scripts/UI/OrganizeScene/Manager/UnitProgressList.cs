using Assets.Scripts.Manager;
using System.Collections.Generic;

namespace Assets.Scripts.UI.OrganaizeScene.Manager
{
    public class UnitProgressList
    {
        private static Dictionary<UnitKindIs, StageList> ProgressList = new Dictionary<UnitKindIs, StageList>()
        {
            {UnitKindIs.NormalUnit,StageList.Stage0},
            {UnitKindIs.Dragoon,StageList.Stage1},
            {UnitKindIs.Ninja,StageList.Stage4},
            {UnitKindIs.Samurai,StageList.Stage6},
            {UnitKindIs.Magi,StageList.Stage4},
            {UnitKindIs.Gunman,StageList.Stage0},
            {UnitKindIs.Sniper,StageList.Stage1},
            {UnitKindIs.Launcher,StageList.Stage1},
            {UnitKindIs.Fighter,StageList.Stage2},
            {UnitKindIs.Ranger,StageList.Stage0},
            {UnitKindIs.Nobody,StageList.Stage0},
        };

        public StageList getListData(UnitKindIs kind)
        {
            return ProgressList[kind];
        }
    }
}