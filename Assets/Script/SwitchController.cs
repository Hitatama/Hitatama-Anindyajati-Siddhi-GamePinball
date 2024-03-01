using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwtichState
    {
        off,
        on,
        Blink
    }

    public Collider bola;
    public Material onMaterial;
    public Material offMaterial;
    public float score;

    public ScoreManager scoreManager;

    private SwtichState state;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Toggle();
        }

    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwtichState.on;
            render.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwtichState.off;
            render.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == SwtichState.on)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }

        //score add
        scoreManager.AddScore(score);
    }

    private IEnumerator Blink(int times)
    {
        state = SwtichState.Blink;

        

        for(int i = 0; i < times; i++)
        {
            render.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            render.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwtichState.off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

}
