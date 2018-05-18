using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startmoveball : MonoBehaviour {
    public Rigidbody rb;
    public float thrust;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -thrust);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
