using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingLeaf : OVRGrabbable
{
    bool bFalling = true;
    bool bAlreadyGrabbed = false;
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        bFalling = false;
        gameObject.SetActive(false);
        if (!bAlreadyGrabbed)
        {
            bAlreadyGrabbed = true;
            //Do whatever events you need to do here
        }
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(Vector3.zero, Vector3.zero);
        bFalling = true;
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        this.enabled = false;
    }

    float flRotSpeed, flSinSpeed, flPosSpeed;

    protected override void Start()
    {
        base.Start();
        flSinSpeed = Random.Range(1.5f, 2.5f);
        flRotSpeed = Random.Range(0.2f, 0.35f);
        flPosSpeed = Random.Range(0.001f, 0.01f);
    }

    void Update()
    {
        if (bFalling)
        {
            float flSinValue = Mathf.Sin(Time.time * flSinSpeed);

            transform.Rotate(-(flSinValue * flRotSpeed), 0.0f, flSinValue * flRotSpeed, Space.World);
            transform.Translate(flSinValue * flPosSpeed, -0.001f, 0.0f, Space.Self);
        }
    }
}
