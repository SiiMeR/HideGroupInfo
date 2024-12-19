using System.Linq;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.Server;

namespace HideGroupInfo;

public class GroupInfoPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ServerySystemPlayerGroups), "CmdgroupInfo")]
    public static bool Prefix(ref TextCommandResult __result, TextCommandCallingArgs args)
    {
        if (args.Caller.Player.Role.Code == "admin" || args.Caller.Player.Groups.Any(group => group.GroupName == args[0] as string))
        {
            return true;
        }
        
        __result = TextCommandResult.Error("This command is only available for members of this group and admins");
        return false;
    }
}