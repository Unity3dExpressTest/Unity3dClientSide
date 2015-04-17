using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkTest : MonoBehaviour {
    public Text textOutput;
    public string url;
    public int port;
    public string route;

	// Use this for initialization
    IEnumerator Start()
    {
        WWW www = new WWW(url + ":" + port + route);
        yield return www;
        textOutput.text = www.text;
	}

    void ConnectToServer()
    {
        //NetworkConnectionError conn = Network.Connect("www.google.com", 80, "");
        //Debug.Log(conn);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
