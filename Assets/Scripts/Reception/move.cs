using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class move : MonoBehaviour
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
        //if (this.gameObject.name == "Emily" || this.gameObject.name == "Davin")
            speed = resetSpeed;
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (coll.GetType() == typeof(BoxCollider))
            this.gameObject.transform.eulerAngles += new Vector3(0, 180, 0);

        else if (coll.GetType() == typeof(CapsuleCollider))
        {
            GetComponent<Animator>().SetBool("stopWalk", true);
            transform.eulerAngles = new Vector3(0, 90, 0);
            speed = 0;
        }
    }
}