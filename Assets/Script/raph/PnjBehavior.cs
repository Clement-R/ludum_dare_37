using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjBehavior : MonoBehaviour {

    public float speed;
    public GameObject target;
    //private Vector3 targetVector;

    private float timeToDoor = 1.0f;
    private WaveController god;

    // Use this for initialization
    void Start () {
        //targetVector = (target.transform.position - this.transform.position).normalized;
        GameObject gameManager = GameObject.Find("GameController");
        god = gameManager.GetComponent<WaveController>();
        timeToDoor = god.TimeWalk;
        // Make the character move to the given point
        StartCoroutine(MoveOverSeconds(gameObject, target.transform.position, timeToDoor));
    }
	
	void Update () {
        //this.transform.position = Vector3.Lerp(this.transform.position, Vector3.zero, Time.deltaTime * speed);
        //transform.Translate(targetVector * Time.deltaTime * speed);
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }
}
