using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Base_Animal
{

    public float Dog_Speed;
    public GameObject Muco;
    public float Projectile_Force;
    protected float WaitProj=0;
    public float MaxWait=0.75f;

    void Start()
    {
        Speed = Dog_Speed;
        RB2D = GetComponent<Rigidbody2D>();
    }

    public override void Especial()
    {
        WaitProj += Time.deltaTime;

        if(WaitProj > MaxWait)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject Proj = Instantiate(Muco, transform.position + new Vector3(Dir.x * 1, Dir.y * 1), Quaternion.identity);
                Proj.GetComponent<Rigidbody2D>().AddForce(Dir * Projectile_Force);
                WaitProj = 0;
            }
           
        }
       
    }
}
