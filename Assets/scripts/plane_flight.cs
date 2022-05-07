using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane_flight : MonoBehaviour
{
    public Vector2 axis;
    public float mouseSensivity = 2f;

    public Vector2 axisSmoothing;
    public Transform centreOfMass;
    public Rigidbody rigidbody;
    public float updownadd = 15f;
    public float sidedownadd = 15f;
    public Transform gowno;
    public float accelerate = 150f;
    public float selfaccelerate = 150f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.centerOfMass = centreOfMass.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        axis.x += Input.GetAxis("Mouse X");
        axis.y += Input.GetAxis("Mouse Y");
        axis = Vector2.ClampMagnitude(axis, 1f);
        axis = new Vector2(Mathf.Lerp(axis.x, 0f, axisSmoothing.x * Time.deltaTime),
            Mathf.Lerp(axis.y, 0f, axisSmoothing.y * Time.deltaTime));

        rigidbody.AddForceAtPosition(new Vector3(sidedownadd * axis.x, -updownadd * axis.y, 0f) * Time.deltaTime, gowno.position);
        if(Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * Time.deltaTime * accelerate);
        }
        else
        {
            rigidbody.AddForce(transform.TransformDirection(Vector3.forward) * Time.deltaTime * selfaccelerate);
        }
    }
}
