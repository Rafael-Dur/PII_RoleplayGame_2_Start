using System;
using System.Collections.Generic;


namespace RoleplayGame
{
     public interface ICharacter
     {
          string Name { get; }
          int Health {get; }
          int Damage {get; }
          string Role {get; }

          void Attack(ICharacter character);

          void RecieveAttack(int damage);

          void HealCharacter(ICharacter character);

          void Heal();

          void Respawn();

          int TotalDamage();

          int TotalProtection();
     }
}
