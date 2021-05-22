using System;
using System.Collections.Generic;


namespace RoleplayGame
{
     public interface IAttackItem : INormalItem
     {
          int Damage {get;}
     }
}