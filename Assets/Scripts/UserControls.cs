﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControls : MonoBehaviour {
    private readonly float SMOOTH = 5f;
    private readonly float MAX_TILT = 45f;

    // Use this for initialization
    void Start () {
		
	}

    
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * -1;
        float vertical = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal = " + horizontal + "; Vertical = " + vertical);        
        Quaternion target = Quaternion.Euler(MAX_TILT * vertical, 0, MAX_TILT * horizontal);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * SMOOTH);
    }
}
