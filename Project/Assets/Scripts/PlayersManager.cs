using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using Assets;
using System.Collections.Generic;

public class PlayersManager : MonoBehaviour {
    string getUsersUrl;
	// Use this for initialization
	void Start ()
    {
        GetPlayersRequest();
	}

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        Debug.Log("WWW text: " + www.text);

        List<Player> data = JsonConvert.DeserializeObject<List<Player>>(www.text);
        foreach (Player player in data) {
            string playerID = player.id;
            Debug.Log(playerID);
            if (!playerID.Equals(GlobalConsts.Instance.userID))
            {
                GameObject playerGO;
                if (transform.FindChild(playerID) != null)
                {
                    playerGO = transform.FindChild(playerID).gameObject;
                }
                else
                {
                    playerGO = Instantiate(Resources.Load("PlayerPrefab")) as GameObject;
                    playerGO.transform.parent = this.transform;
                    playerGO.name = playerID;
                    playerGO.GetComponent<PlayerServerConnection>().IsUser = false;
                    playerGO.GetComponent<PlayerServerConnection>().userID = playerID;
                    playerGO.SetActive(true);
                }
                var xPos = float.Parse(player.x);
                var yPos = float.Parse(player.y);
                playerGO.transform.position = new Vector3(xPos, yPos, 0);
            }
        }
        
    }
	// Update is called once per frame
	void FixedUpdate ()
    {
        GetPlayersRequest();
	}

    void GetPlayersRequest()
    {
        getUsersUrl = GlobalConsts.Instance.serverIP + "/users";
        WWW www = new WWW(getUsersUrl);

        StartCoroutine(WaitForRequest(www));
    }
}
