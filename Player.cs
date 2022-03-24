using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jumpkeypressed;
    float horizontalInput;
    private Rigidbody rigidbodycomponent;

    public Transform groundCheckTransform = null;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodycomponent = GetComponent<Rigidbody>() ;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpkeypressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        rigidbodycomponent.velocity = new Vector3(horizontalInput, GetComponent<Rigidbody>().velocity.y, 0);
        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length==1)
        {
            return;
        }

        if(jumpkeypressed)
        {
            rigidbodycomponent.AddForce(Vector3.up*10, ForceMode.VelocityChange);
            jumpkeypressed = false;
        }
        
        
    }
    void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer==6)
            {
                Destroy(other.gameObject);
                Scoremaneger.instance.AddPoint();
            }
        }
    
}
