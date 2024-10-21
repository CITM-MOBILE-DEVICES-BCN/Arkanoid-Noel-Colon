using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    public GameObject game;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector2(2,1)*100);
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
        if(rb.velocity.sqrMagnitude < 500)
        {
            rb.AddForce(rb.velocity);
        }
        Debug.Log((int)rb.velocity.x + " " + (int)rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
