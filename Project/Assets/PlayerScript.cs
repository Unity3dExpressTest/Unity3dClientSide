using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    public Text textOutput;
    public bool IsUser = false;
    public string url;
    public int port;
    public string route;

    // Use this for initialization
    void Start()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        WWWForm form = new WWWForm();
        form.AddField("id", deviceID);
        form.AddField("name", deviceID);
        form.AddField("x", this.transform.position.x.ToString());
        form.AddField("y", this.transform.position.y.ToString());

        WWW www = new WWW(url + ":" + port + route, form);
        StartCoroutine(WaitForRequest(www));
    }

    // Update is called once per frame
    void Update()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        WWWForm form = new WWWForm();
        form.AddField("id", deviceID);
        form.AddField("name", deviceID);
        form.AddField("x", this.transform.position.x.ToString());
        form.AddField("y", this.transform.position.y.ToString());

        WWW www = new WWW(url + ":" + port + route, form);
        StartCoroutine(WaitForRequest(www));
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
