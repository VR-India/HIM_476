using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the movement of the object, adjusting its rotation based on the type of collider during collision.
/// </summary>
public class ColliderBasedMotion : MonoBehaviour
{
    public float speed;
    public float resetSpeed;
    public Collider coll;
    public List<AnimatorClipInfo> clip;

    void Start()
    {
        coll = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        // Reset the speed when enabling the object.
        speed = resetSpeed;
    }

    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        AdjustRotationOnCollision();
    }

    private void Move()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }

    /// <summary>
    /// Adjusts the rotation of the object based on the type of collider during collision.
    /// </summary>
    private void AdjustRotationOnCollision()
    {
        if (coll is BoxCollider)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
        else if (coll is CapsuleCollider)
        {
            // Stop walking animation, adjust rotation to face a specific direction.
            GetComponent<Animator>().SetBool("stopWalk", true);
            transform.eulerAngles = new Vector3(0, 90, 0);

            // Set speed to 0 for CapsuleCollider collision.
            speed = 0;
        }
    }
}