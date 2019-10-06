using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasyte : MonoBehaviour
{

    public float Speed;
    private Vector2 VecDir;

    protected Rigidbody2D RB2D;
    private Vector2 MoveVel;

    public float Life;

    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        Life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        Speed -= Time.deltaTime * 20;

        Life -= Time.deltaTime;
        if (Life <= 0)
            Destroy(gameObject);
        
        

    }

    private void Movement()
    {
        VecDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveVel = VecDir.normalized * Speed;   
        
        if((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0))
            RB2D.AddForce(MoveVel * Time.deltaTime);
    }
}
