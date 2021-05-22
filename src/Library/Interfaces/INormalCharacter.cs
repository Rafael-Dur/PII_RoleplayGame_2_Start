using System;
using System.Collections.Generic;


namespace RoleplayGame
{
     public interface INormalCharacter : ICharacter
     {
          List<INormalItem> Inventary {get; }

          void Equip(INormalItem item);

          void UnEquip(INormalItem item);
     }
}