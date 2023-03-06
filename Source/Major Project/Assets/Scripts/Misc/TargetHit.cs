using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    public AudioSource impact;

    // Start is called before the first frame update
    void Start()
    {
        impact = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("targetEasy"))
        {
            impact.Play();
        }

        if(other.gameObject.CompareTag("targetMedium"))
        {
            impact.Play();
        }

        if(other.gameObject.CompareTag("targetHard"))
        {
            impact.Play();
        }

        if(other.gameObject.CompareTag("target"))
        {
            impact.Play();
        }
    }
}
