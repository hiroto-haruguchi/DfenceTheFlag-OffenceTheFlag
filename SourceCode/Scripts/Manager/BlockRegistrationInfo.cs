using Assets.Scripts.Damage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class BlockRegistrationInfo
    {
        public Vector3 pos { get; set; }
        public DogTag myTag { get; set; }
        public BlockKindIs  iAm { get; set; }
        public BlockRegistrationInfo(Vector3 position, BlockKindIs iam,DogTag tag)
        {
            pos = position;
            myTag = tag;
            iAm = iam;  
        }

    }
}