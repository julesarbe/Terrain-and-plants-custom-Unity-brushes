using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class RisiereBrush : TerrainBrush {

    public int risiere_height = 10;
    public float offset = 0;
    public int radius = 20;

    private double dist;
    public override void draw(int x, int z) {
        for (int zi = -radius; zi <= radius; zi++) {
            for (int xi = -radius; xi <= radius; xi++) {
                float original_height = terrain.get(x+xi, z+zi);
                dist = Math.Pow(zi, 2) + Math.Pow(xi, 2);
                if(dist < Math.Pow(radius,2)){
                    float factor = (float) Math.Exp(-5*(Math.Pow(zi,2) + Math.Pow(xi,2))/Math.Pow(radius,2));
                    int new_height = (int) original_height/risiere_height;
                    terrain.set(x + xi, z + zi, original_height + factor*(new_Height(original_height, risiere_height, offset)-original_height)) ;}
            }
        }
    }

    public float new_Height(float original_height, float risiere_height, float offset) {
        float new_height = offset + risiere_height * (int) (original_height/risiere_height);
        return new_height;
    }
}
