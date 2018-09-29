using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using DAL.Model;
using System.Data;

namespace DAL.Repository
{
    public class TemplatesRepository
    {
        SqlConnection DefaultConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString());
    }
}
