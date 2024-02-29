using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;

    private Renderer render;
    private Animator anim;

    private void Start()
    {
        render = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        render.material.color = color;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            //animation
            anim.SetTrigger("Hit");

        }
    }

    
}
