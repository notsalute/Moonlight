using ApolloCore.API.QM;
using MelonLoader;
using Moonlight_Client.Modules;

namespace Modules
{
    public class UI
    {
        public static void QuickMenuInit()
        {
            var MainMenu = new QMTabMenu("Open <color=#bf42f5>Moonlight's</color> Menu", "<color=#bf42f5>Moonlight</color>", SpriteLoader.MakeSpriteFromImage(SpriteLoader.GetImageFromResources("moon")));

            #region World Menu
            var WorldMenu = new QMNestedButton(MainMenu, 1, 0, "Worlds", "Opens the World specific menu", "Worlds");

            var AmongUs = new QMNestedButton(WorldMenu, 1, 0, "Among Us", null, "Among Us");

            new QMSingleButton(AmongUs, 1, 0, "Start Game", delegate
            {
                Moonlight_Client.Functions.WorldOpt.forcestartAmong();
            }, "Forcefully starts the game");

            new QMSingleButton(AmongUs, 2, 0, "End Game", delegate
            {
                Moonlight_Client.Functions.WorldOpt.forceendAmong();
            }, "Just ends it lmao");

            new QMSingleButton(AmongUs, 3, 0, "Kill All", delegate
            {
                Moonlight_Client.Functions.WorldOpt.KillAll();
            }, "Ez win");

            new QMSingleButton(AmongUs, 4, 0, "Check Impostor", delegate
            {
                Moonlight_Client.Functions.BetterAmongCheats.LogImpostor();
            }, "Tells you who the impostor is via Console <color=#f00000>[FALSE POSITIVE / BROKEN]</color>");

            new QMSingleButton(AmongUs, 1, 1, "Give Impostor", delegate
            {
                Moonlight_Client.Functions.BetterAmongCheats.GiveImpos();
            }, "Forces you to have Impostor role");

            new QMSingleButton(AmongUs, 2, 1, "Skip Voting", delegate
            {
                Moonlight_Client.Functions.BetterAmongCheats.Skipvotes();
            }, "Imagine voting lmao skip that shit");

            new QMSingleButton(AmongUs, 3, 1, "End Voting", delegate
            {
                Moonlight_Client.Functions.BetterAmongCheats.FinishVotes();
            }, "Took too long so just end it");

            new QMSingleButton(AmongUs, 4, 1, "Eject Everyone", delegate
            {
                Moonlight_Client.Functions.BetterAmongCheats.ejecteveryone();
            }, "This is funny");

            new QMSingleButton(AmongUs, 1, 2, "Sabotage All", delegate
            {
                Moonlight_Client.Functions.BetterAmongCheats.sabotageeverything();
            }, "Try fixing this! crewmates!");

            new QMSingleButton(AmongUs, 2, 2, "Repair All", delegate
            {
                Moonlight_Client.Functions.BetterAmongCheats.RepairAll();
            }, "Call me Bob The Builder");

            var Murder4 = new QMNestedButton(WorldMenu, 2, 0, "Murder 4", null, "Murder 4");

            new QMSingleButton(Murder4, 1, 0, "Start Game", delegate
            {
                Moonlight_Client.Functions.WorldOpt.forcestartMurd();
            }, "Forcefully starts the game");

            new QMSingleButton(Murder4, 2, 0, "End Game", delegate
            {
                Moonlight_Client.Functions.WorldOpt.forceendMurd();
            }, "Just ends it lmao");

            new QMSingleButton(Murder4, 3, 0, "Kill All", delegate
            {
                Moonlight_Client.Functions.WorldOpt.KillAll();
            }, "Kills all bystanders, murderers & sherifs");

            new QMSingleButton(Murder4, 4, 0, "Murder Win", delegate
            {
                Moonlight_Client.Functions.WorldOpt.MurderWin();
            }, "Makes the Murder win");

            new QMSingleButton(Murder4, 1, 1, "Bystander Win", delegate
            {
                Moonlight_Client.Functions.WorldOpt.BystanderWin();
            }, "Makes the Bystander win");

            new QMSingleButton(Murder4, 2, 1, "Get Knife", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.Getknife();
            }, "Teleports the knife to you");

            new QMSingleButton(Murder4, 3, 1, "TP Nade", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.TpBOMBLOL();
            }, "Teleports the nade to you");

