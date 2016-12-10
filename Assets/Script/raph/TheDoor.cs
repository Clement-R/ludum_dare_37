using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDoor : MonoBehaviour {

    public List<Collider> pnjsPreNormal;
    public List<Collider> pnjsPostNormal;
    public List<Collider> pnjsPerfect;
    WaveController waveController;

    public string inputKey;

    private void Awake()
    {
        pnjsPreNormal = new List<Collider>();
        pnjsPostNormal = new List<Collider>();
        pnjsPerfect = new List<Collider>();
    }

    void Start()
    {
        waveController = GameObject.Find("GameController").GetComponent<WaveController>();
    }


    //A mettre dans input detector
    void playerPressedKey()
    {
        if (pnjsPreNormal.Count <= 0 && pnjsPerfect.Count <= 0 && pnjsPostNormal.Count <= 0)
        {
            //Too early
            waveController.missNote();
            return;
        }

    }

    public void PreNormalTriggerEnter(Collider other)
    {
        pnjsPreNormal.Add(other);
        Debug.Log("pre normal enter " + other.name);
    }

    public void PerfectTriggerEnter(Collider other)
    {
        pnjsPerfect.Add(other);
        Debug.Log("perfect enter " + other.name);
    }

    public void PostNormalTriggerEnter(Collider other)
    {
        pnjsPostNormal.Add(other);
        Debug.Log("post normal enter " + other.name);
    }

    public void PreNormalTriggerExit(Collider other)
    {
        Debug.Log("pre normal exit " + other.name);
        pnjsPreNormal.Remove(other);
    }

    public void PerfectTriggerExit(Collider other)
    {
        Debug.Log("perfect exit " + other.name);
        pnjsPerfect.Remove(other);
    }

    public void PostNormalTriggerExit(Collider other)
    {
        Debug.Log("post normal exit " + other.name);
        pnjsPostNormal.Remove(other);
        other.transform.parent.GetComponent<PnjBehavior>().passedLastCollider();
    }
}
