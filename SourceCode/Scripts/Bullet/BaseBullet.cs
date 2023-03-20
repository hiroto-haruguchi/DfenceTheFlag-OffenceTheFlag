using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Damage;
using Assets.Scripts.CharcterSource;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public abstract class BaseBullet : CharacterBase
    {
        public Vector2 bulletVelocityDirection;
    }
}