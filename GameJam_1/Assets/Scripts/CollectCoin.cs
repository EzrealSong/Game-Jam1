using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private bool touched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private int rotationsPerMinute = 15;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,6*rotationsPerMinute*Time.deltaTime,0);
    }


    private void OnTriggerEnter(Collider other){
        if(other.name == "RollerBall" && !touched)
        {  
            FindObjectOfType<AudioManager>().Play("CoinPickup");
            other.GetComponent<PlayerCollectCoin>().points++;
            Destroy(gameObject);
        }

    }
}
