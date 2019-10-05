using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Parasite : MonoBehaviour
{
    public float Speed;
    private Vector2 VecDir;

    protected Rigidbody2D RB2D;
    private Vector2 MoveVel;

    public GameObject Eject;
    public bool Ejected;

    private float Force = 0;

    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Ejected)
        {
            Movement();
            Ejecting();
        }

        RB2D.velocity = new Vector2(0, 0);
        RB2D.angularVelocity = 0;

    }

    private void Movement()
    {
        VecDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveVel = VecDir.normalized * Speed;

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);


        RB2D.MovePosition(RB2D.position + MoveVel * Time.deltaTime);
    }

    private void Ejecting()
    {
        if (Input.GetMouseButton(0))
        {
            
            Force += 10;

        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject Proj = Instantiate(Eject, transform.GetChild(0).transform.position, Quaternion.identity);
            if (Force > 750)
            {
                Force = 750;
            }
            Proj.GetComponent<Rigidbody2D>().AddForce(transform.up * Force);
            Force = 0;



            Ejected = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Parasite")
        {
            Destroy(collision.gameObject);
            Ejected = false;
        }
    }

    public abstract void Especial();
}
