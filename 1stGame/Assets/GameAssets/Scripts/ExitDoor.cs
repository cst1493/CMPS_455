using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject door;
    public float timeBeforeSpawning;
    void Start()
    {
        if (timeBeforeSpawning == 0) { timeBeforeSpawning = 20; }
        
        StartCoroutine(SpawnAction());
    }
    IEnumerator SpawnAction()
    {
        yield return new WaitForSeconds(timeBeforeSpawning);
        Instantiate(door, this.transform.position, this.transform.rotation);
    }
}
