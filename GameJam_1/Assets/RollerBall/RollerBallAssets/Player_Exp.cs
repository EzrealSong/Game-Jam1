using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Exp : MonoBehaviour
{
    private Rigidbody body;
    //private GameObject ball;
    public float speed = 5;
    public float jumpPower = 10;

    public float zInput;
    public Vector3 facing;
    void Start()
    {
        //ball = GameObject.FindGameObjectWithTag("Player");
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(xInput, 0, zInput);
        Vector3 forward_movement = (body.velocity.magnitude==0) ? new Vector3(0,0,zInput): body.velocity * zInput;
        forward_movement = forward_movement * speed;
        forward_movement = Vector3.ClampMagnitude(forward_movement,speed);

        Vector3 side_movement = perpendicular(forward_movement);
        side_movement = (side_movement.magnitude==0)? new Vector3(xInput,0,0):side_movement* xInput * speed;
        side_movement = Vector3.ClampMagnitude(side_movement,speed);

        body.AddForce(forward_movement);
        body.AddForce(side_movement);
        facing = forward_movement;
        if(Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector3.up*jumpPower,ForceMode.Impulse);
        }

        
    }

    private Vector3 perpendicular(Vector3 inVec)
    {
        /*
        function (a,b,c) 
        {
            return  c<a  ? (b,-a,0) : (0,-c,b) 
        }
        */
        return (inVec.z < inVec.x) ? new Vector3(inVec.y, -inVec.x, 0) : new Vector3(0, -inVec.z, inVec.y);
    }
}
