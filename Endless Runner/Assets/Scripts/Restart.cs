
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour {
    


    void Update () {
            if (Input.touchCount == 1 || Input.anyKey ){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
        }
    }
}
