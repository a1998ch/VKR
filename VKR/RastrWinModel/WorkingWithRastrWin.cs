using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ASTRALib;

namespace RastrWinModel
{
    public class WorkingWithRastrWin
    {
        public string GetPowerValue(string pathFile)
        {
            Regex pattern = new Regex(@"(\w*(могоча.*сш)\w*)|(\w*(сш.*могоча)\w*)", RegexOptions.IgnoreCase);

            IRastr rastr = new Rastr();
            rastr.Load(RG_KOD.RG_REPL, pathFile, "");

            ITable node = rastr.Tables.Item("node");
            ICol ny = node.Cols.Item("ny");
            ICol name = node.Cols.Item("name");
            ICol baseVoltage = node.Cols.Item("uhom");

            var result = String.Empty;
            for (int i = 0; i < node.Count; i++)
            {
                if (pattern.IsMatch(name.get_Z(i)) && baseVoltage.get_Z(i) == 220)
                {
                    result += ny.get_Z(i).ToString();
                }
            }
            return result;
            //ITable node = rastr.Tables.Item("node");
            //ICol pn = rastr.Tables.Item("node").Cols.Item("pn");
            //ICol ny = rastr.Tables.Item("node").Cols.Item("ny");

            //for (var col in node) { }

            //double number = pn.get_Z(0);
            //WriteLine("rastr {0}", number);
            //pn.set_Z(0, 111);
            //number = pn.get_Z(0);
            //WriteLine("rastr {0}", number);

            //WriteLine(calcRegim(rastr));

            //rastr.Save(PathFile, "");
            //ReadLine();
        }

        public void CalcRegim(Rastr inRastr)
        {
            ASTRALib.ITable ParamRgm = inRastr.Tables.Item("com_regim");
            ASTRALib.ICol statusRgm = ParamRgm.Cols.Item("status");
            inRastr.rgm(""); //Расчет режима 
            int status = statusRgm.get_Z(0);

            if(status== 1) 
            {
                throw new ArgumentException("Режим не сходится");
            }
        }
    }
}
