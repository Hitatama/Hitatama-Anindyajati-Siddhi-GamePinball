using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public float score;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;

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

            //playSFX
            audioManager.PlaySFX(collision.transform.position);

            //playVSX
            vfxManager.PlayVFX(collision.transform.position);

            //score add
            scoreManager.AddScore(score);
        }
    }

     
}
