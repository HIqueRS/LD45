using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push_Obj : MonoBehaviour
{

    protected Rigidbody2D RB2D;

    protected bool Was_pushed;
    // Start is called before the first frame update
    void Start()
    {
        Was_pushed = false;
        RB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Was_pushed)
        {

        }


       

        if (RB2D.velocity.magnitude < 0.5f && RB2D.velocity.magnitude < 0.5f)
        {
            RB2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }

    void Pushed()
    {

    }
}
