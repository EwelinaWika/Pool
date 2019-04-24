using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionListner : MonoBehaviour
{
    public LayerMask collisionLayer;


    public event Action<Rigidbody> CollisionEntered;

    private void OnTriggerEnter(Collider collision)
    {
     
        if (collision.gameObject.layer == 11)
        {
         
            if (collision.attachedRigidbody)
                CollisionEntered?.Invoke(collision.attachedRigidbody); 
          
        }
    }
}
