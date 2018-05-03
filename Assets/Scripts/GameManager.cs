using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public const int MaxHealth = 100;
    public int Health = MaxHealth;
    Text logText;

    List<string> LogMessages;
    int maxMessages = 10;

    // Use this for initialization
    void Start ()
	{
		//var Box1 = GameObject.Find("Box1").GetComponent<portBlock>();
        LogMessages = new List<string>();
        logText = GameObject.Find("LogText").GetComponent<Text>();

        logText.text = "";
    }
	
	// Update is called once per frame
	void Update ()
	{
			//var Box1 = GameObject.Find("Box1").GetComponent<portBlock>();
        LogMessages = new List<string>();
		 //Debug.Log( Box1.blocked );
	}

	public void LogPacket(int packetId, int healthBefore, int healthAfter, float packetDelay)
    {
        string boxID = "1";
        string portScriptNumber = "1";
        if (packetId % 10 == 1)
        {
            boxID = "Box1";
        }
        else  if (packetId % 10 == 2)
        {
            boxID = "Box2";
        }
        else if (packetId % 10 == 3)
        { boxID = "Box3"; }
        else if (packetId % 10 == 4)
        { boxID = "Box4"; }
        else if (packetId % 10 == 5)
        { boxID = "Box5"; }
        else if (packetId % 10 == 6)
        { boxID = "Box6"; }
        else if (packetId % 10 == 7)
        { boxID = "Box7"; }
        else if (packetId % 10 == 8)
        { boxID = "Box8"; }
        else if (packetId % 10 == 9)
        { boxID = "Box9";}
        else if (packetId % 10 == 0)
        { boxID = "Box10"; }
        var Box1 = GameObject.Find(boxID).GetComponent<portBlock>();
        //if( packetId % 10 == 2)     
        //var Box = GameObject.Find("Box2").GetComponent<portBlock>();
        //if (packetId % 10 == 1 && Box1.blocked == 1)
        //logText.color = Color.black;
        //else
        //logText.color = Color.white;
        if (Box1.blocked == 0)
        {
            string logStr =
                string.Format(
                    "{0} [**] Incoming Packet Detected [PacketId: {1}]           [HealthBefore: {2}] [ HealthAfter : {3}] [Packet Rate : {4}]",
                    GetTimestamp(), packetId, healthBefore, healthAfter, packetDelay);
            LogMessages.Add(logStr);
        }
        if (Box1.blocked == 1)
        {
            string logStr =
                string.Format(
                    "{0} [**] Incoming Packet Detected [PacketId: {1}]           [HealthBefore: {2}] [ HealthAfter : {3}] [Packet Rate : {4}] BLOCKED",
                    GetTimestamp(), packetId, healthBefore, healthAfter, packetDelay);
            LogMessages.Add(logStr);
        }

        if (LogMessages.Count > maxMessages)
        {
            LogMessages.RemoveAt(0);
        }

        logText.text = "";
        foreach(var message in LogMessages)
        {
           logText.text += message + "\n";
        }
     }

    string GetTimestamp()
    {
        return Time.time.ToString("0.000");
    }
}
