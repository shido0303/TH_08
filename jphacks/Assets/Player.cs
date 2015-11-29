using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

    public float speed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        if (Input.GetButton("Jump"))
        {
            transform.position += transform.forward * 0.5f;
        }
	}

}
