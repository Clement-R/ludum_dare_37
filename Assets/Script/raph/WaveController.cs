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

    private int nbrNoteOk;
    private int nbrNotePerfect;
    private int nbrNoteMissed;
    public int nbrTotalNote;
    private float ratio;

    public int ptsOk;
    public int ptsPerfect;
    private int score;

    public float TimeWalk = 1.0f;

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
        //Debug.Log("current time" + currentTime);

        while ((current.time - TimeWalk + startTime) <= currentTime)
        {
            GameObject o = Instantiate(pnjPrefab, spawns[current.door].transform.position, Quaternion.identity) as GameObject; //Quaternion.LookRotation(direction); pour plus tard
            o.GetComponent<PnjBehavior>().target = doors[current.door];
            currentIndex++;
            if (currentIndex >= listNotes.Count)
                return;
            current = listNotes[currentIndex];
        }
	}
    
    public void missNote()
    {
        nbrNoteMissed++;
        Debug.Log("current failures " + nbrNoteMissed);
        updateRatio();
    }

    public void validNote(bool perfect)
    {
        /*
        private int nbrNoteOk;
    private int nbrNotePerfect;
    private int nbrNoteMissed;
    public int nbrTotalNote;
    private float ratio;

    public int ptsOk;
    public int ptsPerfect;
    private int score;*/
        
        nbrTotalNote++;
        if (perfect)
            nbrNotePerfect++;
        else
            nbrNoteOk++;

        updateScore();
        updateRatio();
    }

    void updateScore()
    {
        score = nbrNoteOk * ptsOk + nbrNotePerfect * ptsPerfect;
        Debug.Log("New score: " + score);
    }

    void updateRatio()
    {
        if(nbrTotalNote != 0)
            ratio = ((nbrNoteOk + nbrNotePerfect) * 100) / nbrTotalNote;
    }
}
