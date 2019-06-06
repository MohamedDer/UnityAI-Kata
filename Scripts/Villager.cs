using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public GameManager gameManager;
    public bool isDead;
    public List<GameObject> waypointList;
    private int currentWaypoint = 0;
    private Lumberjack lumb;

    public KataVillager kataVillager;

    // Start is called before the first frame update
    void Start()
    {
        kataVillager = GetComponent<KataVillager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void GoToSwarmill()
    {
        if(!isDead) {
            Sawmill sawmill = GetClosestSawmill();
            lumb = Instantiate(gameManager.lumberjackPrefab, this.transform.position, this.transform.rotation);
            lumb.gameObject.SetActive(false);
            navMeshAgent.destination = sawmill.transform.position;
            navMeshAgent.isStopped = false;
            animator.SetBool("walk", true);
        }
    }

    public Sawmill GetClosestSawmill()
    {
        return gameManager.sawmillLists[0];
    }

    public void GoToWayPoint()
    {
        if (!this.isDead)
        {
            GameObject waypoint = waypointList[currentWaypoint];
            if (currentWaypoint >= waypointList.Count - 1)
            {
                currentWaypoint = 0;
            }
            else
            {
                currentWaypoint++;
            }
            navMeshAgent.destination = waypoint.transform.position;
            navMeshAgent.isStopped = false;
            animator.SetBool("walk", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sawmill")
        {
            Sawmill sawmill = other.gameObject.GetComponent<Sawmill>();
            if(Utils.v3Equal(navMeshAgent.destination, sawmill.transform.position)) {
                if (sawmill.lumberjackLists.Count >= 1) {
                    this.isDead = true;
                    navMeshAgent.isStopped = true;
                    animator.SetBool("walk", false);
                    animator.SetBool("isDead", true);
                } else {
                    gameManager.villagerLists.Remove(this);
                    lumb.transform.position = transform.position;
                    lumb.gameObject.SetActive(true);
                    lumb.gameManager = gameManager;
                    sawmill.lumberjackLists.Add(lumb);
                    Destroy(this.gameObject);
                }
            }
        }
        if(other.tag == "Waypoint")
        {
            GoToWayPoint();
        }
    }
}
