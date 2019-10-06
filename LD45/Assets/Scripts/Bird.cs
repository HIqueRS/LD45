using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Base_Animal
{
    public GameObject Obj;
    public bool WithObj = false;

    public float WaitObj = 0;


    private RaycastHit2D hit2D;
    public bool FreeSpace = true;

    public override void Especial()
    {
        WaitObj += Time.deltaTime;

       // RaycastHit2D hit2D = Physics2D.Raycast(transform.GetChild(0).position, new Vector2(0, -1));
      //  Debug.DrawRay(transform.GetChild(0).position, new Vector2(0,-1));


        

        if (WithObj)
        {            
            Obj.transform.position = transform.GetChild(0).transform.position;
            Obj.GetComponent<BoxCollider2D>().enabled = false;

            Debug.DrawRay(Obj.transform.position + new Vector3(0, -0.5f, 0), new Vector2(0, -0.5f));
            //Vector2 teste = Obj.transform.position + new Vector3(0, -1,0);

            RaycastHit2D hit2D = Physics2D.Raycast(Obj.transform.position + new Vector3(0, -0.5f, 0), new Vector2(0, -0.5f));

            if (!hit2D)
            {
                if (WaitObj > 0.2f)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        WithObj = false;
                        WaitObj = 0;
                        Obj.transform.position = Obj.transform.position + new Vector3(0, -0.5f, 0);
                        Obj.GetComponent<BoxCollider2D>().enabled = true;
                    }
                }
            }

           
        }
        
        if(Ejected)
        {
            WithObj = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FreeSpace = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FreeSpace = true;
    }
}
