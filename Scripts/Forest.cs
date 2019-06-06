using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : MonoBehaviour
{
    public List<Tree> treeLists;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Tree getAvailableTree()
    {
        Tree availableTree = treeLists.Find((Tree t) => {
            return !t.isLumberjackAssign;
        });
        if(availableTree == null) {
            return null;
        }
        availableTree.isLumberjackAssign = true;
        return availableTree;
    }
}
