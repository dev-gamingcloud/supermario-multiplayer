using System.Collections;
using System.Collections.Generic;
using gamingCloud;
using gamingCloud.Network;
using gamingCloud.templates;
using UnityEngine;

public class ServerManager : GCMultiPlayer
{
    // Start is called before the first frame update
    class MyPlayer
    {
        public string username;
        public string password;
        public int? score;

        public MyPlayer(string _username, string _password, string _email, string _phone, int? _score)
        {
            this.username = _username;
            this.password = _password;
            this.score = _score;
        }

    }

    async void Start()
    {
        MyPlayer my = new MyPlayer("mahdi", "12345", "aaasssss@rashidi.ir", "0915659852", 50000);
        ApiResponse res = await Players.CreatePlayer<MyPlayer>(my);
        Debug.Log(res.status);
        ConnectToMultiPlayerServer();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("send");
            SendEvent("GetEventTurn", "false", SendPacketMode.BroadCast);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SendEvent("GetEventTurn", "true", SendPacketMode.BroadCast);

        }
    }

    public void SendJump()
    {
        SendEvent("GetEventSpace", SendPacketMode.BroadCast);
        Debug.Log("send jump");
    }
    public void SendDead()
    {
        SendEvent("Dead", SendPacketMode.BroadCast);
        Debug.Log("send dead");
    }
    public void SendGround()
    {
        SendEvent("GetEventGround", SendPacketMode.BroadCast);
        Debug.Log("send Ground");
    }
    private void OnDestroy()
    {
        disconnect();
    }
    void Dead(PlayerModel model)
    {

        getClients(model)[0].gameObject.SetActive(false);
    }
    void GetEventTurn(PlayerModel model, string content)
    {

        getClients(model)[0].GetComponent<SpriteRenderer>().flipX = bool.Parse(content);
    }
    void GetEventSpace(PlayerModel model)
    {
        getClients(model)[0].GetComponent<clientMovement>().changeSpcae(true);
        // GameObject.Find("MarioClient").GetComponent<clientMovement>().changeSpcae();
    }
    void GetEventGround(PlayerModel model)
    {
        getClients(model)[0].GetComponent<clientMovement>().changeSpcae(false);
        // GameObject.Find("MarioClient").GetComponent<clientMovement>().changeSpcae();
    }

    public override void ConnectedToServer()
    {
        Debug.Log("connect");
        JoinToServer(new RoomSetting());
    }
    public override void OnJoined()
    {
        Debug.Log("joined");
    }
}
