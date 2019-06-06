using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageScript : MonoBehaviour
{
    public List<LogPileScript> logPileList;

    public List<GameObject> waypointList;

    public int woodCount = 0;
    public int MAX_STOCK = 0;

    public bool IsFull()
    {
        return woodCount >= MAX_STOCK;
    }

    // Update is called once per frame
    public void StoreWood(int logCount)
    {
        LogPileScript logPile = logPileList.Find((LogPileScript l) => {
            return l.state < 6;
        });
        if(logPile != null) {
            woodCount += logCount;
            logPile.storeWood();
        }
    }
}
