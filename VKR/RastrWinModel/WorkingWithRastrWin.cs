using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASTRALib;

namespace RastrWinModel
{
    public class WorkingWithRastrWin
    {
        public string GetPowerValue(string pathFile)
        {
            IRastr rastr = new Rastr();
            rastr.Load(RG_KOD.RG_REPL, pathFile, "");

            var tables = rastr.Tables;

            foreach (var item in tables) 
            {
                var a = item;
            }
            return String.Empty;
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
