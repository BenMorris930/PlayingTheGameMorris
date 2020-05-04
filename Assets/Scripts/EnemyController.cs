using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRB;
    public GameObject playerObject;
    public float speed = 7;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (playerObject.transform.position - transform.position).normalized;
        Vector3 noY = new Vector3(moveDir.x, 0, moveDir.z);
        enemyRB.AddForce(noY * speed);
        if (transform.position.y < -10) Destroy(gameObject);
    }
}
