using AlarmCenter.DataCenter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWAlarm
{
    public class CEquip : CEquipBase
    {
        bool Isinit = true;
        int Interval = 1;
        bool result = true;
        bool results = true;
        int count = 100;
        int counts = 0;
        public override bool init(EquipItem item)
        {
            if (!base.init(item))//设备初始化
            {
                if (Isinit)
                {
                    DataCenter.WriteLogFile("GWAlarmCenter初始化失败");
                    Isinit = false;
                    return Isinit;
                }
            }
            //读取数据库Equip表communication_time_param字段配置，表休眠时间
            Interval = Convert.ToInt32(item.communication_time_param);
            return true;
        }
        public override CommunicationState GetData(CEquipBase pEquip)
        {
            return base.GetData(pEquip);
        }
        public override bool GetYC(DataRow r)
        {
            if(counts<10)
            {
                SetYCData(r, count);
                count = count + 3;
                counts = counts + 1;
                Sleep(1000);
            }
            if(counts>9&&counts<15)
            {
                SetYCData(r, count);
                count = count-1;
                counts = counts + 1;
                Sleep(1000);
            }
            else
            {
                SetYCData(r, count);
            }
            return true;
        }
        public override bool GetYX(DataRow r)
        {
            if(r[ "main_instruction"].ToString() == "触碰")
            {
                SetYXData(r, result);
            }
            if (r["main_instruction"].ToString() == "接近")
            {
                SetYXData(r, results);
            }
            return true;
        }
        public override bool SetParm(string MainInstruct, string MinorInstruct, string Value)
        {
            if (MainInstruct.ToLower()=="open")
            {
                result = true;
            }
            if (MainInstruct.ToLower() == "close")
            {
                result = false;
            }
            if (MainInstruct.ToLower() == "opens")
            {
                results = true;
            }
            if (MainInstruct.ToLower() == "closes")
            {
                results = false;
            }
            return true;
        }
    }
}
