using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Setting Structs / Struct:
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}


//"Main"
public class PlayerControler : MonoBehaviour 
{
    //Variables:
    private Rigidbody rb;

    public Boundary boundary;

    public GameObject shot;
    public GameObject shotSpecial;

    public Transform shotSpawn;

    private Vector3 movement;

    private Quaternion calibrationQuaternion;

    public Touch_Pad touchPad;

    public Fire_Pad firePad;

    public bool useTilt;

    public float drag_speed;
    public float tilt_speed;
    public float player_tilt;
    public float fireRate;
    public float special_fireRate;

    private float nextFire;

    public bool pwrUP;


    //Main Functions:
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        pwrUP = false;
        useTilt = false; //alternar entre trackpad e tilt

        CalibrateAccelerometer();
    }

    private void Update() 
    {
        if(firePad.CanFire() && Time.time > nextFire)
        {        
            if (pwrUP)
            {
                nextFire = Time.time + special_fireRate;
                Instantiate(shotSpecial, transform.position, transform.rotation);
            }
            else
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, transform.position, transform.rotation);
            }
        }
    }

    private void FixedUpdate()
    {
        if(useTilt)
        {
            Vector3 accelerationRaw = Input.acceleration;
            Vector3 acceleration = FixAcceleration(accelerationRaw);
            movement = new Vector3(acceleration.x, 0.0f, acceleration.y);

            rb.velocity = movement * tilt_speed;
        }
        else
        {
            Vector2 direction = touchPad.GetDirection();
            movement = new Vector3(direction.x, 0.0f, direction.y);

            rb.velocity = movement * drag_speed;
        }

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -player_tilt);
    }

    public void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    private Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }
}
