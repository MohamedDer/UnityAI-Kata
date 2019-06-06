using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static bool v3Equal(Vector3 first, Vector3 second) {
        return (first.x == second.x) && (first.z == second.z);
    }
}
