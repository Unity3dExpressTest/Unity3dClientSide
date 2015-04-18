using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Newtonsoft.Json;
using Assets;
using System;

public class PlayerServerConnection : MonoBehaviour {
    public Text textOutput;
    public bool IsUser = false;
    string postUserUrl;
    public string userID;
    public MeshRenderer renderer;

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
        textOutput.text = userID;
        byte[] ba = System.Text.Encoding.Default.GetBytes(userID);
        string hexString = BitConverter.ToString(ba);
        //Debug.Log("hexString: " + hexString);

        string redString = "" + hexString[0] + hexString[1];
        //Debug.Log("R: " + redString);
        float red = ConvertHexToFloat(redString);

        string greenString = "" + hexString[3] + hexString[4];
        //Debug.Log("G: " + greenString);
        float green = ConvertHexToFloat(greenString);

        string blueString = "" + hexString[6] + hexString[7];
        //Debug.Log("B: " + blueString);
        float blue = ConvertHexToFloat(blueString);

        renderer.material.color = new Color(red/256, green/256, blue/256);
    }

    float ConvertHexToFloat(string hexString)
    {
        int num = Int32.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
        return (float)num;
    }

    // Update is called once per frame
    void Update ()
    {
        if(IsUser && this.GetComponentInParent<PlayerController>().idle)
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
        player.x = this.transform.position.x.ToString();
        player.y = this.transform.position.y.ToString();

        string jsonString = JsonConvert.SerializeObject(player);
        //Debug.Log(jsonString);

        //Hashtable headers = form.headers;
		Dictionary<string, string> headers = new Dictionary<string, string>();
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
