using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameProgramming1.WaypointSystem
{
    public class Waypoint : MonoBehaviour
    {
        public Vector3 Position
        {
            get { return transform.position; }
        }
    }
}