using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    [SerializeField] private float Speed = 16.0f;

    //UI components.
    [SerializeField] Transform PowerMeter;
    [SerializeField] Text PowerText;
    private float PowerFlash = 0.0f;

    [SerializeField] private GameObject SocketTemplate;
    [SerializeField] private GameObject WireTemplate;

    [SerializeField] private RectTransform Gamefield;
    [SerializeField] private GameObject Win;
    [SerializeField] private GameObject Gameover;
    [SerializeField] private Transform SocketParent;
    [SerializeField] private int totalSockets = 8; //How many sockets are there on the game board?

    //Wire Gun related variables.
    private float WireGunRailWidth;
    [SerializeField] private Transform WireGun;
    [SerializeField] private GameObject LaserTemplate;

    //Game related variables.
    private float railDirection = 0.0f;

    private float Power = 100.0f; //How much power is there left?
    [SerializeField] private float PowerDrain = 2.5f; //At what rate should the power drain at?
    [SerializeField] private float RoundTime = 60.0f; //How long do you need to last in order to complete the minigame?
    private float TimeLeft = 99999999.0f; //How much time there is left within the game.



    //Going to need two class objects, one to represent wires and the other to represent sockets.
    private class WireObj
    {

        private float lifeTime = 0.0f;
        private SocketObj[] sockets = new SocketObj[2];

        public GameObject Wire; //The Wire in the actual game.

        //Constructor
        public WireObj(GameObject WireGraphic, SocketObj socketA, SocketObj socketB)
        {

            Wire = WireGraphic; //Store this for when we need to remove it once lifetime is up.

            //Store the sockets and tell those sockets that they are in fact powered.
            sockets[0] = socketA;
            sockets[1] = socketB;

            for (int i = 0; i < 2; i++)
                sockets[i].isPowered = true;

            //Using the wire graphic given, scale and rotate it so it fits between the two sockets.
            RectTransform rect = WireGraphic.GetComponent<RectTransform>();

            Vector3 socketVector = (socketA.socket.transform.localPosition - socketB.socket.transform.localPosition);
            rect.sizeDelta = new Vector2(24.0f, socketVector.magnitude);
            rect.localPosition = (socketA.socket.transform.localPosition + socketB.socket.transform.localPosition) * 0.5f;
            rect.localRotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(socketVector.y, socketVector.x) * Mathf.Rad2Deg - 90.0f);

            //And also give it a random colour to make it prettier :3
            WireGraphic.GetComponent<Image>().color = new Color(Random.Range(0.25f, 1.0f), Random.Range(0.25f, 1.0f), Random.Range(0.25f, 1.0f));

            //Just to make it visible.
            WireGraphic.SetActive(true);

            //Give this wire a random amount of lifetime.
            lifeTime = Random.Range(5.0f, 30.0f);

        }

        public bool Tick(float delta)
        {

            lifeTime -= delta;
            if(lifeTime <= 0.0f)
            {
                //Destroy the wire, and tell the two sockets that we have infact died...
                for (int i = 0; i < 2; i++)
                    sockets[i].isPowered = false;

                //Destroy the wire
                Destroy(Wire);

                //Return true to let the game know that yes it need to remove this wire from its list.
                return true;
            }

            return false; //The wire is all good for now :3

        }

    }

    private class SocketObj
    {

        public bool isPowered = false;
        public GameObject socket;

    }

    //Create two lists to hold our sockets and wires.
    List<WireObj> Wires = new List<WireObj>();
    List<SocketObj> Sockets = new List<SocketObj>();



    void InitializeGame()
    {

        //Hide both the win and gameover screens.
        Win.SetActive(false);
        Gameover.SetActive(false);


        //Get the width of the rail, that way the clamp is automatic whenever the rail is changed...
        WireGunRailWidth = WireGun.parent.GetComponent<RectTransform>().rect.width * 0.5f - 32.0f;

        if (WireGunRailWidth < 0.0f)
            WireGunRailWidth = 0.0f;

        //Reset the wiregun position and movement.
        WireGun.transform.localPosition = new Vector3(0.0f, WireGun.transform.localPosition.y, 0.0f);
        railDirection = 0.0f;

        //Reset the timer.
        TimeLeft = RoundTime;

        //Reset the power.
        Power = 100.0f;

        //Clear the sockets and wires.
        while (Sockets.Count > 0)
        {

            SocketObj socket = Sockets[0];
            Destroy(socket.socket);
            Sockets.Remove(socket);

        }

        while(Wires.Count > 0)
        {

            WireObj wire = Wires[0];
            Destroy(wire.Wire);
            Wires.Remove(wire);

        }

        //Spawn in a bunch of random sockets, but first only allow divisible of 2, so there is always a pair of socket on the field regardless of config...
        int socketPairs = (totalSockets / 2) * 2;

        float halfWIDTH = (Gamefield.rect.width - 128.0f) * 0.5f;
        float halfHEIGHT = (Gamefield.rect.height - 224.0f) * 0.5f;

        List<SocketObj> Remaining = new List<SocketObj>();

        for (int x = 0; x < socketPairs; x++)
        {

            SocketObj newSocket = new SocketObj();

            newSocket.socket = Instantiate(SocketTemplate, SocketParent);

            newSocket.socket.transform.localPosition = new Vector3(Mathf.Lerp(-halfWIDTH, halfWIDTH, (float)x / (float)(socketPairs - 1)), Random.Range(-halfHEIGHT, halfHEIGHT), 0.0f);

            newSocket.socket.SetActive(true);

            Sockets.Add(newSocket);

            //Also add them to a list of remaining, so we can initialize them with wires randomly.
            Remaining.Add(newSocket);

        }

        //Randomly pair all the wires up, so the player have a fair start.
        while (Remaining.Count > 0)
        {

            SocketObj socketA = Remaining[Random.Range(0, Remaining.Count - 1)];

            //Immediately remove socketA from the list, cuz we dont want B to pick it too.
            Remaining.Remove(socketA);

            SocketObj socketB = Remaining[Random.Range(0, Remaining.Count - 1)];

            //Same for socket B cuz now it will be used to make a wire.
            Remaining.Remove(socketB);

            //Create our wire.
            Wires.Add(new WireObj(Instantiate(WireTemplate, SocketParent), socketA, socketB));

        }

    }

    // Start is called before the first frame update
    void Start()
    {

        InitializeGame();

    }

    private void OnEnable()
    {
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {

        if (TimeLeft > 0.0f && Power > 0.0f)
        {

            if (railDirection != 0.0f)
                WireGun.localPosition = new Vector2(Mathf.Clamp(WireGun.localPosition.x + (railDirection * Speed * Time.deltaTime), -WireGunRailWidth, WireGunRailWidth), WireGun.localPosition.y);

            //See if there is any wires present, and if so drain them or melt them if they have been drained.
           for(int i = Wires.Count - 1; i > -1; i--)
                if (Wires[i].Tick(Time.deltaTime))
                    Wires.Remove(Wires[i]);

            //Check if there is any sockets left, and drain at the rate per socket unplugged.
            int disconnectCount = 0;
            foreach (SocketObj socket in Sockets)
                if (!socket.isPowered)
                    disconnectCount++;

            //Add or take power away based on disconnectCount.
            Power -= (disconnectCount > 0 ? PowerDrain * Time.deltaTime : PowerDrain * -0.5f * Time.deltaTime);
            Power = Mathf.Clamp(Power, 0.0f, 100.0f); //Clamp the power.

            //Resize the power meter!
            PowerMeter.transform.localScale = new Vector3(Power / 100.0f, 1.0f, 1.0f);

            //Enable power warning text and make it flash.
            if ((disconnectCount > 0))
            {

                float alpha = (Mathf.Sin(PowerFlash * 6.283184f) * 0.5f) + 0.5f;

                PowerText.text = "WARNING! WARNING! WARNING!";
                PowerText.color = new Color(1.0f, 0.0f, 0.0f, alpha);

                PowerFlash += Time.deltaTime;
                if (PowerFlash > 1.0f)
                    PowerFlash -= 1.0f;
            }
            else
            {
                PowerText.text = "CHARGING...";
                PowerText.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            }

            //Decrease the timer left.
            TimeLeft -= Time.deltaTime;

        }
        else if(!Win.activeSelf && !Gameover.activeSelf)
        {

            //Time's up or power is out, if there is still power then it means they reached here through time out.
            if(Power > 0.0f)
            {
                //They won.
                Win.SetActive(true);
            }
            else
            {
                //They lost...
                Gameover.SetActive(true);
            }

        }

    }

    //This is like some really really crude raycasting for sockets...
    private SocketObj FireWire()
    {

        float minDist = Gamefield.rect.height - 224.0f;
        SocketObj victim = null;

        foreach(SocketObj socket in Sockets)
        {

            if (socket.isPowered)
                continue; //We are not testing sockets that already got wired plugged in them.

            float socketWidth = socket.socket.GetComponent<RectTransform>().rect.width;
            float minX = socket.socket.transform.localPosition.x - socketWidth * 0.5f;

            if(WireGun.localPosition.x >= minX && WireGun.localPosition.x <= minX + socketWidth)
            {
                float dist = socket.socket.transform.localPosition.y - WireGun.localPosition.y;
                if(dist < minDist)
                {
                    minDist = dist;
                    victim = socket;
                }
            }

        }

        //If we reached here, we might of well at least instantiate a laser!
        GameObject newLaser = Instantiate(LaserTemplate, SocketParent);

        newLaser.transform.localPosition = new Vector3(WireGun.localPosition.x, WireGun.localPosition.y + (minDist * 0.5f), 0.0f);
        newLaser.GetComponent<RectTransform>().sizeDelta = new Vector2(32.0f, minDist);
        newLaser.SetActive(true);

        //Return result of the raycast.
        return victim;

    }

    private void OnLeft_Stick(InputValue value)
    {
        //Store the value into railDirection, so we can constantly re-use the value...
        //Cuz this function only actually updates when there is actual change in value.
        railDirection = value.Get<Vector2>().x;

    }

    //Which socket do they currently have selected?
    private SocketObj current = null;

    private void OnSouth_Button()
    {
        //Fire the laser unless it not yet used.
        SocketObj socket = FireWire();

        //See if the laser/raycast have hit a socket.
        if(socket != null)
        {

            //Do we already have a previous one selected? If so power them!
            if(current != null)
            {
                Wires.Add(new WireObj(Instantiate(WireTemplate,SocketParent), current, socket));
                current = null;
            }
            else
            {
                current = socket; //Simply just store the socket for a later pair.
            }

        }

    }

}
