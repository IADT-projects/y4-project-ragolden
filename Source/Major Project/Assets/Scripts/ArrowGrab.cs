using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowGrab : MonoBehaviour
{
    private RealtimeTransform RealtimeTransform;
    private Arrow Arrow;
    // Start is called before the first frame update
    void Start()
    {
        RealtimeTransform = GetComponent<RealtimeTransform>();
        Arrow = GetComponent<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Arrow.isSelected)
        {
            RealtimeTransform.RequestOwnership();
        }
    }
}
