﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DAL1.Model;

namespace DAL1.Repository
{
    public class EventRepository
    {
        SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
        public List<Events> GetEvents()
        {
            List<Events> EventList = new List<Events>();
            DefaultConnection.Open();
            string sql = "Select * From Event";
            SqlCommand myCommand = new SqlCommand(sql, DefaultConnection);
            Events e;
            using (SqlDataReader dr = myCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    e = new Events
                    {
                        EventId = Convert.ToInt32(dr["Id"].ToString()),
                        EventName = dr["Name"].ToString(),
                        SId = Convert.ToInt32(dr["SourceId"].ToString()),
                    };
                    EventList.Add(e);
                }
            }
            return EventList;
        }
        public List<Events> GetEventsid(int sid)
        {
            List<Events> EventList = new List<Events>();
            DefaultConnection.Open();
            string sql = "Select * From Event where SourceId="+sid;
            SqlCommand myCommand = new SqlCommand(sql, DefaultConnection);
            Events e;
            using (SqlDataReader dr = myCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    e = new Events
                    {
                        EventId = Convert.ToInt32(dr["Id"].ToString()),
                        EventName = dr["Name"].ToString(),
                        SId = Convert.ToInt32(dr["SourceId"].ToString()),
                    };
                    EventList.Add(e);
                }
            }
            return EventList;
        }
    }
}
