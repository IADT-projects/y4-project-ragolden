using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArrowRequest : MonoBehaviour
{
    private RealtimeTransform RealtimeTransform;
    private RealtimeView rtView;
    public int ownership = -1;

    // Start is called before the first frame update
    void Start()
    {
        RealtimeTransform = gameObject.GetComponent<RealtimeTransform>();
        rtView = gameObject.GetComponent<RealtimeView>();
    }

    public void Grabbed()
    {
        RealtimeTransform.RequestOwnership();
        rtView.RequestOwnership();
        ownership = RealtimeTransform.ownerID;
    }
}
