﻿namespace LIN.Access.Developer;


public class Build
{


    public static void Init(string? url = null)
    {
        Service._Service = new();
        Service._Service.SetDefault(url ?? "http://api.cloud.services.linapps.co/");
        //Service._Service.SetDefault("http://localhost:5089/");
    }


}