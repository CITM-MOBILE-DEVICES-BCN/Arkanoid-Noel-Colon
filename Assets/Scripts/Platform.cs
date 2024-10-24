using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePos;
    private bool automatic = false;
    [SerializeField] private GameObject Ball;
    [SerializeField] private Slider Slider;
    [SerializeField] private Powerup Powerup;
    void Start()
    {
        
    }
    void SwitchModes()
    {
        automatic = !automatic;
    }

    void BecomeChungus()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Powerup"))
        {
            BecomeChungus();
            Destroy(collision.gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (!automatic)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(Slider.value, transform.position.y, transform.position.z);
        }
        else
        {
            if(Ball.transform.position.x <= 7.31 && Ball.transform.position.x >= -7.31)
            {
                transform.position = new Vector3(Ball.transform.position.x, transform.position.y, transform.position.z);
                Slider.value = transform.position.x;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchModes();
        }
        
    }
}
