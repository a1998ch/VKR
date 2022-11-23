using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationModel
{
    public static class DataBaseQuerys
    {
        public static string ConnectToDB(string nameServer, string nameDB)
        {
            return $@"data source={nameServer};
                      initial catalog={nameDB};
                      trusted_connection=true";
        }

        public static string QueryForCalc(int schemeNumber, string regulationType, int voltageLevel)
        {
            return $"SELECT p.K2U_Value, p.Power_Value, v.Voltage_value, r.Regulation_type, s.Scheme_number " +
                   $"FROM Value_param p, Voltage_level v, Regulation r, Scheme s " +
                   $"WHERE s.Voltage_id = v.Voltage_id AND " +
                   $"s.Value_id = p.Value_id AND " +
                   $"r.Regulation_id = s.Regulation_id AND " +
                   $"Scheme_number = '{schemeNumber}' AND " +
                   $"Regulation_type = '{regulationType}' AND " +
                   $"Voltage_value = {voltageLevel};";
        }

        public static string QueryAllData
        {
            get =>
                   $"SELECT p.K2U_Value, p.Power_Value, v.Voltage_value, r.Regulation_type, s.Energy_object_name, s.Scheme_number " +
                   $"FROM Value_param p, Voltage_level v, Regulation r, Scheme s " +
                   $"WHERE s.Voltage_id = v.Voltage_id AND " +
                   $"s.Value_id = p.Value_id AND " +
                   $"r.Regulation_id = s.Regulation_id";
        }
    }
}
