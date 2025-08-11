using Content.Shared.Damage.Systems;
using Content.Shared.EntityEffects;
using Content.Shared.FixedPoint;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

namespace Content.Shared._Goobstation.EntityEffects.Effects;

[UsedImplicitly]
public sealed partial class TakeStaminaDamage : EntityEffect
{
    /// <summary>
    /// How much stamina damage to take.
    /// </summary>
    [DataField]
    public FixedPoint2 Amount = FixedPoint2.New(10); // Changed from int to FixedPoint2

    /// <summary>
    /// Whether stamina damage should be applied immediately
    /// </summary>
    // [DataField]
    // public bool Immediate;

    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys)
    {
        // Start of Harmony change, colorcode for Guidebook
        var color = MathF.Sign((float) Amount) == 1 ? "red" : "green";
        var amountStr = $"[color={color}]{MathF.Abs((float) Amount)}[/color]";

        return Loc.GetString("reagent-effect-guidebook-deal-stamina-damage",
            // ("immediate", Immediate),
            ("amount", amountStr),
            ("chance", Probability),
            ("deltasign", MathF.Sign((float) Amount))
        );
    }
    // End of Harmony change

    public override void Effect(EntityEffectBaseArgs args)
    {
        if (args is EntityEffectReagentArgs reagentArgs)
        {
            if (reagentArgs.Scale != 1f)
                return;
        }

        args.EntityManager.System<SharedStaminaSystem>()
            .TakeStaminaDamage(args.TargetEntity,(float) Amount); // visual: false, immediate: Immediate);
    }
}
