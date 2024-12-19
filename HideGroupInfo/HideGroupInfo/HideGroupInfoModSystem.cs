using HarmonyLib;
using Vintagestory.API.Server;
using Vintagestory.API.Common;
using Vintagestory.Server;

namespace HideGroupInfo;

public class HideGroupInfoModSystem : ModSystem
{
    public override void StartServerSide(ICoreServerAPI api)
    {
        var harmony = new Harmony(Mod.Info.ModID);

        var original = AccessTools.Method(typeof(ServerySystemPlayerGroups), "CmdgroupInfo");
        var patch = AccessTools.Method(typeof(GroupInfoPatch), nameof(GroupInfoPatch.Prefix));

        harmony.Patch(original, new HarmonyMethod(patch));
    }

}