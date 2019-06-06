using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lumberjack : MonoBehaviour
{
    private int MaxStock = 8;
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    private Light lantern;
    public AudioSource cutSound;
    private bool isOnTree = false;
    private int currentWaypoint = 0;

    public GameManager gameManager;
    private int logStock = 0;
    public Tree assignedTree;
    private bool waitForStorage = false;

    public KataLumberjack kataLumberjack;
    void Start()
    {
        kataLumberjack = GetComponent<KataLumberjack>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        if(isOnTree && animator.GetBool("cutTree") == false) {
            onTree();
        }
    }

    // State
    public bool isFull() {
        return logStock == MaxStock;
    }

    

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Forest")
        {
            assignedTree = other.gameObject.GetComponent<Forest>().getAvailableTree();
            kataLumberjack.OnForestEnter();
        }
        if (other.tag == "Storage" && !waitForStorage) {
            if(!gameManager.storage.IsFull()) {
                gameManager.storage.StoreWood(logStock);
                logStock = 0;
                waitForStorage = true;
            }
            else
            {
                waitForStorage = true;
                WaitForStorageNotFull();
            }
        }
        if (other.tag == "Tree") {
            Tree tree = other.gameObject.GetComponent<Tree>();
            if ( assignedTree == tree)
            {
                isOnTree = true;
            }
        }
        if (other.tag == "Waypoint") 
        {
            waitForStorage = true;
            WaitForStorageNotFull();
        }
    }

    // GoToAction
    public void GoToForest()
    {
        navMeshAgent.destination = gameManager.forest.transform.position;
        navMeshAgent.isStopped = false;
        animator.SetBool("walk", true);
    }

    public void GoToTree()
    {
        navMeshAgent.destination = assignedTree.transform.position;
        animator.SetBool("walk", true);
        navMeshAgent.isStopped = false;
    }

    public void GoToStorage() {
        navMeshAgent.destination = gameManager.storage.transform.position;
        animator.SetBool("walk", true);
        navMeshAgent.isStopped = false;
    }

    public void WaitForStorageNotFull()
    {
        GameObject waypoint = gameManager.storage.waypointList[currentWaypoint];
        if (currentWaypoint >= gameManager.storage.waypointList.Count -1)
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

    // Animation
    public void onTree() {
        animator.SetBool("walk", false);
        animator.SetBool("cutTree", true);
    }
    public void CutSound() {
        cutSound.Play();
        if(!isFull())
        {
            logStock++;
        }
    }

    public void EndCut() {
        animator.SetBool("cutTree", false);
        Destroy(assignedTree.gameObject);
        isOnTree = false;
        assignedTree = gameManager.forest.getAvailableTree();
        if (assignedTree != null) {
            GoToTree();
        } else {
            // TODO Null tree
        }
    }
}
