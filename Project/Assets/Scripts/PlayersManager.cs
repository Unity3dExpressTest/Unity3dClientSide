using UnityEngine;
using System.Collections;

public class PlayersManager : MonoBehaviour {
    string getUsersUrl;
	// Use this for initialization
	void Start ()
    {
        getUsersUrl = GlobalConsts.Instance.serverIP + "/users";
        WWW www = new WWW(getUsersUrl);
        StartCoroutine(WaitForRequest(www));
	}

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        Debug.Log(www.text);
    }
	// Update is called once per frame
	void Update ()
    {
	
	}
}
