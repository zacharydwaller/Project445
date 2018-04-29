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
        LogMessages = new List<string>();
        logText = GameObject.Find("LogText").GetComponent<Text>();
        logText.text = "";
    }
	
	// Update is called once per frame
	void Update ()
	{
		// Local change
	}

    public void LogPacket(int packetId, int healthBefore, int healthAfter)
    {
        string logStr =
            string.Format(
            "{0} [**] Incoming Packet Detected [PacketId: {1}] [HealthBefore: {2}] [HealthAfter : {3}]",
            GetTimestamp(), packetId, healthBefore, healthAfter);

        LogMessages.Add(logStr);

        if(LogMessages.Count > maxMessages)
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
