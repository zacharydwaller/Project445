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

	}

	public void LogPacket(int packetId, int healthBefore, int healthAfter, float packetDelay)
    {
        string portScriptNumber = "1";
        int boxNumber = packetId % 10;
        string boxID = "Box" + boxNumber.ToString();

        var Box1 = GameObject.Find(boxID).GetComponent<portBlock>();

        string logStr = string.Format(
                "{0} [**] Incoming Packet Detected [PacketId: {1}]\n[HealthBefore: {2}] [ HealthAfter : {3}] [Packet Rate : {4}]",
                GetTimestamp(), packetId, healthBefore, healthAfter, packetDelay);


        if (Box1.blocked == 1)
        {
            logStr += " BLOCKED";
        }

        LogMessages.Add(logStr);

        PrintLog();
     }

    private void PrintLog()
    {
        if (LogMessages.Count > maxMessages)
        {
            LogMessages.RemoveAt(0);
        }

        logText.text = "";
        foreach (var message in LogMessages)
        {
            logText.text += message + "\n";
        }
    }

    string GetTimestamp()
    {
        return Time.time.ToString("0.000");
    }
}
