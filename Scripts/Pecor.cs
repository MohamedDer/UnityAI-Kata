using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pecor : MonoBehaviour
{
    public Villager villager;
    public Lumberjack lumb;

    // Start is called before the first frame update
    void Start()
    {
        lumb.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
