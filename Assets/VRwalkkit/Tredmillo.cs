using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tredmillo : MonoBehaviour {
    Rigidbody rb;
    private Animator animatorh;
    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        animatorh = GetComponent<Animator>();

    }
    float inputHorizontal;
    float inputVertical;

    // WASDで移動する
    float x = 0.0f;
    float z = 0.0f;

    

    public float movespeed = 0.01f;

    // Update is called once per frame
    void Update () {

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 cameraRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");


        if (SmartPhoneInput.PadGradX > 0.4)
        {
            transform.position += cameraForward * movespeed;

            z += 1.0f;
            animatorh.SetBool("iswalk", true); Debug.Log("up: " + SmartPhoneInput.PadGradY);
        }
        else
        {
            animatorh.SetBool("iswalk", false);
        }
        if (SmartPhoneInput.PadGradX < -0.4)
        {
            transform.position -= cameraForward * movespeed;

            z -= 1.0f;
            animatorh.SetBool("isback", true);
        }
        else
        {
            animatorh.SetBool("isback", false);Debug.Log("down: " + SmartPhoneInput.PadGradY);
        }
        
        
        if (SmartPhoneInput.PadGradZ > 0.5)
        {
            //x -= 1.0f;
            transform.position -= cameraRight * movespeed;

            animatorh.SetBool("isright", true);
        }
        else
        {
            animatorh.SetBool("isright", false);Debug.Log("right: " + SmartPhoneInput.PadGradZ);
        
        }
        
        if (SmartPhoneInput.PadGradZ < -0.5)
        {
            transform.position += cameraRight * movespeed;

            //x += 1.0f;
            //transform.Rotate(0, -10, 0);

            animatorh.SetBool("isleft", true);
        }
        else
        {
            animatorh.SetBool("isleft", false);
        
        Debug.Log("left: " + SmartPhoneInput.PadGradZ);


        }


    }
}
