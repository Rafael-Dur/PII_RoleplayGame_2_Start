using System;
using System.Collections.Generic;


namespace RoleplayGame
{
     public interface IMagicCharacter : ICharacter
     {
          List<IItem> Inventary {get; }

          void Equip(IItem item);

          void UnEquip(IItem item);
     }
}