using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody body;
    //private GameObject ball;
    public float speed = 10;
    public float jumpPower = 10;

    public Vector3 facing;
    public Vector3 perpendicular;

    [SerializeField]
    private bool isJumping = false;

    private float xInput;
    private float zInput;
    void Start()
    {
        //ball = GameObject.FindGameObjectWithTag("Player");
        body = GetComponent<Rigidbody>();

        facing = transform.forward;
        perpendicular = GetPerpendicular(facing);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // print("jump");
            isJumping = true;
            FindObjectOfType<AudioManager>().Play("Jump");
            body.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        xInput = 0.5f*Input.GetAxis("Horizontal");
        zInput = 1f;

        if(transform.position.y < -5){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    void FixedUpdate()
    {        
        Vector3 zMovement = body.velocity;
        Vector3 xMovement = new Vector3(0, 0, (xInput * 2));
        // zMovement += ((facing*zInput) + (perpendicular*xInput))*speed;
        zMovement += (facing * zInput) * speed;
        



        if (zMovement.magnitude > 0)
            zMovement = Vector3.ClampMagnitude(zMovement,speed);
        else
            zMovement = Vector3.ClampMagnitude(zMovement,-speed);

        //print(zMovement);
        /*   
         Vector3 zMovement = new Vector3(xInput, 0, zInput);
         zMovement*=speed;
         zMovement = Vector3.ClampMagnitude(zMovement,speed);

          */
        body.AddForce(zMovement);
        body.MovePosition(transform.position - xMovement * Time.deltaTime * speed);
        body.velocity = Vector3.ClampMagnitude(body.velocity,speed);
      
 
        /*
        if(body.velocity.magnitude!=0 )
        {
            facing.x = body.velocity.x;
            facing.z = body.velocity.z;
            perpendicular = GetPerpendicular(facing);
        }
        if((body.velocity.x == 0 && body.velocity.z == 0))
        {
            facing = transform.forward;
            perpendicular = GetPerpendicular(facing);

        }
        */
    }

    //void FixedUpdate_base()
    //{
    //    float xInput = Input.GetAxis("Horizontal");
    //    float zInput = Input.GetAxis("Vertical");

    //    Vector3 zMovement = new Vector3(xInput, 0, zInput);
    //    zMovement*=speed;
    //    zMovement = Vector3.ClampMagnitude(zMovement,speed);
    //    body.AddForce(zMovement);
    //}

    
    private Vector3 GetPerpendicular(Vector3 inVec)
    {
        return new Vector3(inVec.z, 0, -inVec.x);
    }

    public void OnCollisionEnter(Collision col)
    {
        Vector3 delta = Vector3.zero;
        List<ContactPoint> list = new List<ContactPoint>();
        col.GetContacts(list);
       // print("Landing: " + col.contactCount);
        for(int i = 0; i < col.contactCount; i++)
        {
            delta += transform.position - list[i].point;
            //print(transform.position + " - " + list[i].point + " " + delta);
        }
        delta /= col.contactCount;
        //Debug.Log("Landing: Done " + delta + " --- " + Mathf.Abs(delta.y));
        if(Mathf.Abs(delta.y)>0.25)
            isJumping = false;
    }
}
