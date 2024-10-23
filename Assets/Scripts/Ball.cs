using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    public GameObject game;
    private float minSpeed = 20;
    private float maxSpeed = 300;
    private float minAngle = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity +=new Vector2(2,1).normalized*math.sqrt(minSpeed);
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            transform.position = new Vector3(0,-3,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.velocity.sqrMagnitude < maxSpeed)
        {
            rb.AddForce(rb.velocity);
        }
        int speed = (int)rb.velocity.sqrMagnitude;
        Debug.Log(speed.ToString());
    }
    // Update is called once per frame
    void Update()
    {
       if(math.abs(rb.velocity.x) < minAngle)
        {
            rb.velocity += new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), 0);
        }

        if (math.abs(rb.velocity.y) < minAngle)
        {
            rb.velocity += new Vector2(0, UnityEngine.Random.Range(-0.5f, 0.5f));
        }

        if(rb.velocity.sqrMagnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized*math.sqrt(maxSpeed);

        }


    }
}
