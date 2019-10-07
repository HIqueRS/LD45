using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : Base_Animal
{

    protected float Wait_E = 0;

    public override void Especial()
    {
        transform.GetChild(0).transform.localPosition = new Vector3( +Dir.x,  + Dir.y -1);

        Wait_E += Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Destructive")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(collision.gameObject);
            }
            
        }
        else if(collision.gameObject.tag == "Push")
        {
            if(Wait_E > 1)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Dir.normalized * 500);

                    Wait_E = 0;
                }
            }
            
           
        }
    }


   
}
