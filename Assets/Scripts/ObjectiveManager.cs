using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour {

    public Text objText;

    public GameObject[] menuObjText = new GameObject[4];

    public bool[] objective = new bool[2];
    public string[] objTextInfo = new string[3];

    public int objIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        objText.text = objTextInfo[objIndex];

        if (objective[0])
        {

            menuObjText[0].SetActive(false);
            menuObjText[1].SetActive(true);

        }

        if (objective[1])
        {

            menuObjText[2].SetActive(false);
            menuObjText[3].SetActive(true);

        }

    }
}
