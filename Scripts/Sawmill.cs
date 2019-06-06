using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Sawmill : MonoBehaviour
{

    public List<Lumberjack> lumberjackLists;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Villager")
        {
            Villager villager = other.gameObject.GetComponent<Villager>();
            gameManager.villagerLists.Remove(villager);
            Lumberjack lum = Instantiate(lumberjackPrefab, villager.transform.position, villager.transform.rotation);
            lum.gameManager = gameManager;
            lumberjackLists.Add(lum);
            lum.GoToForest();
            Destroy(other.gameObject);
            if(lumberjackLists.Count > 10)
            {
                //todo
            }
        }
    }*/
}
