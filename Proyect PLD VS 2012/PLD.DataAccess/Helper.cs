using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

namespace PLD.DataAccess
{
    public static class Helper
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CS_Test"].ConnectionString;
        }
    }
}
