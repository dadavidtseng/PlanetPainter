[Root](../../../AGENTS.md) > `Assets/Scripts/Map/`

# Map

Paints tilemaps beneath the player and reports completion percentage. `MapService` implements `IMapService`; `MapOutlookHandler` scans player bounds, skips unpaintable cells, and writes color-specific splash tiles; `MapPercentageHandler` counts paintable cells and updates progress. `MapRepository` stores painted tile information. Bound by `MapInstaller` and `GameInstaller`.

Key files: `MapService.cs`, `MapView.cs`, `MapRepository.cs`, `Handler/`, `Type/`. Depends on Player and Extenject tick/initialization interfaces. No tests discovered.
