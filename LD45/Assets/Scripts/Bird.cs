using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Base_Animal
{
    public GameObject Obj;
    public bool WithObj = false;

    public float WaitObj = 0;

    public override void Especial()
    {
        WaitObj += Time.deltaTime;

        if (WithObj)
        {            
            Obj.transform.position = transform.GetChild(0).transform.position;
            Obj.GetComponent<BoxCollider2D>().enabled = false;
        }
        if( WaitObj > 0.2f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                WithObj = false;
                WaitObj = 0;
                Obj.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            if (WaitObj > 0.2f)
            {
                if (!WithObj)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Obj = collision.gameObject;
                        WithObj = true;
                        WaitObj = 0;
                    }
                }
            }
           
        }
    }
}
