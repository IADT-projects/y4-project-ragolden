using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowRequest : MonoBehaviour
{
    public Transform Quiver;
    public string arrowName;

    public void SpawnArrow()
    {
        GameObject arrow = Realtime.Instantiate(arrowName, Quiver.position, Quiver.rotation);
    }
}
