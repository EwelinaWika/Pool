using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform whiteBall;
    public Transform cue;
    public CollisionListner collisionListner;
    public float force = 10;

    public float rotationSpeed = 1;
    public float swingForce = 1;
    public float minX;
    public float maxX;

    float curForce;


    Vector3 cueStartPos;

    private void Start()
    {
        transform.position = whiteBall.position;
        cueStartPos = cue.transform.localPosition;

        //Dodajemy metode CollisionListner do zdarzenia
        collisionListner.CollisionEntered += CollisionListner_CollisionEntered;
    }

        //Dodanie Siły fizycznej do piłki
    void CollisionListner_CollisionEntered(Rigidbody rigidbody)
    {
        var forward = transform.right;
        forward.y = 0;
        rigidbody.velocity = forward * -curForce;
    }



    private void Update()
    {
        Vector3 euler = transform.eulerAngles;
        transform.localRotation = Quaternion.Euler(euler + Vector3.up * rotationSpeed * Input.GetAxis("Mouse X"));
        float yAxis = Input.GetAxis("Mouse Y");
        Vector3 curPos = cue.localPosition + Vector3.right * swingForce * -yAxis;
        curPos.x = Mathf.Clamp(curPos.x, minX, maxX);
        cue.transform.localPosition = curPos;
        curForce = yAxis * force;
    }

}
