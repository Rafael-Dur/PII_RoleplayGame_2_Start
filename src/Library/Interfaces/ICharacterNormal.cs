using System;
using System.Collections.Generic;


namespace RoleplayGame
{
     public interface ICharacterNormal : ICharacter, INormalItem
     {
          List<INormalItem> Inventary {get; }

          void Equip(INormalItem item);

          void UnEquip(INormalItem item);
     }
}