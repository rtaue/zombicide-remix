using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour {

    public AudioSource audSource;
    public AudioClip[] audClip;

    public float health = 20f;
    public float walk = 2.5f;
    public float running = 5f;

    public enum Zstate { Patrol, Bersek, Attack, Dead};
    public Zstate zState;
    public Animator anim;
    Rigidbody[] rdbs;

    public GameObject target;
    public bool targetOnSight = false;
    public float berserkTime = 5f;
    public float berserkCount;

    public GameObject paths;
    public Transform[] pathsIndv;
    int pathsRound = 1;

    public NavMeshAgent navAgent;

	// Use this for initialization
	void Start () {

        if (paths == null)
        {

            paths = GameObject.Find("ExteriorWaypoints");

        }

        pathsIndv = paths.GetComponentsInChildren<Transform>();

        rdbs = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rdb in rdbs)
        {

            rdb.isKinematic = true;

        }

        anim.enabled = false;
        Invoke("StartAnim", Random.value);

        pathsRound = Random.Range(1, pathsIndv.Length);
        navAgent.SetDestination(pathsIndv[pathsRound].position);

	}

    private void FixedUpdate()
    {

        switch (zState)
        {

            case (Zstate.Patrol):
                Patrol();
                break;

            case (Zstate.Bersek):
                Berserk();
                break;

            case (Zstate.Attack):
                Attack();
                break;

            case (Zstate.Dead):
                Dead();
                break;

        }

        if (!targetOnSight && (zState == Zstate.Attack || zState == Zstate.Bersek))
        {

            berserkCount += Time.deltaTime;
            if (berserkCount >= berserkTime)
            {

                target = null;

                anim.SetBool("running", false);

                zState = Zstate.Patrol;

                berserkCount = 0;

            }

        }

    }

    public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0f)
        {

            Die();

        }

    }

    void Die()
    {

        anim.SetBool("dying", true);

        zState = Zstate.Dead;

    }

    void StartAnim()
    {

        anim.enabled = true;

    }

    void Patrol()
    {

        audSource.clip = audClip[0];


        navAgent.SetDestination(pathsIndv[pathsRound].position);
        navAgent.speed = walk;

        Vector3 dir = pathsIndv[pathsRound].transform.position - transform.position;

        if (dir.magnitude < 2)
        {

            pathsRound = Random.Range(1, pathsIndv.Length);
            navAgent.SetDestination(pathsIndv[pathsRound].position);

        }

    }

    void Berserk()
    {

        audSource.clip = audClip[1];

        navAgent.SetDestination(target.transform.position);
        navAgent.speed = running;

        Vector3 dir = target.transform.position - transform.position;

        if (dir.magnitude < 2.5f)
        {

            zState = Zstate.Attack;

        }

        anim.SetBool("running", true);
        anim.SetBool("attack", false);

    }

    void Attack()
    {

        Vector3 dir = target.transform.position - transform.position;

        if (dir.magnitude > 2)
        {

            zState = Zstate.Bersek;

        }

        anim.SetBool("running", false);
        anim.SetBool("attack", true);

    }

    void Dead()
    {

        foreach (Rigidbody rdb in rdbs)
        {

            rdb.isKinematic = false;

        }

        navAgent.enabled = false;

        anim.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && zState != Zstate.Dead)
        {

            targetOnSight = true;
            target = other.gameObject;

            zState = Zstate.Bersek;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {

            targetOnSight = false;

        }

    }

}
