using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject brick;

    void Start()
    {
        SpawnAllBricks();
    }

    public void SpawnAllBricks()
    {
        for (int i = 5; i > 0; i--)
        {
            for (int j = 0; j < 6; j++)
            {
                string brickname = (i + "HP Brick (" + (j+1) + ")");
                GameObject clone = Instantiate(brick, new Vector3(7.5f - 3 * j, i - 1, 0), Quaternion.identity);
                clone.GetComponent<Brick>().hp = i;
                clone.name = brickname;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
