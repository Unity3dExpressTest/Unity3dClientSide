using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public Transform player;
    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
        player = this.transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        float xDelta = Input.GetAxis("Horizontal");
        float yDelta = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(xDelta, yDelta, 0);
        player.position += move * speed * Time.deltaTime;
	}
}
