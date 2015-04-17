using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkTest : MonoBehaviour {
    public Text textOutput;

	// Use this for initialization
    IEnumerator Start()
    {
        WWW www = new WWW("www.pawz.ninja/pets");
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
