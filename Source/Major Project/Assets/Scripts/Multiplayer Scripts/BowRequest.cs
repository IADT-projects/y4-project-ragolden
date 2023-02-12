using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BowRequest : MonoBehaviour
{
    private RealtimeTransform RealtimeTransform;
    private Bow Bow;
    public int ownership = -1;

    // Start is called before the first frame update
    void Start()
    {
        RealtimeTransform = GetComponent<RealtimeTransform>();
        Bow = GetComponent<Bow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Bow.isSelected)
        {
            RealtimeTransform.RequestOwnership();
            ownership = RealtimeTransform.ownerID;
            //Debug.Log(ownership);
        }
    }
}
