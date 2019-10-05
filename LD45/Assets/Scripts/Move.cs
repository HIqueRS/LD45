using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    private Vector2 VecDir;

    private Rigidbody2D RB2D;
    private Vector2 MoveVel;

    // Start is called before the first frame update
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        VecDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveVel = VecDir.normalized * Speed;

        RB2D.MovePosition( RB2D.position + MoveVel * Time.deltaTime);
    }
}
