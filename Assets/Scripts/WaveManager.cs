using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

    public GameObject[] zombiesPrefab;
    public Transform[] spawnPosition;

    public ObjectiveManager objManager;

    public int waveIndex = 0;
    public float waveDifficult = 0;
    public float waveTime = 30f;
    public float waveCount;

    public Text waveText;
    public Slider slider;
    public Animator anim;

    public int zAmount = 2;

	// Use this for initialization
	void Start () {

        waveCount = waveTime * (2f/3f);

	}
	
	// Update is called once per frame
	void Update () {
		
        if (waveCount >= waveTime)
        {

            waveText.text = "Wave " + waveIndex.ToString("00");
            anim.SetTrigger("wave");

            WaveSpawn();

            waveIndex++;
            waveCount = 0;

        }

        if (waveDifficult < 25f)
            zAmount = 2;
        else if (waveDifficult < 50f)
            zAmount = 3;
        else if (waveDifficult < 75f)
            zAmount = 4;
        else
            zAmount = 5;

        waveDifficult += 0.25f * Time.deltaTime;
        slider.value = waveDifficult;

        waveCount += Time.deltaTime;

	}

    void WaveSpawn()
    {

        if (objManager.objective[0])
        {

            for(int i = 0; i < spawnPosition.Length - 1; i++)
            {

                for (int n = 0; n < zAmount; n++)
                {

                    if (waveDifficult < 25f)
                    {

                        int zIndex = Random.Range(0, 3);
                        Instantiate(zombiesPrefab[zIndex], spawnPosition[i].position,Quaternion.identity);

                    }
                    else if (waveDifficult < 50f)
                    {

                        int zIndex = Random.Range(0, 2);
                        if (zIndex == 0)
                            zIndex = Random.Range(0, 3);
                        else
                            zIndex = 3;
                        Instantiate(zombiesPrefab[zIndex], spawnPosition[i].position, Quaternion.identity);

                    }
                    else if (waveDifficult >= 50f)
                    {

                        int zIndex = Random.Range(0, 3);
                        if (zIndex == 0)
                            zIndex = Random.Range(0, 3);
                        else if (zIndex == 1)
                            zIndex = 3;
                        else if (zIndex == 2)
                            zIndex = 4;
                        Instantiate(zombiesPrefab[zIndex], spawnPosition[i].position, Quaternion.identity);

                    }

                }

            }

        }
        else
        {

            for (int i = 0; i < spawnPosition.Length - 1; i++)
            {

                for (int n = 0; n < zAmount; n++)
                {

                    if (waveDifficult < 25f)
                    {

                        int zIndex = Random.Range(0, 3);
                        Instantiate(zombiesPrefab[zIndex], spawnPosition[i].position, Quaternion.identity);

                    }
                    else if (waveDifficult < 50f)
                    {

                        int zIndex = Random.Range(0, 2);
                        if (zIndex == 0)
                            zIndex = Random.Range(0, 3);
                        else
                            zIndex = 3;
                        Instantiate(zombiesPrefab[zIndex], spawnPosition[i].position, Quaternion.identity);

                    }
                    else if (waveDifficult >= 50f)
                    {

                        int zIndex = Random.Range(0, 3);
                        if (zIndex == 0)
                            zIndex = Random.Range(0, 3);
                        else if (zIndex == 1)
                            zIndex = 3;
                        else if (zIndex == 2)
                            zIndex = 4;
                        Instantiate(zombiesPrefab[zIndex], spawnPosition[i].position, Quaternion.identity);

                    }

                }

            }

        }

        

    }
}
