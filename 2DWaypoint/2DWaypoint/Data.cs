using System.Runtime.Serialization;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _2DWaypoint
{
    [Serializable]
    class Data : ISerializable
    {
        public char waypoint = 'A';
        public static int comboBox = 0;
        public int box = 0;
        public int selectBuffer = 5;
        public PointF DrawEllipsAt;
        string map;

        List<string> WaypointListBox = new List<string>();
        List<string> WeightListBox = new List<string>();
        List<WayPointButton> m_waypointStorage = new List<WayPointButton>();
        List<Edge> m_edgeStorage = new List<Edge>();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("map", map, typeof(string));
            info.AddValue("waypoint", waypoint, typeof(char));
            info.AddValue("Waypoints", m_waypointStorage, typeof(List<WayPointButton>));
            info.AddValue("Edge", m_edgeStorage, typeof(List<Edge>));
            info.AddValue("waypointList", WaypointListBox, typeof(List<string>));
            info.AddValue("weightList", WeightListBox, typeof(List<string>));
        }


        public Data(SerializationInfo info, StreamingContext context)
        {
            map = (string)info.GetValue("map", typeof(string));
            waypoint = (char)info.GetValue("waypoint", typeof(char));
            m_waypointStorage = (List<WayPointButton>)info.GetValue("Waypoints", typeof(List<WayPointButton>));
            m_edgeStorage = (List<Edge>)info.GetValue("Edge", typeof(List<Edge>));
            WaypointListBox = (List<string>)info.GetValue("waypointList", typeof(List<string>));
            WeightListBox = (List<string>)info.GetValue("weightList", typeof(List<string>));
        }

        public Data()
        {

        }

        public void SetMap(string s)
        {
            map = s;
        }

        public string GetMap()
        {
            if (map != "")
                return map;
            else
                return null;
        }
        public void AddWaypoint(WayPointButton b)
        {
            m_waypointStorage.Add(b);
        }

        public void AddEdge(Edge e)
        {
            m_edgeStorage.Add(e);
        }

        public List<WayPointButton> GetWayPointButtons()
        {
            return m_waypointStorage;
        }

        public List<Edge> GetEdges()
        {
            return m_edgeStorage;
        }

        public void ClearData()
        {
            m_waypointStorage.Clear();
            m_edgeStorage.Clear();
            WeightListBox.Clear();
            WaypointListBox.Clear();
        }

        public void RemoveEdge(Edge e)
        {
            m_edgeStorage.Remove(e);
        }
        public void RemoveWaypoint(WayPointButton b)
        {
            m_waypointStorage.Remove(b);
        }

        public void AddToWaypointList(string s)
        {
            WaypointListBox.Add(s);
        }

        public void AddToWeightList(string s)
        {
            WeightListBox.Add(s);
        }

        public List<string> GetWaypoints()
        {
            return WaypointListBox;
        }
        public List<string> GetWeights()
        {
            return WeightListBox;
        }
    }
}
