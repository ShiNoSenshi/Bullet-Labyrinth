using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalLogic : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject);
            SceneManager.LoadScene("Finish");
        }
    }
}
