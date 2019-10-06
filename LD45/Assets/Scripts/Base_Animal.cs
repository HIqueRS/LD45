﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Animal : MonoBehaviour
{
    public float Speed;
    private Vector2 VecDir;
    private Vector2 Dir;

    protected Rigidbody2D RB2D;
    private Vector2 MoveVel;

    public GameObject Eject;
    public bool Ejected;

    private float Force = 0;
    private float Wait = 0;
    private float WaitBt = 0;

    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(WaitBt > 0.2)
        {
            Aim();
        }
        

        if (!Ejected)
        {
            Movement();
            Ejecting();
        }

        RB2D.velocity = new Vector2(0, 0);
        RB2D.angularVelocity = 0;


        Wait += Time.deltaTime;
        WaitBt += Time.deltaTime;
    }

    private void Movement()
    {
        VecDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        MoveVel = VecDir.normalized * Speed;




        RB2D.MovePosition(RB2D.position + MoveVel * Time.deltaTime);
    }

    private void Ejecting()
    {
        if(Wait > 0.5)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Force += 10f;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (Force > 100)
                {
                    Force = 100;
                }

                GameObject Proj = Instantiate(Eject, transform.position + new Vector3(Dir.x * 1, Dir.y * 1), Quaternion.identity);
                Proj.GetComponent<Rigidbody2D>().AddForce(Dir * (100 + Force));

                Ejected = true;

                Force = 0;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Parasite")
        //{
        //    Destroy(collision.gameObject);
        //    Ejected = false;
        //}
    }

    protected void Aim()
    {


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Dir.x = 1;
            Dir.y = 0;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Dir.x = -1;
            Dir.y = 0;
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Dir.y = 1;
            Dir.x = 0;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            Dir.y = -1;
            Dir.x = 0;
        }

        if ((Input.GetAxisRaw("Horizontal") > 0) && (Input.GetAxisRaw("Vertical") > 0))//dir cim
        {
            Dir.x = 1;
            Dir.y = 1;
            WaitBt = 0;
        }
        else if ((Input.GetAxisRaw("Horizontal") > 0) && (Input.GetAxisRaw("Vertical") < 0))//dir baix
        {
            Dir.x = 1;
            Dir.y = -1;
            WaitBt = 0;
        }
        else if ((Input.GetAxisRaw("Horizontal") < 0) && (Input.GetAxisRaw("Vertical") < 0))//esq bai
        {
            Dir.x = -1;
            Dir.y = -1;
            WaitBt = 0;
        }
        else if ((Input.GetAxisRaw("Horizontal") < 0) && (Input.GetAxisRaw("Vertical") > 0))//esq cim
        {
            Dir.x = -1;
            Dir.y = 1;
            WaitBt = 0;
        }

       

    }

    public abstract void Especial();

    public void Parasitizing()
    {
        Wait = 0;
        Ejected = false;
       
    }
}
