using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class VegetationBrush : InstanceBrush {

    public int density = 1;
    public new float radius = 20;
    public int idx = 0; 
    public float height;
    public float fscale;
    public float degrees = 60f;
    private Vector3 normal;
    private Vector3 vertical = new Vector3(0, 90, 0);

    Random r = new Random();

    public override void draw(float x, float z) {

        for (int i = 1; i <= density; i++) {
            int rxInt = r.Next(0, 100);
            int rzInt = r.Next(0, 100);
            float xi = x+radius*((float)rxInt/50 - 1);
            float zi = z+radius*((float)rzInt/50 - 1);
            height = terrain.get((int) xi, (int) zi);
            if (height < 25){
                fscale = 0.5f;
                idx = 0;
            }
            if (25 <= height){
                fscale =(float) (-height/150 + 0.8);
                idx = 1;
            }

            if (height < 100) {
                normal = terrain.getNormal(xi, zi);
                if (Vector3.Angle(normal, vertical) < degrees)
                {
                    mySpawnObject(xi, zi, fscale, idx);
                }
            }
        }
    }
}
