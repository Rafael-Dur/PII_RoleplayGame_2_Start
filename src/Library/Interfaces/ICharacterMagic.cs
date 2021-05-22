using System;
using System.Collections.Generic;


namespace RoleplayGame
{
     public interface ICharacterMagic : ICharacter, IItem
     {
          List<IItem> Inventary {get; }

          void Equip(IItem item);

          void UnEquip(IItem item);
     }
}