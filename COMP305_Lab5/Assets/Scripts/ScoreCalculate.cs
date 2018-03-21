using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculate : MonoBehaviour {

    public GameObject persistedObject;
    // Use this for initialization
    void Start () {
        Instantiate(persistedObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        persistedObject = GameObject.Find("Score");
    }
}
