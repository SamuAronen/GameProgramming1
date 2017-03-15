using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GameProgramming1.WaypointSystem
{
    public enum Direction
    {
        Forward,
        Backward
    }

    public enum PathType
    {
        Loop, // After reaching the last waypoint, user moves to the first waypoint
        PingPong, // User changes direction after reachin the last waypoint
        OneWay // User stops after reaching the last waypoint
    }

    interface IPathUser
    {
        Waypoint CurrentWaypoint { get; }
        Direction Direction { get; set; }
        Vector3 Position { get; set; }


        void Init(IMover mover, Path path);
    }
}