using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControls : MonoBehaviour {
    public float maxTilt = 45f;
    public float smooth = 0.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal") * -1;
        float vertical = Input.GetAxis("Vertical");
        Debug.Log("Horizontal = " + horizontal + "; Vertical = " + vertical);        
        Quaternion target = Quaternion.Euler(maxTilt * vertical, 0, maxTilt * horizontal);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
