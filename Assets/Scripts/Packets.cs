using UnityEngine;

public class Packets : MonoBehaviour {

    int badID;
    int goodID;
    int speedUpID;
    int speedDownID;
    int[] packetID = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 700 };

    public float packetDelay = 1f;
    float packetDelayVariance = 0.5f;
    float nextPacket;

    GameManager gameManager;

    // Use this for initialization
    void Start() {
        PacketIDMaker();
        badID = (Random.Range(0, 10));
        goodID = (Random.Range(0, 10));
        speedUpID = (Random.Range(0, 10));
        speedDownID = (Random.Range(0, 10));
        while ( goodID == badID)
            goodID = (Random.Range(0, 10));
        while (speedUpID == goodID || speedUpID == badID)
            speedUpID = (Random.Range(0, 10));
        while (speedDownID == goodID || speedDownID == badID || speedDownID == speedUpID)
            speedDownID = (Random.Range(0, 10));


        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		//Box1 = GameObject.Find("Box1").GetComponent<COlor>();

        

        nextPacket = packetDelay;
    }

    // Update is called once per frame
    void Update() {

        if (Time.time >= nextPacket)
        {
            string boxID = "1";
            nextPacket = Time.time + GetRandomDelay();

            int healthBefore = gameManager.Health;
            int packet = Mathf.RoundToInt(Random.Range(0, 10));
            if (gameManager.Health <= 0)
                Application.LoadLevel("gameOver");
            if (packet == 0)
            { boxID = "Box1";  }
            else if (packet == 1)
            { boxID = "Box2"; }
            else if (packet == 2)
            { boxID = "Box3"; }
            else if (packet == 3)
            { boxID = "Box4"; }
            else if (packet == 4)
            { boxID = "Box5"; }
            else if (packet == 5)
            { boxID = "Box6"; }
            else if (packet == 6)
            { boxID = "Box7"; }
            else if (packet == 7)
            { boxID = "Box8"; }
            else if (packet == 8)
            { boxID = "Box9"; }
            else if (packet == 9)
            { boxID = "Box10"; }
            var Box = GameObject.Find(boxID).GetComponent<portBlock>();

            if (packet == badID && Box.blocked != 1)
            {
                gameManager.Health -= 4;
            }
            if (packet == goodID && Box.blocked != 1)
            {
                gameManager.Health += 4;
            }
            if (packet == speedUpID && Box.blocked != 1 && packetDelay >= .5)
            {
                packetDelay -= .1f;
            }
            if (packet == speedDownID && Box.blocked != 1)
            {
                packetDelay += .1f;
            }

            int healthAfter = gameManager.Health;
			gameManager.LogPacket(packetID[packet], healthBefore, healthAfter, packetDelay );
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
