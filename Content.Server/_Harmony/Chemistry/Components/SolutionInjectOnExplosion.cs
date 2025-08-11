using Content.Server.Chemistry.Components;
using Content.Shared.Chemistry.Reagent;


namespace Content.Server._Harmony.Chemistry.Components;

/// <summary>
/// Used for explosive entities that inject reagents into targets on explosion.
/// </summary>
[RegisterComponent]
public sealed partial class SolutionInjectOnExplosionComponent : BaseSolutionInjectOnEventComponent
{
    [DataField("reagents")]
    public List<ReagentQuantity> Reagents = new();
}
