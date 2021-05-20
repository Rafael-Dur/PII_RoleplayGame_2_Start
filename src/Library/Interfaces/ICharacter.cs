using System;
using System.Collections.Generic;


namespace RoleplayGame
{
     public interface ICharacter
     {
          string Name { get;}

          int Health {get;}

          int InitialHealth {get;}

          int Damage {get;} 

          string Role {get; }

          List<IItem> Inventary {get;}
          void Attack(ICharacter character);

          void RecieveAttack(int damage);

          void HealCharacter(ICharacter character);

          void Heal();

          void Respawn();

          void Equip(IItem item);

          void UnEquip(IItem item);

          int TotalDamage();

          int TotalProtection();
     }
}