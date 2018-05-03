using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public ScoreHolder ScoreHolder;

    public const int MaxHealth = 100;
    public int Health = MaxHealth;
    Text logText;

    public const float GoalTime = 60f;
    private float StartTime;

    List<string> LogMessages;
    int maxMessages = 9;

    // Use this for initialization
    void Start ()
	{
		//var Box1 = GameObject.Find("Box1").GetComponent<portBlock>();
        LogMessages = new List<string>();
        logText = GameObject.Find("LogText").GetComponent<Text>();

        logText.text = "";

        StartTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
	{
        if(Time.time >= StartTime + GoalTime)
        {
            ScoreHolder.Score = Health * 100;
            SceneManager.LoadScene("winScene");
        }
	}

	public void LogPacket(int packetId, int healthBefore, int healthAfter, float packetDelay)
    {
        int boxNumber = (packetId % 10) + 1;
        string boxID = "Box" + boxNumber.ToString();

        var Box = GameObject.Find(boxID).GetComponent<PortBlock>();

        string logStr = string.Format(
                "{0} [**] Incoming Packet Detected [PacketId: {1}]\n[HealthBefore: {2}] [ HealthAfter : {3}] [Packet Rate : {4}]",
                GetTimestamp(), packetId, healthBefore, healthAfter, packetDelay);

        if (Box.Blocked == true)
        {
            Debug.Log(boxID);
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
            logText.text += message + "\n\n";
        }
    }

    string GetTimestamp()
    {
        return Time.time.ToString("0.000");
    }
}
