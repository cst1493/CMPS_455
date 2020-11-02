using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canister : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public float lifetime = 5f;
    public GameObject bullet;
    private Quaternion direction = Quaternion.Euler(Vector3.forward * 90);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpinAndShoot());
        Destroy(gameObject, lifetime);
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator SpinAndShoot()
    {
        while(lifetime != 0)
        {
            transform.rotation *= Quaternion.Euler(Vector3.forward*45);
            direction *= Quaternion.Euler(Vector3.forward * 45);
            Instantiate(bullet, this.transform.position, direction);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
