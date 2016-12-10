using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {
    public TextAsset waveJson;
    public GameObject pnjPrefab;
    public GameObject[] spawns;
    public GameObject[] doors;
    private List<Note> listNotes;
    private int currentIndex;
    private float startTime;
    private float currentTime;

    private void Awake()
    {
        currentIndex = 0;
        listNotes = new List<Note>();
        JSONObject json = new JSONObject(waveJson.text);
        Note temp;
        Debug.Log(json);
        json = json.list[0];
        foreach (JSONObject entry in json.list)
        {
            Debug.Log(entry);
            temp = new Note();
            JsonUtility.FromJsonOverwrite(entry.ToString(), temp);
            listNotes.Add(temp);
        }
    }

	void Start () {
        currentTime = startTime = Time.time;
        Debug.Log("startime " + startTime);
	}
	
	void Update () {
        if (currentIndex >= listNotes.Count)
            return;
        Note current = listNotes[currentIndex];
        currentTime += Time.deltaTime;
        //Debug.Log(startTime+ " " +current.time);

		while((current.time + startTime) <= currentTime)
        {
            GameObject o = Instantiate(pnjPrefab, spawns[current.door].transform.position, Quaternion.identity);
            o.GetComponent<PnjBehavior>().target = doors[current.door];
            currentIndex++;
            if (currentIndex >= listNotes.Count)
                return;
            current = listNotes[currentIndex];
        }
	}
}
