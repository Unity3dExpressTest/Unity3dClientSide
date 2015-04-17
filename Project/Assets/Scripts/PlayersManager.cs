using UnityEngine;
using System.Collections;

public class PlayersManager : MonoBehaviour {
    public string getUsersUrl = GlobalConsts.Instance.serverIP + "/users";
	// Use this for initialization
	void Start () {
        
        WWW www = new WWW(getUsersUrl);
        StartCoroutine(WaitForRequest(www));
	}

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        Debug.Log(www.text);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
