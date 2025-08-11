// using Content.Server.Antag;
using Content.Shared.EntityTable;
using Robust.Shared.Prototypes;

namespace Content.Server.Antag.Components;

/// <summary>
/// Spawns a prototype for antags created with a spawner.
/// </summary>
[RegisterComponent, Access(typeof(AntagSpawnerSystem))]
public sealed partial class AntagSpawnerComponent : Component
{
    /// <summary>
    /// The entity to spawn.
    /// </summary>
    [DataField("prototype")]
    public EntProtoId? Prototype = null;
    // Harmony, updated to allow rolling from entity tables
    [DataField("table")]
    public ProtoId<EntityTablePrototype>? TableId = null;
}
