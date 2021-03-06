using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gliderHandle : OVRGrabbable
{
    bool bGrabbed = false;
    public GameObject parent;
    GameObject player;
    CharacterController controller;
    OVRPlayerController VRcontroller;
    OVRGrabber currentHand;
    float flDefaultGravity, flOriginalXRot, flOriginalYRot;
    public float flSpeedMultiplier = 1.0f;
    public float flQuaternion = 2.0f;
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<CharacterController>();
        flDefaultGravity = player.GetComponent<OVRPlayerController>().GravityModifier;
        VRcontroller = player.GetComponent<OVRPlayerController>();
    }
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        currentHand = hand;
        bGrabbed = true;
        controller.enabled = false;
        VRcontroller.enabled = false;
        player.transform.SetParent(parent.transform);
        transform.parent = parent.transform;
        flOriginalXRot = currentHand.gameObject.transform.rotation.x;
        flOriginalYRot = currentHand.gameObject.transform.rotation.y;
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        bGrabbed = false;
        controller.enabled = true;
        VRcontroller.enabled = true;
        controller.velocity.Set(0.0f, 0.0f, 0.0f);
        player.transform.SetParent(null);
        transform.parent = parent.transform;
    }

    void Update()
    {
        if (bGrabbed)
        {
            float flNewRot = currentHand.gameObject.transform.rotation.x - flOriginalXRot;
            float flNewRotY = currentHand.gameObject.transform.rotation.y - flOriginalYRot;
            parent.transform.Translate(0.0f, 0.0f, 0.06f* flSpeedMultiplier, Space.Self);
            parent.transform.localRotation = Quaternion.Lerp(parent.transform.localRotation, new Quaternion(flNewRot, flNewRotY, 0.0f, 1.5f), Time.deltaTime * flQuaternion);
        }
        if (transform.parent != parent.transform)
        {
            transform.parent = parent.transform;
            transform.localPosition = new Vector3(1.08f, 0.0f, 0.0f);
            transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
            transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}

