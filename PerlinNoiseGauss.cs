using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PerlinNoiseGauss : TerrainBrush
{

    public float height = 1;
    public new int radius = 20;
    private double H;
    public float xfloat;
    public float zfloat;

    private double dist;
    public override void draw(int x, int z)
    {
        for (int zi = -radius; zi <= radius; zi++)
        {
            for (int xi = -radius; xi <= radius; xi++)
            {
                float original_height = terrain.get(x + xi, z + zi);
                dist = Math.Pow(zi, 2) + Math.Pow(xi, 2);
                xfloat = (float)x + (xi + radius)/(float)(radius);
                zfloat = (float)z + (zi + radius)/ (float)(radius);
                float perlin = Mathf.PerlinNoise(xfloat, zfloat);
                if (dist < Math.Pow(radius, 2))
                {
                    H = Math.Exp(-5 * (Math.Pow(zi, 2) + Math.Pow(xi, 2)) / Math.Pow(radius, 2));
                    terrain.set(x + xi, z + zi, 10*perlin*height*(float)H + original_height);
                    //terrain.set(x + xi, z + zi, 20*perlin*height*(float)H + original_height);
                }
            }
        }
    }
}
