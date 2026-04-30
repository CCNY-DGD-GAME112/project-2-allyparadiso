using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Projectile3DController : MonoBehaviour
{
    //My components
    public Rigidbody RB;
    
    //How fast do I fly?
    public float Speed = 15;
    //How hard do I knockback things I hit?
    public float Knockback = 5;
    public Camera Eyes;
   

    void Start()
    {
        transform.forward = Eyes.transform.forward;
        //When I spawn, I fly straight forwards at my Speed
        RB.linearVelocity = transform.forward * Speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        //If I hit something with a rigidbody. . .
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            //I push them in the direction I'm flying with a power equal to my Knockback stat
            rb.AddForce(RB.linearVelocity.normalized * Knockback,ForceMode.Impulse);

        }
        GameObject otherGameObject = other.gameObject;
        

        if (otherGameObject.CompareTag("Rat"))
        {
            Movement health = otherGameObject.GetComponent<Movement>();
            health.TakeDamage();
        }
        //If I hit anything, I despawn
        Destroy(gameObject);
    }

}
