using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Newtonsoft.Json;
using Assets;

public class PlayerServerConnection : MonoBehaviour {
    public Text textOutput;
    public bool IsUser = false;
    string postUserUrl;
    public string userID;

    // Use this for initialization
    void Start()
    {
        if(IsUser)
        {
            userID = GlobalConsts.Instance.userID;
            PostPlayerData();
        }
        else
        {
            GetPlayerData();
        }
        //textOutput.text = userID;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsUser)
        {
            PostPlayerData();
        }
        else
        {
            GetPlayerData();
        }
    }

    void GetPlayerData()
    {

    }

    void PostPlayerData()
    {
        

        Player player = new Player();
        player.id = userID;
        player.name = userID;
        player.x = this.transform.position.x.ToString();
        player.y = this.transform.position.y.ToString();

        string jsonString = JsonConvert.SerializeObject(player);
        //Debug.Log(jsonString);

        //Hashtable headers = form.headers;
        Hashtable headers = new Hashtable();
        headers.Add("Content-Type", "application/json");
        //headers.Add("Content-Type", "application/json");

        byte[] rawData = System.Text.Encoding.ASCII.GetBytes(jsonString);
        //Debug.Log(System.Text.Encoding.Default.GetString(rawData));

        postUserUrl = GlobalConsts.Instance.serverIP + "/user";
        WWW www = new WWW(postUserUrl, rawData, headers);
        StartCoroutine(WaitForRequest(www));
    }
    

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            //Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
