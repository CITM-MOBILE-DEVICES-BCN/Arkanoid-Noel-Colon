using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Slider slider;
    private float minSpeed = 20;
    private float maxSpeed = 300;
    private float minAngle = 0.5f;
    private bool flying = false;
    // Start is called before the first frame update
    void Start()
    {
        RequestLaunch();
    }

    IEnumerator LaunchBallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        LaunchBall();
    }

    void RequestLaunch()
    {
        StartCoroutine(LaunchBallAfterDelay(2f));
    }

    void LaunchBall()
    {

        rb.velocity = new Vector2(2, 1).normalized * math.sqrt(minSpeed);
        flying = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector3(0,-3,0);
            flying=false;
            slider.value = 0;
            RequestLaunch();
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
        if (flying)
        {
            if (math.abs(rb.velocity.x) < minAngle)
            {
                rb.velocity += new Vector2(UnityEngine.Random.Range(-0.5f, 0.5f), 0);
            }

            if (math.abs(rb.velocity.y) < minAngle)
            {
                rb.velocity += new Vector2(0, UnityEngine.Random.Range(-0.5f, 0.5f));
            }

            if (rb.velocity.sqrMagnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * math.sqrt(maxSpeed);

            }
        }
       


    }
}
