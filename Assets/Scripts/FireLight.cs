using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    public float lightRadius;
    public float fireStrength;
    public float strengthDecayRate;
    public float strengthGrowRate;
    public float radiusGrowRate;
    public float radiusDecayRate;
    public bool isLit;
    // Start is called before the first frame update
    void Start()
    {
        isLit = true;
        lightRadius = 10;
        fireStrength = 4;
    }

    private void Update()
    {
        AstarPath.active.Scan();
        GetComponent<Light>().range = lightRadius;
        GetComponent<Light>().intensity = fireStrength;
        GetComponent<CircleCollider2D>().radius = GetComponent<Light>().range/2;
        if (fireStrength <= 0.5)
        {
            fireStrength = 0;
            lightRadius = 0;
            isLit = false;
        }
    }

    public void Shrink()
    {
        lightRadius -= radiusDecayRate;
        if(fireStrength > 0.2)
            fireStrength -= strengthDecayRate;
    }

    public void Grow()
    {
        if(lightRadius < 15)
            lightRadius += radiusGrowRate;
        if(fireStrength < 4)
            fireStrength += strengthGrowRate;
    }
}
