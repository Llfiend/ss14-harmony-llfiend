using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Map;

namespace Content.Server._Harmony.Chemistry.Events

{
    [ByRefEvent]
    public readonly record struct SolutionInjectOnExplosionEvent(
        EntityCoordinates Epicenter,
        float TotalIntensity,
        float Slope,
        float MaxIntensity,
        List<ReagentQuantity> Reagents);
}

