using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Newtonsoft.Json;
using Assets;

public class PlayerScript : MonoBehaviour {
    public Text textOutput;
    public bool IsUser = false;
    public string url = "52.6.61.57/user";

    // Use this for initialization
    void Start()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        
        /*
        WWWForm form = new WWWForm();
        form.AddField("id", deviceID);
        form.AddField("name", deviceID);
        form.AddField("x", this.transform.position.x.ToString());
        form.AddField("y", this.transform.position.y.ToString());
        */

        Player player = new Player();
        player.id = deviceID;
        player.name = deviceID;
        player.x = this.transform.position.x.ToString();
        player.y = this.transform.position.y.ToString();

        string jsonString = JsonConvert.SerializeObject(player);
        Debug.Log(jsonString);

        //Hashtable headers = form.headers;
        Hashtable headers = new Hashtable();
        headers.Add("Content-Type", "application/json");
        //headers.Add("Content-Type", "application/json");

        byte[] rawData = System.Text.Encoding.ASCII.GetBytes(jsonString);
        //Debug.Log(System.Text.Encoding.Default.GetString(rawData));

        WWW www = new WWW(url, rawData, headers);
        StartCoroutine(WaitForRequest(www));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        WWWForm form = new WWWForm();
        form.AddField("id", deviceID);
        form.AddField("name", deviceID);
        form.AddField("x", this.transform.position.x.ToString());
        form.AddField("y", this.transform.position.y.ToString());

        WWW www = new WWW(url + ":" + port + route, form);
        StartCoroutine(WaitForRequest(www));*/
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

        //textOutput.text = www.text;
    }
}
