using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector3 ScreenPoint;
    public GameObject projectile;
    public Camera cam;
    public Vector3 pPoint;
    Rigidbody rb;
    Vector3 forwardDir;
    Vector3 rightDir;
    Transform myCamera;
    bool timer = false;
    private float camSpeed;

    //to be put in a player class later
    public float shotSpeed;
    public float cooldown;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        myCamera = GetComponentInChildren<Camera>().transform;
    }


    void RotateCam()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * camSpeed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * camSpeed);
        }
    }
    void MousePos()
    {
        ScreenPoint = Input.mousePosition;
        ScreenPoint.z = 10.0f;
        pPoint = cam.ScreenToWorldPoint(ScreenPoint);
    }
    void Shoot()
    {
        if (Input.GetButton("Fire1") && !timer)
        {
            timer = true;
            GameObject spawnedProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            pPoint.y = gameObject.transform.position.y;
            spawnedProjectile.transform.LookAt(pPoint);
            spawnedProjectile.GetComponent<Rigidbody>().AddForce(spawnedProjectile.transform.forward.normalized * shotSpeed);
            StartCoroutine(shotCooldown());
        }
    }
    void Move()
    {
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        forwardDir = gameObject.transform.forward * vert;
        rightDir = myCamera.transform.right * horz;
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (forwardDir + rightDir) * speed);
    }
    void Update()
    {
        RotateCam();
        MousePos();
        Shoot();
        Move();
    }
    //void OnDrawGizmos()
    //{
    //    ScreenPoint = Input.mousePosition;
    //    ScreenPoint.z = 10.0f;
    //    if(cam!=null)
    //    {
    //        pPoint = cam.ScreenToWorldPoint(ScreenPoint);
    //    }

    //    Gizmos.DrawSphere(pPoint, 1);
    //}
    IEnumerator shotCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        {
            timer = false;
        }
    }
}
