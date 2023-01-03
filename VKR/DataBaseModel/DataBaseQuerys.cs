using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModel
{
    public static class DataBaseQuerys
    {
        public static string ConnectToDB(string nameServer, string nameDB)
        {
            return $@"data source={nameServer};
                      initial catalog={nameDB};
                      trusted_connection=true";
        }

        //public static string QueryForCalc(string eoName, string schemeName, string regulationType, int voltageLevel)
        //{
        //    return $"SELECT p.K2U_Value, p.Power_Value, v.Voltage_value, r.Regulation_type, s.Scheme_id, " +
        //           $"s.Scheme_name, e.Energy_object_number, e.Energy_object_name " +
        //           $"FROM Value_param p, Voltage_level v, Regulation r, Scheme s, Energy_object e " +
        //           $"WHERE e.Scheme_id = s.Scheme_id AND " +
        //           $"e.Regulation_id = r.Regulation_id AND " +
        //           $"e.Voltage_id = v.Voltage_id AND " +
        //           $"e.Value_id = p.Value_id AND " +
        //           $"Energy_object_name = '{eoName}' AND " +
        //           $"Scheme_name = '{schemeName}' AND " +
        //           $"Regulation_type = '{regulationType}' AND " +
        //           $"Voltage_value = '{voltageLevel}'";
        //}

        public static string QueryForCalc(string eoName, string schemeName, string regulationType, int voltageLevel)
        {
            return $"SELECT s.K2U_value, s.Power_value, s.Scheme_name, " +
                            $"s.Regulation_type, s.Voltage_value, e.Energy_object_name " +
                   $"FROM Schema_data s, Energy_object e " +
                   $"WHERE e.Scheme_id = s.Scheme_id AND " +
                           $"Energy_object_name = '{eoName}' AND " +
                           $"Scheme_name = '{schemeName}' AND " +
                           $"Regulation_type = '{regulationType}' AND " +
                           $"Voltage_value = '{voltageLevel}'";
        }

        public static string QueryForCalcAsym(string eoName, string schemeName, string regulationType, int voltageLevel)
        {
            return $"SELECT s.K2U_value, s.Current_value, s.Scheme_name, " +
                            $"s.Regulation_type, s.Voltage_value, e.Energy_object_name " +
                   $"FROM Schema_data s, Energy_object e " +
                   $"WHERE e.Scheme_id = s.Scheme_id AND " +
                           $"Energy_object_name = '{eoName}' AND " +
                           $"Scheme_name = '{schemeName}' AND " +
                           $"Regulation_type = '{regulationType}' AND " +
                           $"Voltage_value = '{voltageLevel}'";
        }

        //public static string QueryData
        //{
        //    get =>
        //           $"SELECT p.K2U_Value, p.Power_Value, v.Voltage_value, r.Regulation_type, " +
        //           $"s.Scheme_name, e.Energy_object_name " +
        //           $"FROM Value_param p, Voltage_level v, Regulation r, Scheme s, Energy_object e " +
        //           $"WHERE e.Scheme_id = s.Scheme_id AND " +
        //           $"e.Regulation_id = r.Regulation_id AND " +
        //           $"e.Voltage_id = v.Voltage_id AND " +
        //           $"e.Value_id = p.Value_id ";
        //}

        public static string QueryData
        {
            get =>
                   $"SELECT e.Energy_object_name, s.Scheme_name, " +
                   $"s.Regulation_type, s.Voltage_value, " +
                   $"s.K2U_value, s.Power_value, s.Current_value " +
                   $"FROM Schema_data s, Energy_object e " +
                   $"WHERE e.Scheme_id = s.Scheme_id";
        }

        public static string VoltageFilter(string voltageValue)
        {
            return
                   $"SELECT s.Scheme_name, s.Regulation_type, s.Voltage_value, " +
                            $"s.K2U_value, s.Power_value, s.Current_value, " +
                            $"e.Energy_object_name " +
                   $"FROM Schema_data s, Energy_object e " +
                   $"WHERE e.Scheme_id = s.Scheme_id AND Voltage_value = '{voltageValue}'";
        }

        //public static string QueryAllData
        //{
        //    get =>
        //           $"SELECT p.Value_id, p.K2U_Value, p.Power_Value, v.Voltage_id, v.Voltage_value, " +
        //           $"r.Regulation_id, r.Regulation_type, s.Scheme_id, s.Scheme_name, e.Energy_object_id, " +
        //           $"e.Energy_object_number, e.Energy_object_name " +
        //           $"FROM Value_param p, Voltage_level v, Regulation r, Scheme s, Energy_object e " +
        //           $"WHERE e.Scheme_id = s.Scheme_id AND " +
        //           $"e.Regulation_id = r.Regulation_id AND " +
        //           $"e.Voltage_id = v.Voltage_id AND " +
        //           $"e.Value_id = p.Value_id ";
        //}

        public static string QueryAllData
        {
            get =>
                   $"SELECT s.Scheme_id, s.Scheme_name, s.Regulation_type, s.Voltage_value, " +
                            $"s.K2U_value, s.Power_value, e.Energy_object_id, e.Energy_object_name " +
                   $"FROM Schema_data s, Energy_object e " +
                   $"WHERE e.Scheme_id = s.Scheme_id";
        }


        public static string LastId(string tableName, string columnName)
        {
            return $"SELECT TOP 1 {columnName} " +
                   $"FROM {tableName} " +
                   $"ORDER BY {columnName} DESC";
        }

        public static string QueryForEnObj => "SELECT * FROM Energy_object";

        //public static string QueryForScheme => "SELECT * FROM Scheme";

        //public static string QueryForReg => "SELECT * FROM Regulation";

        //public static string QueryForValue => "SELECT * FROM Value_param";

        //public static string QueryForVoltage => "SELECT * FROM Voltage_level";

        public static string QueryForSchemaData => "SELECT * FROM Schema_data";

        public static string QueryForSchemaName(string objName) => $"SELECT Scheme_name " +
                                                                   $"FROM Schema_data, Energy_object " +
                                                                   $"WHERE Energy_object_name = '{objName}'";

        public static string QueryForRegType(string objName) => $"SELECT Regulation_type " +
                                                                $"FROM Schema_data, Energy_object " +
                                                                $"WHERE Energy_object_name = '{objName}'";

        public static string QueryForColumn(string tableName,
            string columnName) => $"SELECT {columnName} FROM {tableName}";
    }
}
