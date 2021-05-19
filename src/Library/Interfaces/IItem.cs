using System;
using System.Collections.Generic;


namespace RoleplayGame
{
     public interface IItem
     {
          string Name {get;}

          int Damage {get;} 

          int Protection {get;}

          string Description {get; set;}

          bool MagicItem {get;}

     }
}