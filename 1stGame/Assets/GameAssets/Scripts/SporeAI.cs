using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeAI : MonoBehaviour
{
    private GameObject closestPlayer;
    float speed = 1.0f;
    Vector2 currentPos;
    void Start()
    {
        closestPlayer = FindClosestPlayer();
        currentPos = this.gameObject.transform.position;
    }

    void Update()
    {
        this.transform.position = currentPos;
        currentPos = Vector2.MoveTowards(currentPos, closestPlayer.transform.position, (speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //TODO make player damage sound if we have time.
            GameObject.Destroy(gameObject);
        }
    }

    public GameObject FindClosestPlayer() //https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
