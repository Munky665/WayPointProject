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

            info.AddValue("waypointCount", m_waypointStorage.Count, typeof(int));
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

        public void ClearWaypointList()
        {
            WaypointListBox.Clear();
        }
        public List<string> GetWeights()
        {
            return WeightListBox;
        }
        public void ClearWeightList()
        {
            WeightListBox.Clear();
        }
    }
}
