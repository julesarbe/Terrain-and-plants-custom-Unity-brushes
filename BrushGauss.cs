using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BrushGauss : TerrainBrush {

    public float height = 1;
    public int radius = 100;
    private double H;

    private double dist;
    public override void draw(int x, int z) {
        for (int zi = -radius; zi <= radius; zi++) {
            for (int xi = -radius; xi <= radius; xi++) {
                float original_height = terrain.get(x+xi, z+zi);
                dist = Math.Pow(zi, 2) + Math.Pow(xi, 2);
                if(dist < Math.Pow(radius,2)){
                H = Math.Exp(-5*(Math.Pow(zi,2) + Math.Pow(xi,2))/Math.Pow(radius,2));
                terrain.set(x + xi, z + zi, 4*height *(float)H + original_height) ;}
            }
        }
    }
}
