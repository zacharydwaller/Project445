﻿using UnityEngine;

public class Packets : MonoBehaviour {

    int badID;
    int[] packetID = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 700 };

    float packetDelay = 1;
    float packetDelayVariance = 0.5f;
    float nextPacket;

    GameManager gameManager;

    // Use this for initialization
    void Start() {
        PacketIDMaker();
        badID = (Random.Range(0, 10));

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        

        nextPacket = packetDelay;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time >= nextPacket)
        {
            nextPacket = Time.time + GetRandomDelay();

            int healthBefore = gameManager.Health;
            int packet = Mathf.RoundToInt(Random.Range(0, 10));

            if (packet == badID)
            {
                gameManager.Health -= 4;
            }

            int healthAfter = gameManager.Health;

            gameManager.LogPacket(packetID[packet], healthBefore, healthAfter);
        }
    }

    void PacketIDMaker()
    {
        int x;
        for (int i = 1; i < 10; i++)
        {
            x = Mathf.RoundToInt(Random.Range(1, 1000));
            if (x % 10 != i)
                while (x % 10 != i)
                    x = Mathf.RoundToInt(Random.Range(1, 1000));

            packetID[i - 1] = x;
            //Debug.Log( packetID[i]);
        }

        packetID[9] = 700;

        var Text1 = GameObject.Find("1Text").GetComponent<TextMesh>();
        Text1.text = packetID[0].ToString();
        var Text2 = GameObject.Find("2Text").GetComponent<TextMesh>();
        Text2.text = packetID[1].ToString();
        var Text3 = GameObject.Find("3Text").GetComponent<TextMesh>();
        Text3.text = packetID[2].ToString();
        var Text4 = GameObject.Find("4Text").GetComponent<TextMesh>();
        Text4.text = packetID[3].ToString();
        var Text5 = GameObject.Find("5Text").GetComponent<TextMesh>();
        Text5.text = packetID[4].ToString();
        var Text6 = GameObject.Find("6Text").GetComponent<TextMesh>();
        Text6.text = packetID[5].ToString();
        var Text7 = GameObject.Find("7Text").GetComponent<TextMesh>();
        Text7.text = packetID[6].ToString();
        var Text8 = GameObject.Find("8Text").GetComponent<TextMesh>();
        Text8.text = packetID[7].ToString();
        var Text9 = GameObject.Find("9Text").GetComponent<TextMesh>();
        Text9.text = packetID[8].ToString();
        var Text10 = GameObject.Find("10Text").GetComponent<TextMesh>();
        Text10.text = packetID[9].ToString();
    }

    float GetRandomDelay()
    {
        return Random.Range(packetDelay - packetDelayVariance, packetDelay + packetDelayVariance);
    }
}