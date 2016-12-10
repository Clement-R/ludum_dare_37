using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject entryA;
    public GameObject entryX;
    public GameObject entryB;
    public GameObject entryY;

    private TheDoor theDoorA;
    private TheDoor theDoorX;
    private TheDoor theDoorB;
    private TheDoor theDoorY;

    private WaveController waveControlller;

    void Start()
    {
        theDoorA = entryA.GetComponent<TheDoor>();
        theDoorX = entryX.GetComponent<TheDoor>();
        theDoorB = entryB.GetComponent<TheDoor>();
        theDoorY = entryY.GetComponent<TheDoor>();

        waveControlller = GameObject.Find("GameController").GetComponent<WaveController>();
    }

    void processColliders(TheDoor door)
    {
        //Check touch nothing
        if (door.pnjsPreNormal.Count <= 0 && door.pnjsPerfect.Count <= 0 && door.pnjsPostNormal.Count <= 0)
        {
            //Too early
            GameObject.Find("GameController").GetComponent<WaveController>().missNote();
            return;
        }
        //Check perfect
        List<Collider> removeMe = new List<Collider>();
        List<Collider> temp = door.pnjsPerfect;
        foreach (Collider col in temp) {
            waveControlller.validNote(true);

            removeMe.Add(col);
            door.pnjsPostNormal.Remove(col);
            door.pnjsPreNormal.Remove(col);

            col.transform.parent.GetComponent<PnjBehavior>().wasChecked();
        }
        foreach (Collider s in removeMe)
            door.pnjsPerfect.Remove(s);
        removeMe.Clear();
        //Check Post
        temp = door.pnjsPostNormal;
        foreach (Collider col in temp)
        {
            waveControlller.validNote(false);
            removeMe.Add(col);
            col.transform.parent.GetComponent<PnjBehavior>().wasChecked();
        }
        foreach (Collider s in removeMe)
            door.pnjsPostNormal.Remove(s);
        removeMe.Clear();
        //Check Pre
        temp = door.pnjsPreNormal;
        foreach (Collider col in temp)
        {
            waveControlller.validNote(false);
            removeMe.Add(col);
            col.transform.parent.GetComponent<PnjBehavior>().wasChecked();
        }
        foreach (Collider s in removeMe)
            door.pnjsPreNormal.Remove(s);
    }

    void Update()
    {
        if (Input.GetButtonDown("ButtonA"))
        {
            processColliders(theDoorA);
        }

        if (Input.GetButtonDown("ButtonX"))
        {
            processColliders(theDoorX);
        }

        if (Input.GetButtonDown("ButtonB"))
        {
            processColliders(theDoorB);
        }

        if (Input.GetButtonDown("ButtonY"))
        {
            processColliders(theDoorY);
        }
    }
}
