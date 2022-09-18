using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    Rigidbody rigid;
    public float reverseGravity=3.37f;
    private float maxSpeed;
    public float maxReach=50f;
    private bool _randomRotation = false;
    private Vector3 randomRotation;
    void Start()
    {
        maxReach = 50f;
        reverseGravity = 3.37f;
        rigid = GetComponent<Rigidbody>();
        maxSpeed = (reverseGravity * rigid.mass);
        reverseGravity = 2f;
    }
    /*if(private floatuniversalmaxSpeed< maxSpeed)
        maxSpeed = universal*/
    void FixedUpdate()
    {
        if(transform.position.y < maxReach)
        {
            rigid.AddForce(new Vector3(0, reverseGravity * rigid.mass, 0));
            rigid.velocity = Vector3.ClampMagnitude(rigid.velocity, maxSpeed);
        }
        if(!_randomRotation && transform.tag != "Jetpack")
        {
            randomRotation.x = Random.Range(0, 150);
            randomRotation.y = Random.Range(0, 150);
            randomRotation.z = Random.Range(0, 150);
            _randomRotation = true;
            rigid.AddForce(randomRotation);
        }
    }
}
