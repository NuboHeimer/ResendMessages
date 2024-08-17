///----------------------------------------------------------------------------
///   Module:       Resend Messages
///   Author:       NuboHeimer (https://live.vkplay.ru/nuboheimer)
///   Email:        nuboheimer@yandex.ru
///----------------------------------------------------------------------------

///   Version:      0.0.2


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class CPHInline
{
	public bool Execute()
	{
        if (!args.ContainsKey("message"))
        {
            CPH.ShowToastNotification("Недостаточно аргументов", "Необходимо указать текст сообщения в аргументе 'message'");
            return false;
        };

        var ignoreNames = new List<string>
        {
        	"nuboheimer",
        	"botinokbobra",
        	"streamelements",
        	"ChatBot",
            "Тир-на-ног'т",
        };

        var services = new List<string>
        {
            "goodgame",
            "vk",
            "nuum",
            "facebook",
            "ok",
            "trovo",
            "rutube",
            "vkplay",
        };

        string userName = args["user"].ToString().ToLower();

        if(!ignoreNames.Contains(userName.ToLower()))
        {
        	if(args["eventSource"].ToString().ToLower() != "twitch")
        	{
        		CPH.SendMessage("#[" + args["eventSource"].ToString() + " | " + args["user"].ToString() + "]: " + args["message"].ToString());
        	};

        	// if(args["eventSource"].ToString().ToLower() != "youtube")
        	// {
        	// 	CPH.SendYouTubeMessage("#[" + args["eventSource"].ToString() + " | " + args["user"].ToString() + "]: " + args["message"].ToString());
        	// };

        	if(args["eventSource"].ToString().ToLower() != "vkplay")
        	{
        		CPH.SetArgument("message", "#[" + args["eventSource"].ToString() + " | " + args["user"].ToString() + "]: " + args["message"].ToString());
        		CPH.ExecuteMethod("MiniChat Method Collection", "SendMessageVkPlay");
        	};

            if(args["eventSource"].ToString().ToLower() != "vk")
        	{
        		CPH.SetArgument("message", "#[" + args["eventSource"].ToString() + " | " + args["user"].ToString() + "]: " + args["message"].ToString());
        		CPH.ExecuteMethod("MiniChat Method Collection", "SendMessageVK");
        	};
        }
		return true;
	}
}