using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridBrush2 : InstanceBrush
{
    public int spacing = 20;
    public new int radius = 20;
    public int idx = 0; 
    private TreeInstance[] trees;
    private float terrainHeight;
    private float terrainWidth;
    private bool isOccupied;
    
    public override void draw(float x, float z) {
        int test_x;
        int test_z;
        float test_radius;
        trees = terrain.terrain_data.treeInstances;
        terrainWidth = terrain.terrain_data.heightmapResolution;
        terrainHeight = terrain.terrain_data.heightmapResolution;
        
        for (int zi = -radius; zi <= radius; zi++) {
            for (int xi = -radius; xi <= radius; xi++) {
                test_x = (int) x + xi;
                test_z = (int) z + zi;
                isOccupied = false;
                test_radius = spacing/3;

                if (test_x % spacing == 0) {
                    if (test_z % spacing == 0){
                        for (int i=0; i<trees.Length; i++){
                            if ((Math.Abs(trees[i].position.x * terrainWidth - (x+xi)) < test_radius) & (Math.Abs(trees[i].position.z * terrainHeight - (z+zi)) < test_radius)){
                                isOccupied = true;
                            }
                        }
                        if (!isOccupied){
                            mySpawnObject(x+xi, z+zi, 3f, idx);
                        }
                    }
                }
            }
        }
    }
}



