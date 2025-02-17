﻿using Microsoft.Xna.Framework;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Minigames;
using StardewValley.Objects;
using StardewValley.TerrainFeatures;
using SObject = StardewValley.Object;

namespace DecidedlyShared.Models;

public class WorldTile
{
    private readonly Vector2 tile;
    private readonly GameLocation location;
    private SObject? objectOnTile;
    private TerrainFeature? terrainFeatureOnTile;
    private Furniture? furnitureOnTile;
    private Crop? cropOnTile;
    private Tree? treeOnTile;
    private FruitTree? fruitTreeOnTile;

    public Vector2? Tile
    {
        get => this.tile;
    }

    public int? TileX
    {
        get => (int)this.tile.X;
    }

    public int? TileY
    {
        get => (int)this.tile.Y;
    }

    public WorldTile(Vector2 tile, GameLocation location)
    {
        this.tile = tile;
        this.location = location;
        this.objectOnTile = null;
        this.terrainFeatureOnTile = null;
        this.furnitureOnTile = null;
        this.cropOnTile = null;
        this.treeOnTile = null;
        this.fruitTreeOnTile = null;

        this.UpdateTile();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="tile"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public bool TryGetSObject(out SObject obj)
    {
        obj = this.objectOnTile;

        if (obj != null)
            return true;
        else
            return false;
    }

    public bool TryGetTerrainFeature(out TerrainFeature feature)
    {
        feature = this.terrainFeatureOnTile;

        if (feature != null)
            return true;
        else
            return false;
    }

    public bool TryGetFurniture(out Furniture? furniture)
    {
        furniture = this.furnitureOnTile;

        if (furniture == null)
            return false;
        else
            return true;
    }

    public bool TryGetCrop(out Crop crop)
    {
        crop = this.cropOnTile;

        if (crop == null)
            return false;
        else
            return true;
    }

    public bool TryGetTree(out Tree tree)
    {
        tree = this.treeOnTile;

        if (tree == null)
            return false;
        else
            return true;
    }

    public bool TryGetFruitTree(out FruitTree tree)
    {
        tree = this.fruitTreeOnTile;

        if (tree == null)
            return false;
        else
            return true;
    }

    public void UpdateTile()
    {
        // Check for Objects.
        if (this.location.Objects.ContainsKey(this.tile))
            this.objectOnTile = this.location.Objects[this.tile];

        // Check for TerrainFeatures.
        if (this.location.terrainFeatures.ContainsKey(this.tile))
            this.terrainFeatureOnTile = this.location.terrainFeatures[this.tile];

        // Check for Crops.
        if (this.terrainFeatureOnTile is HoeDirt hoeDirt)
        {
            if (hoeDirt.crop != null)
                this.cropOnTile = hoeDirt.crop;
        } // Check for Trees.
        else if (this.terrainFeatureOnTile is Tree tree)
        {
            this.treeOnTile = tree;
        } // And check for FruitTrees.
        else if (this.terrainFeatureOnTile is FruitTree fruitTree)
        {
            this.fruitTreeOnTile = fruitTree;
        }

        // Check for Furniture.
        this.furnitureOnTile = this.location.GetFurnitureAt(this.tile) ?? null;
    }
}
