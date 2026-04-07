using Godot;
using Godot.Collections;

namespace Combat {
    [GlobalClass]
    public partial class Defence : Resource
    {
        [Export] public Dictionary<DamageType, float> DamageReflectPercentages { get; set; } = new Dictionary<DamageType, float>();
        [Export] public Dictionary<StatusEffectType, float> StatusEffectReflectPercentages { get; set; } = new Dictionary<StatusEffectType, float>();
        public Defence() { }
        public Defence(Dictionary<DamageType, float> damageReflectPercentages, Dictionary<StatusEffectType, float> statusEffectReflectPercentages)
        {            
            DamageReflectPercentages = damageReflectPercentages;
            StatusEffectReflectPercentages = statusEffectReflectPercentages;
        }
        public Defence(float slashing = 0, float piercing = 0, float blunt = 0, float fire = 0, float ice = 0, float lightning = 0, float poison = 0,
                       float burn = 0, float freeze = 0, float shock = 0, float poisonEffect = 0)
        {
            DamageReflectPercentages[DamageType.Slashing] = slashing;
            DamageReflectPercentages[DamageType.Piercing] = piercing;
            DamageReflectPercentages[DamageType.Blunt] = blunt;
            DamageReflectPercentages[DamageType.Fire] = fire;
            DamageReflectPercentages[DamageType.Ice] = ice;
            DamageReflectPercentages[DamageType.Lightning] = lightning;
            DamageReflectPercentages[DamageType.Poison] = poison;

            StatusEffectReflectPercentages[StatusEffectType.Burn] = burn;
            StatusEffectReflectPercentages[StatusEffectType.Freeze] = freeze;
            StatusEffectReflectPercentages[StatusEffectType.Shock] = shock;
            StatusEffectReflectPercentages[StatusEffectType.Poison] = poisonEffect;
        }
    }
}