            new QMSingleButton(Murder4, 4, 1, "TP Revolver", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.Tpre();
            }, "Teleports the revolver to you");

            new QMSingleButton(Murder4, 1, 2, "TP Luger", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.Luger();
            }, "Teleports the luger to you");

            new QMSingleButton(Murder4, 2, 2, "TP Shawty xD", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.shotgun();
            }, "Teleports the shotgun to you");

            new QMSingleButton(Murder4, 3, 2, "TP Beartrap", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.beartrap();
            }, "Teleports the beartrap to you");

            new QMSingleButton(Murder4, 4, 2, "Blind niggas", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.blindall();
            }, "I CAN'T SEE AHHH");

            new QMSingleButton(Murder4, 1, 3, "Find all clues", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.findclues();
            }, "Ez win");

            new QMSingleButton(Murder4, 2, 3, "LIGHTS OUT!", delegate
            {
                Moonlight_Client.Functions.BetterMurderCheats.lightsout();
            }, "Baby lock the door and turn the lights down low");
            new QMToggleButton(Murder4, 3, 3, "RapidFireGuns", delegate
            {
                MelonCoroutines.Start(Moonlight_Client.Functions.BetterMurderCheats.RapidFire());
                
            }, delegate
            {
                MelonCoroutines.Stop(Moonlight_Client.Functions.BetterMurderCheats.RapidFire());

            }, "RATATATATATATA");
            new QMToggleButton(Murder4, 4, 3, "SelfGoldenGun", delegate
            {
                MelonCoroutines.Start(Moonlight_Client.Functions.BetterMurderCheats.SelfGoldenGun());

            }, delegate
            {
                MelonCoroutines.Stop(Moonlight_Client.Functions.BetterMurderCheats.SelfGoldenGun());

            }, "Wow a golden gun!");
            /*
            var PrisonEsc = new QMNestedButton(WorldMenu, 3, 0, "Prison Escape", null, "Prison Escape");

                new QMSingleButton(PrisonEsc, 1, 0, "Start Game", delegate
                {
                    
                }, "Start the game");

                new QMSingleButton(PrisonEsc, 2, 0, "End Game", delegate
                {

                }, "End the game");

                new QMSingleButton(PrisonEsc, 3, 0, "Inf Money", delegate
                {

                }, "Put the money in the bag!");
            */
            #endregion

            #region Instance Menu
            var InstanceMenu = new QMNestedButton(MainMenu, 2, 0, "Instance", "Opens the menu for current Instance", "Instance");


            new QMSingleButton(InstanceMenu, 2, 0, "Copy World ID", delegate
            {
                Moonlight_Client.Functions.WorldOpt.WorldID();
            }, "Gets the current instance ID");

            new QMSingleButton(InstanceMenu, 3, 0, "Join World ID", delegate
            {
                Moonlight_Client.Functions.WorldOpt.JoinWorldID();
            }, "Joins any world via ID on your clipboard");

            new QMSingleButton(InstanceMenu, 4, 0, "Kill Portals", delegate
            {
                Moonlight_Client.Functions.WorldOpt.DestroyPortals();
            }, "Should be obvious what this does");

            new QMToggleButton(InstanceMenu, 1, 0, "Player ESP", delegate
            {
                Moonlight_Client.Functions.WorldOpt.ESPAAA();
            }, delegate
            {
                Moonlight_Client.Functions.WorldOpt.NoEspNigga();
            }, "OMG ESP IN A SOCIAL GAME AAAAAAAHHH");

            new QMSingleButton(InstanceMenu, 2, 1, "Inf Portals", delegate
            {
                Moonlight_Client.Functions.WorldOpt.InfPortals();
            }, "Makes all portals the max timer limit");

            new QMSingleButton(InstanceMenu, 3, 1, "Rejoin World", delegate
            {
                Moonlight_Client.Functions.WorldOpt.RejoinWorld();
            }, "Rejoins");

            new QMSingleButton(InstanceMenu, 4, 1, "Download WRLD", delegate
            {
                Moonlight_Client.Functions.WorldOpt.DownloadVRCW();
            }, "Rejoins");
            #endregion

            #region Movement
            var MoveMenu = new QMNestedButton(MainMenu, 3, 0, "Movement", "Opens the Movement menu", "Movement");

            //Sliders don't work anymore
            /*
            new QMSlider(MoveMenu, -510, -740, "Walk Speed Amount", 0.1f, 55, 25, delegate (float NewSpeedValue)
            {
                Moonlight_Client.Functions.Movements.NewSpeedValue = NewSpeedValue;
            });

            new QMSlider(MoveMenu, -510, -865, "Fly Speed Amount", 0.1f, 55, 25, delegate (float FlyingSpeedValue)
            {
                Moonlight_Client.Functions.Movements.FlySpeedValue = FlyingSpeedValue;
            });
            */

            new QMToggleButton(MoveMenu, 1, 0, "Walk Speed", delegate
            {
                Moonlight_Client.Functions.Movements.FastWalk();
            }, delegate
            {
                Moonlight_Client.Functions.Movements.NormalWalk();
            }, "If you want to change speed via slider you must turn this off and then on!");

            new QMToggleButton(MoveMenu, 2, 0, "Flight", delegate
            {
                Moonlight_Client.Functions.Movements.flynigga();
                Moonlight_Client.Functions.Movements.NoClipperOn();
            }, delegate
            {
                Moonlight_Client.Functions.Movements.Dontflynigga();
                Moonlight_Client.Functions.Movements.NoClipperOff();
            }, "If you want to change speed via slider you must turn this off and then on!");


            new QMToggleButton(MoveMenu, 3, 0, "Slow motion", delegate
            {
                Moonlight_Client.Functions.GameControls.SlowMo();
            }, delegate
            {
                Moonlight_Client.Functions.GameControls.NormalTime();
            }, "I'm moving so slooowwwwwww");

            #endregion

            #region Safety Menu
            var SafetyMenu = new QMNestedButton(MainMenu, 4, 0, "Safety", "Opens the Protection menu <color=#f00000>[W.I.P]</color>", "Safety");

            new QMToggleButton(SafetyMenu, 1, 0, "RPC Filtering", delegate
            {

            }, delegate
            {

            }, "Anti-RPC");

            new QMToggleButton(SafetyMenu, 2, 0, "Photon Filtering", delegate
            {

            }, delegate
            {

            }, "Anti-Photon");

            new QMToggleButton(SafetyMenu, 3, 0, "Avatar Filtering", delegate
            {

            }, delegate
            {

            }, "Anti-Avatar");
            #endregion

            #region Exploits Menu
            var ExploitMenu = new QMNestedButton(MainMenu, 1, 1, "Exploits", "Mess with VRChat", "Exploits");

            ;

            new QMToggleButton(ExploitMenu, 1, 0, "E1", delegate
            {
                Moonlight_Client.Functions.ExploitsManager.Event1start();
            }, delegate
            {
                Moonlight_Client.Functions.ExploitsManager.Even1NoStart();
            }, "Funny ear killer");

            new QMToggleButton(ExploitMenu, 2, 0, "Loud Mic", delegate
            {
                Moonlight_Client.Functions.ExploitsManager.LoudAssMic();
            }, delegate
            {
                Moonlight_Client.Functions.ExploitsManager.NormalMic();
            }, "AAAAAAAAAAAAAHHHHHHHHH");

            new QMSingleButton(ExploitMenu, 3, 0, "Respawn Pickups", delegate
            {
                Moonlight_Client.Functions.items.respawnpickups();
            }, "Respawns all pickups");

            new QMSingleButton(ExploitMenu, 4, 0, "Force Item Ownership", delegate
            {
                Moonlight_Client.Functions.items.objectowner();
            }, "Haha my items now");

            new QMSingleButton(ExploitMenu, 1, 1, "Fuck Udon", delegate
            {
                Moonlight_Client.Functions.ExploitsManager.UdonAssOn();
            }, "Nukes udon beyond repair");
            #endregion

            #region Self Menu
            var SelfMenu = new QMNestedButton(MainMenu, 2, 1, "Self", "Do shit to yourself", "Self");

            new QMToggleButton(SelfMenu, 2, 0, "Hide Self", delegate
            {
                Moonlight_Client.Functions.SelfShit.HideSelfOn();
            }, delegate
            {
                Moonlight_Client.Functions.SelfShit.HideSelfOff();
            }, "Hide yourself locally");

            new QMSingleButton(SelfMenu, 3, 0, "Avatar by ID", delegate
            {
                Moonlight_Client.Functions.SelfShit.AVIID();
            }, "Change Avatar By ID via your Clipboard");

            new QMToggleButton(SelfMenu, 4, 0, "PC Crash", delegate
            {
                Moonlight_Client.Functions.SelfShit.AssetKill();
            }, delegate
            {
                Moonlight_Client.Functions.SelfShit.AssetKillOff();
            }, "Kills lobby with a PC Avatar");

            new QMToggleButton(SelfMenu, 1, 1, "T-Pose", delegate
            {
                Moonlight_Client.Functions.SelfShit.TPOSE();
            }, delegate
            {
                Moonlight_Client.Functions.SelfShit.TPOSE();
            }, "You already know lol");

            new QMSingleButton(SelfMenu, 2, 1, "Default Avatar", delegate
            {
                Moonlight_Client.Functions.SelfShit.DefaultAVI();
            }, "Change Avatar By ID via your Clipboard");

            new QMSingleButton(SelfMenu, 3, 1, "Download VRCA", delegate
            {
                Moonlight_Client.Functions.SelfShit.DwnVRCA();
            }, "Download your current Avatar");

            new QMToggleButton(SelfMenu, 4, 1, "Quest Crash", delegate
            {
                Moonlight_Client.Functions.SelfShit.StartQuestAssetKill();
            }, delegate
            {
                Moonlight_Client.Functions.SelfShit.StopQuestAssetKill();
            }, "Kills lobby with a Quest Avatar (Thank you Silent for the Avatar)");
            #endregion

            #region Settings
            var SetsMenu = new QMNestedButton(MainMenu, 4, 3, "<color=#ffd000>Settings</color>", "Opens the Settings menu", "Settings");

            new QMSingleButton(MainMenu, 3, 3, $"<color=#bf42f5>Discord Checker:</color> {Moonlight_Client.Discord.ServerLink.DiscordStatusActive}", delegate
            {
                //This is the discord server status thingy lol
            }, null);

            new QMSingleButton(MainMenu, 2, 3, $"<color=#bf42f5>Discord</color>", delegate
            {
                Moonlight_Client.Discord.ServerLink.DiscordJoin();
            }, "Join Moonlight's Discord");


            new QMSingleButton(SetsMenu, 1, 0, "Quit Game", delegate
            {
                Moonlight_Client.Functions.GameControls.KillGame();
            }, "Fastest way to exit VRChat");

            new QMSingleButton(SetsMenu, 2, 0, "Restart Game", delegate
            {
                Moonlight_Client.Functions.GameControls.RestartGame();
            }, "Fastest way to restart VRChat");

            new QMSingleButton(SetsMenu, 3, 0, "Cap FPS", delegate
            {
                Moonlight_Client.Functions.GameControls.CapGame();
            }, "Sets FPS to Monitor limit");

            new QMSingleButton(SetsMenu, 4, 0, "Uncap FPS", delegate
            {
                Moonlight_Client.Functions.GameControls.UnCapGame();
            }, "Sets FPS to inf");


            new QMSingleButton(SetsMenu, 2, 1, "Clear Console", delegate
            {
                Moonlight_Client.Functions.GameControls.ClearConsole();
            }, "Clears your console");

            new QMSingleButton(SetsMenu, 3, 1, "<color=#ff0000>Logout</color>", delegate
            {
                Moonlight_Client.Functions.GameControls.LOGOUT();
            }, "Sends you to the login page");

            new QMSingleButton(SetsMenu, 4, 1, "Fullscreen", delegate
            {
                Moonlight_Client.Functions.GameControls.Fullscreen();
            }, "");

            new QMSingleButton(SetsMenu, 1, 1, "Windowed", delegate
            {
                Moonlight_Client.Functions.GameControls.Windowed();
            }, "");


            new QMSingleButton(SetsMenu, 2, 2, "Friend Salute", delegate
            {
                Moonlight_Client.Functions.AutoFR.FriendSalute();
            }, "Send a friend request to the owner");

            new QMSingleButton(SetsMenu, 1, 2, "Friend Zilla to erp", delegate
            {
                Moonlight_Client.Functions.AutoFR.FriendZilla();
            }, "Send a friend request to the owner");

            /*
            new QMToggleButton(SetsMenu, 4, 2, "CS:GO Mode", delegate
            {
                //Moonlight_Client.Functions.GameControls.WideScreenON();
            }, delegate
            {
                //Moonlight_Client.Functions.GameControls.WideScreenOFF();
            }, "Makes your screen wide as fuck");
            */
            #endregion
        }
    }
}
