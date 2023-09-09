using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    [HideInInspector]
    public Path_ path;
      
    public void CreatePath()
    {
        path = new Path_(transform.position);
    }
}
