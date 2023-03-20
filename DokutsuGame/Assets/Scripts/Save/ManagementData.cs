using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


namespace Assets.Scripts.Save
{
    [DataContract]
    public  class ManagementData
    {

        [DataMember]
        private Dictionary<StageList, bool> Data;

        [DataMember]
        private int Money; 


        public void setData(StageList stage,bool state)
        {
            Data[stage]=state;
        }

        public bool getData(StageList stage)
        {
            return Data[stage];
        }

        public void setMoney(int money)
        {
            Money+=money;
        }
        public int getMoney()
        {
            return Money;
        }
        [DataMember]
        public StageList selectStage;

        public ManagementData()
        {
            Data= new Dictionary<StageList, bool>()
            {
                {StageList.Stage0,true },
                {StageList.Stage1,false },
                {StageList.Stage2,false },
                {StageList.Stage3,false },
                {StageList.Stage4,false },
                {StageList.Stage5,false },
                {StageList.Stage6,false },

            };
            this.selectStage = StageList.Stage0;
            this.Money=100;
        }
    }
}