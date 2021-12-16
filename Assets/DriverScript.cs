using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.8f;
    [SerializeField] float moveSpeed = 0.008f;
    [SerializeField] float slowSpeed = 0.006f;
    [SerializeField] float boostSpeed = 0.02f;

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "SpeedUp")
        {
            Debug.Log("Boosting!");
            moveSpeed = boostSpeed;
        }
    }
}
