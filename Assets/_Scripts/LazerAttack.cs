using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAttack : MonoBehaviour
{
    public float lifespan = 4;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (lifespan > 0)
            lifespan -= Time.deltaTime;
        else
            Destroy(this.gameObject);

        //transform.Translate(Vector3.up * 10 * Time.deltaTime);
        rb.AddRelativeForce(new Vector3(0,0,50));
        //rb.velocity=Vector3.MoveTowards(transform.position,transform.forward*500,10);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "monster") {
            Debug.Log("HIT MNOSTER");
            other.gameObject.GetComponent<Enemy>().gotHit();
            Destroy(this.gameObject);
        }

    }
}
