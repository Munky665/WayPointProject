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
            //adds the maps file location to save file
            info.AddValue("map", map, typeof(string));
            //adds the waypoint char to save file
            info.AddValue("waypoint", waypoint, typeof(char));
            //adds a reference count for the waypoints in waypoint storage 
            info.AddValue("waypointCount", m_waypointStorage.Count, typeof(int));
            //adds waypoint storage list to save file
            for (int i = 0; i < m_waypointStorage.Count; i++)
            {
                info.AddValue("Waypoints" + i, m_waypointStorage[i], typeof(WayPointButton));
            }

            info.AddValue("edgeCount", m_edgeStorage.Count, typeof(int));
            for(int i = 0; i < m_edgeStorage.Count; i++)
            {
                info.AddValue("Edge" + i, m_edgeStorage[i],typeof(Edge));
            }

            info.AddValue("waypointlistCount", WaypointListBox.Count, typeof(int));
            for(int i = 0; i < WaypointListBox.Count; i++)
            {
                info.AddValue("waypointList" +i, WaypointListBox[i], typeof(string));
            }

            info.AddValue("weightlistCount", WeightListBox.Count, typeof(int));
            for(int i = 0; i < WeightListBox.Count; i++)
            {
                info.AddValue("weightList" + i, WeightListBox[i], typeof(string));
            }
        }


        public Data(SerializationInfo info, StreamingContext context)
        {
            map = (string)info.GetValue("map", typeof(string));
            waypoint = (char)info.GetValue("waypoint", typeof(char));

            int count = (int)info.GetValue("waypointCount", typeof(int));
            for(int i = 0; i < count; i++)
            {
                m_waypointStorage.Add((WayPointButton)info.GetValue("Waypoints" + i, typeof(WayPointButton)));
            }

            count = (int)info.GetValue("edgeCount", typeof(int));
            for (int i = 0; i < count; i++)
            {
                m_edgeStorage.Add((Edge)info.GetValue("Edge" + i, typeof(Edge)));
            }

            count = (int)info.GetValue("waypointlistCount", typeof(int));
            for (int i = 0; i < count; i++)
            {
                WaypointListBox.Add((string)info.GetValue("waypointList" + i, typeof(string)));
            }

            count = (int)info.GetValue("weightlistCount", typeof(int));
            for (int i = 0; i < count; i++)
            {
                WeightListBox.Add((string)info.GetValue("weightList" + i, typeof(string)));
            }
        }
        //default constructor
        public Data()
        {

        }
        //sets map location to string
        public void SetMap(string s)
        {
            map = s;
        }
        //gets string with map location
        public string GetMap()
        {
            if (map != "")
                return map;
            else
                return null;
        }
        //adds a waypoint button to waypoint list
        public void AddWaypoint(WayPointButton b)
        {
            m_waypointStorage.Add(b);
        }
        //adds an edge to storage
        public void AddEdge(Edge e)
        {
            m_edgeStorage.Add(e);
        }
        //gets the list of waypoints
        public List<WayPointButton> GetWayPointButtons()
        {
            return m_waypointStorage;
        }
        //gets the list of edges
        public List<Edge> GetEdges()
        {
            return m_edgeStorage;
        }
        //clears all lists
        public void ClearData()
        {
            m_waypointStorage.Clear();
            m_edgeStorage.Clear();
            WeightListBox.Clear();
            WaypointListBox.Clear();
        }
        //remove specified edge
        public void RemoveEdge(Edge e)
        {
            m_edgeStorage.Remove(e);
        }
        //remove specified waypoint
        public void RemoveWaypoint(WayPointButton b)
        {
            m_waypointStorage.Remove(b);
        }
        //add waypoint name to listbox
        public void AddToWaypointList(string s)
        {
            WaypointListBox.Add(s);
        }
        //add weight of edge to list box
        public void AddToWeightList(string s)
        {
            WeightListBox.Add(s);
        }
        //get list of waypoint names
        public List<string> GetWaypoints()
        {
            return WaypointListBox;
        }
        //clear the waypoint list box
        public void ClearWaypointList()
        {
            WaypointListBox.Clear();
        }
        //returns the list of weights
        public List<string> GetWeights()
        {
            return WeightListBox;
        }
        //clears the weights from the list box
        public void ClearWeightList()
        {
            WeightListBox.Clear();
        }
    }
}
