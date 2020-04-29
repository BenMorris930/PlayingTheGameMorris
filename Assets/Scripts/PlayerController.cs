using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public GameObject focalPoint;
    public float speed = 10;
    public float maxSpeed = 5;
    public bool hasPowerup = false;
    public GameObject powerUp;
    public float repulsePower = 20;
    private Animator anim;
    public GameObject powerupRing;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //if (rbPlayer.velocity.magnitude > maxSpeed) rbPlayer.velocity.magnitude = 5;
        rbPlayer.AddForce(focalPoint.transform.forward * speed * verticalInput, ForceMode.Force);
        rbPlayer.AddForce(focalPoint.transform.right * speed * horizontalInput, ForceMode.Force);
        powerupRing.transform.position = transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            anim.SetBool("Has Powerup", true);
            powerupRing.SetActive(true);
            Destroy(powerUp.gameObject);
            StartCoroutine(PowerupCountdown());
        }
    }

    private IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(5.0f);
        hasPowerup = false;
        anim.SetBool("Has Powerup", false);
        powerupRing.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 repulseDir = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(repulseDir * repulsePower, ForceMode.Impulse);
        }
    }


}
