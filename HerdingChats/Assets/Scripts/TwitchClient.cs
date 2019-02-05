﻿using System.Collections;
using System.Collections.Generic;
using TwitchLib.Unity;
using TwitchLib.Client.Models;
using UnityEngine;

public class TwitchClient : MonoBehaviour
{

    public Client client;
    public string channelName = "sulu244";
    public GameObject CatControllerObject;
    private float helpTimer;
    private bool helpFlag;

    private CatController catController;
    // Start is called before the first frame update
    void Start()
    {
        Application.runInBackground = true;

        ConnectionCredentials credentials = new ConnectionCredentials("mrtwitchboto", Secrets.Instance.accessToken);
        client = new Client();
        client.Initialize(credentials, channelName);

        client.OnMessageReceived += ChatListen;
        client.OnChatCommandReceived += CommandListen;

        client.Connect();
        client.SendMessage(client.JoinedChannels[0], "MrTwitchBoto has joined chat");

        catController = CatControllerObject.GetComponent<CatController>();
        helpTimer = 40.0f;
    }

    private void CommandListen(object sender, TwitchLib.Client.Events.OnChatCommandReceivedArgs e)
    {
        if (e.Command.CommandText == "help" && helpFlag == false)
        {
            Help();
            helpFlag = true;
        }
        else if (e.Command.CommandText == "Up" || e.Command.CommandText == "up" || e.Command.CommandText == "Down" || e.Command.CommandText == "down"
            || e.Command.CommandText == "Left" || e.Command.CommandText == "left" || e.Command.CommandText == "Right" || e.Command.CommandText == "right")
        {
            catController.ChatMoveCommand(e.Command.CommandText);
        }
        /*else
        {
            client.SendMessage(client.JoinedChannels[0],"Command not recognized, please use !Help to get the list of commands.");
        }*/

        if (helpFlag == true)
        {
            helpTimer = helpTimer - Time.deltaTime;
            if (helpTimer <= 0.0f)
            {
                helpFlag = false;
                helpTimer = 40.0f;
            }
        }
    }

    private void ChatListen(object sender, TwitchLib.Client.Events.OnMessageReceivedArgs e)
    {
        Debug.Log("Someone just sent a message in Twitch Chat");
        Debug.Log(e.ChatMessage.Username + ": " + e.ChatMessage.Message);
    }

    private void Help()
    {
        client.SendMessage(client.JoinedChannels[0], "Welcome to Herding Chats! You can use chat commands to help the cats avoid the player! The valid commands are: !Up, !Down, !Left, !Right");
    }
}
