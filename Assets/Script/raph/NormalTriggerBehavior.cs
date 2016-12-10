using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTriggerBehavior : MonoBehaviour {

    private DoorBehavior parent;

    void Start()
    {
        parent = transform.parent.GetComponent<DoorBehavior>();
    }

    void OnTriggerEnter(Collider aCol)
    {
        parent.NormalTriggerEnter(aCol);
    }

    void OnTriggerExit(Collider aCol)
    {
        parent.NormalTriggerExit(aCol);
    }
}
