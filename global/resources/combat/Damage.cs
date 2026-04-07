using Godot;
using Godot.Collections;

namespace Combat {
    [GlobalClass]
    public partial class Damage : Resource
    {
        [Export] public Dictionary<DamageType, float> DamageValues { get; set; } = new Dictionary<DamageType, float>();
        [Export] public Dictionary<StatusEffectType, float> StatusEffectValues { get; set; } = new Dictionary<StatusEffectType, float>();

        public Damage() { }
        public Damage(Dictionary<DamageType, float> damageValues, Dictionary<StatusEffectType, float> statusEffectValues)
        {
            DamageValues = damageValues;
            StatusEffectValues = statusEffectValues;
        }
        public Damage(int slashing = 0, int piercing = 0, int blunt = 0, int fire = 0, int ice = 0, int lightning = 0, int poison = 0,
                      int burn = 0, int freeze = 0, int shock = 0, int poisonEffect = 0)
        {
            DamageValues[DamageType.Slashing] = slashing;
            DamageValues[DamageType.Piercing] = piercing;
            DamageValues[DamageType.Blunt] = blunt;
            DamageValues[DamageType.Fire] = fire;
            DamageValues[DamageType.Ice] = ice;
            DamageValues[DamageType.Lightning] = lightning;
            DamageValues[DamageType.Poison] = poison;

            StatusEffectValues[StatusEffectType.Burn] = burn;
            StatusEffectValues[StatusEffectType.Freeze] = freeze;
            StatusEffectValues[StatusEffectType.Shock] = shock;
            StatusEffectValues[StatusEffectType.Poison] = poisonEffect;
        }

    }
}