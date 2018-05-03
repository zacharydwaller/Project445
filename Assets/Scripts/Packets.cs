using UnityEngine;
using UnityEngine.SceneManagement;

public class Packets : MonoBehaviour {

    int badIndex;
    int goodIndex;
    int speedUpIndex;
    int speedDownIndex;

    int[] packetIds = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    public float packetDelay = 1f;
    float packetDelayVariance = 0.25f;
    float nextPacketTime;

    GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        PacketIDMaker();

        badIndex = Random.Range(0, 10);
        goodIndex = Random.Range(0, 10);
        speedUpIndex = Random.Range(0, 10);
        speedDownIndex = Random.Range(0, 10);

        while (goodIndex == badIndex)
        {
            goodIndex = (Random.Range(0, 10));
        }

        while (speedUpIndex == goodIndex || speedUpIndex == badIndex)
        {
            speedUpIndex = (Random.Range(0, 10));
        }

        while (speedDownIndex == goodIndex || speedDownIndex == badIndex || speedDownIndex == speedUpIndex)
        {
            speedDownIndex = (Random.Range(0, 10));
        }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        nextPacketTime = packetDelay;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.Health <= 0)
        {
            SceneManager.LoadScene("gameOver");
        }

        if (Time.time >= nextPacketTime)
        {
            nextPacketTime = Time.time + GetRandomDelay();

            int healthBefore = gameManager.Health;

            int packetIndex = Random.Range(0, 10);
            int boxNumber = packetIndex + 1;
            string boxID = "Box" + boxNumber.ToString();

            var Box = GameObject.Find(boxID).GetComponent<PortBlock>();

            if (packetIndex == badIndex && Box.Blocked == false)
            {
                gameManager.Health -= 25;
            }
            if (packetIndex == goodIndex && Box.Blocked == false)
            {
                gameManager.Health += 5;
            }
            if (packetIndex == speedUpIndex && Box.Blocked == false && packetDelay >= .5)
            {
                packetDelay -= .1f;
            }
            if (packetIndex == speedDownIndex && Box.Blocked == false)
            {
                packetDelay += .1f;
            }

            int healthAfter = gameManager.Health;
			gameManager.LogPacket(packetIds[packetIndex], healthBefore, healthAfter, packetDelay );
        }
    }

    void PacketIDMaker()
    {
        int x;
        for (int i = 1; i <= 10; i++)
        {
            x = Mathf.RoundToInt(Random.Range(100, 1000));

            // Make last number match box number
            int indexDiff = (x % 10) - (i % 10);
            x -= indexDiff;

            packetIds[i - 1] = x;
            //Debug.Log( packetID[i]);
        }

        var Text1 = GameObject.Find("1Text").GetComponent<TextMesh>();
        Text1.text = packetIds[0].ToString();
        var Text2 = GameObject.Find("2Text").GetComponent<TextMesh>();
        Text2.text = packetIds[1].ToString();
        var Text3 = GameObject.Find("3Text").GetComponent<TextMesh>();
        Text3.text = packetIds[2].ToString();
        var Text4 = GameObject.Find("4Text").GetComponent<TextMesh>();
        Text4.text = packetIds[3].ToString();
        var Text5 = GameObject.Find("5Text").GetComponent<TextMesh>();
        Text5.text = packetIds[4].ToString();
        var Text6 = GameObject.Find("6Text").GetComponent<TextMesh>();
        Text6.text = packetIds[5].ToString();
        var Text7 = GameObject.Find("7Text").GetComponent<TextMesh>();
        Text7.text = packetIds[6].ToString();
        var Text8 = GameObject.Find("8Text").GetComponent<TextMesh>();
        Text8.text = packetIds[7].ToString();
        var Text9 = GameObject.Find("9Text").GetComponent<TextMesh>();
        Text9.text = packetIds[8].ToString();
        var Text10 = GameObject.Find("10Text").GetComponent<TextMesh>();
        Text10.text = packetIds[9].ToString();
    }

    float GetRandomDelay()
    {
        return Random.Range(packetDelay - packetDelayVariance, packetDelay + packetDelayVariance);
    }
}
