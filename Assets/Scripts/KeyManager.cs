using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour {

    public GameObject[] keys;
    private int keyIndex;

	// Use this for initialization
	void Start () {

        keyIndex = Random.Range(0, keys.Length);
        keys[keyIndex].SetActive(true);

	}
	
}
