using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public GameObject focalPoint;
    public float speed = 10;
    public float maxSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //if (rbPlayer.velocity.magnitude > maxSpeed) rbPlayer.velocity.magnitude = 5;
        rbPlayer.AddForce(focalPoint.transform.forward * speed * verticalInput, ForceMode.Force);
        rbPlayer.AddForce(focalPoint.transform.right * speed * horizontalInput, ForceMode.Force);

        
    }
}
