using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Setup")]
    public Transform RocketTarget;
    public Rigidbody RocketRgb;

    public float TurnSpeed = 1f;
    public float RocketFlySpeed = 10f;

    private Transform _rocketLocalTrans;

    void Start()
    {
        if (!RocketTarget)
        {
            Debug.Log("Please set the Rocket target");
        }
        _rocketLocalTrans = GetComponent<Transform>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!RocketRgb)
        
            return;
            RocketRgb.velocity = _rocketLocalTrans.forward * RocketFlySpeed;
        var rocketTargetrot = Quaternion.LookRotation(RocketTarget.position - _rocketLocalTrans.position);
        RocketRgb.MoveRotation(Quaternion.RotateTowards(_rocketLocalTrans.rotation, rocketTargetrot, TurnSpeed));


        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody plRgb = collision.gameObject.GetComponent<Rigidbody>();
            if (plRgb)
            {
                plRgb.AddForceAtPosition(Vector3.up * 1000f, plRgb.position);
            }
        }
    }
}
