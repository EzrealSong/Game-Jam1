using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    private Rigidbody playerBody;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBody = player.GetComponent<Rigidbody>();
        offset = new Vector3(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y, transform.position.z - player.transform.position.z);
        transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z));
        //offset = new Vector3(0,2f,-5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        /*
        //transform.position = player.transform.position+offset;
        Vector2 offset = new Vector2(playerBody.velocity.x, playerBody.velocity.z);
        if(offset.magnitude == 0)
        {
            Vector3 fwd = player.transform.forward;
            fwd *= -5;
            offset = new Vector3(fwd.x, 5, fwd.z);
        }
        offset.Normalize();
        offset = offset * -5;
        
        transform.position = player.transform.position + new Vector3(offset.x, 0, offset.y);
        transform.position = new Vector3(transform.position.x, player.transform.position.y+5, transform.position.z);
        //transform.rotation = Quaternion.LookRotation(player.GetComponent<Rigidbody>().velocity);
        // transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y+2, player.transform.position.z));
        */
    }
    
}
