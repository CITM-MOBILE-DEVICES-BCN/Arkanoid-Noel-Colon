using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 5;
    private Color red = Color.red;
    private Color green = Color.green;
    private Color blue = Color.blue;
    private Color yellow = Color.yellow;
    private Color black = Color.black;
    [SerializeField] private PowerupManager powerupManager;

    void Start()
    {
        SetColor();
    }

    

    void SetColor()
    {
        switch(hp)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().color = red;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().color = green;
                break;
            case 3:
                gameObject.GetComponent<SpriteRenderer>().color = blue;
                break;
            case 4:
                gameObject.GetComponent<SpriteRenderer>().color = yellow;
                break;
            case 5:
                gameObject.GetComponent<SpriteRenderer>().color = black;
                break;
        }
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            RemoveHP();
        }
    }
    void RemoveHP()
    {
        hp--;
        if (hp <= 0)
        {
            int number = (int)Random.Range(0f, 10f) + 1;
            if (number == 10)
            {
                powerupManager.SpawnPowerup(gameObject);
            }
            Destroy(gameObject);
        }
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RemoveHP();
        }
       */


    }
}
