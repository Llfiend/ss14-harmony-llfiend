using System.Linq;
using Content.Server.Antag.Components;
using Content.Shared.EntityTable;
using Robust.Shared.Prototypes;

namespace Content.Server.Antag;

/// <summary>
/// Spawns an entity when creating an antag for <see cref="AntagSpawnerComponent"/>.
/// </summary>
public sealed class AntagSpawnerSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<AntagSpawnerComponent, AntagSelectEntityEvent>(OnSelectEntity);
    }

    [Dependency] private readonly IPrototypeManager _prototype = default!; // Harmony
    [Dependency] private readonly EntityTableSystem _entityTableSystem = default!; // Harmony

    private void OnSelectEntity(Entity<AntagSpawnerComponent> ent, ref AntagSelectEntityEvent args)
    {
        // Harmony, Same functionality
        if (ent.Comp.Prototype != null)
        {
            args.Entity = Spawn(ent.Comp.Prototype.Value);
            return;
        }
        // Harmony, allows AntagSpawner to additionally roll from an entity table
        if (ent.Comp.TableId != null &&
            _prototype.TryIndex(ent.Comp.TableId.Value, out var table))
        {
            var pick = _entityTableSystem.GetSpawns(table).FirstOrDefault();
            if (pick != default)
                args.Entity = Spawn(pick);
        }
    }
}
// End Harmony Change

