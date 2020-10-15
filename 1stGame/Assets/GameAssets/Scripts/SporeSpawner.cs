using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeSpawner : MonoBehaviour
{
    public float enemyCount = 10.0f;
    private float spawnTime = 5.0f;

    //
    public GameObject SporeRed;
    public GameObject SporeBlack;
    public GameObject SporeGreen;
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAction());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnAction()
    {     
            if (SporeBlack)
            {
                while (enemyCount != 0)
                {
                    Instantiate(SporeBlack, this.transform.position, this.transform.rotation);
                    yield return new WaitForSeconds(spawnTime);
                    enemyCount--;
                }
            }
            if (SporeGreen)
            {
                while (enemyCount != 0)
                {
                    Instantiate(SporeGreen, this.transform.position, this.transform.rotation);
                    yield return new WaitForSeconds(spawnTime);
                    enemyCount--;
                }
            }
            if (SporeRed)
                {
                while (enemyCount != 0)
                {
                    Instantiate(SporeRed, this.transform.position, this.transform.rotation);
                    yield return new WaitForSeconds(spawnTime);
                    enemyCount--;
                }
            }
            
    }
}
