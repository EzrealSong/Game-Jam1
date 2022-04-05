using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Saw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private int rotationsPerMinute = 60;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,6*rotationsPerMinute*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
        if(other.name == "RollerBall")
        {  
            FindObjectOfType<AudioManager>().Play("Death");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

    }
}
