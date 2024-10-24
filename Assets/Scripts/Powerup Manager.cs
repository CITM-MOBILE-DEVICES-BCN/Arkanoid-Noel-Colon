using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PowerupManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject powerup;
    void Start()
    {
        
    }

    public void SpawnPowerup(GameObject brick)
    {
        GameObject clone;
        clone = GameObject.Instantiate(powerup, brick.transform.position + new Vector3(0, -1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
