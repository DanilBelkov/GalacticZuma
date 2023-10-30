using Dreamteck.Splines;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsInit : MonoBehaviour
{
    public List<GameObject> PlanetTypes;
    public int PlanetCount;
    public Transform ParentPlanets;
    public SplineComputer Spline;
    void Start()
    {
        if (PlanetTypes == null) PlanetTypes = new List<GameObject>();
        InitializePlanet();
    }

    public void InitializePlanet()
    {
        if (PlanetTypes == null) return;
        if (ParentPlanets.childCount >= PlanetCount) return;
        var selectType = PlanetTypes[Random.Range(0, PlanetTypes.Count)];
        var newObject = Instantiate(selectType, Vector3.zero, selectType.transform.rotation);
        newObject.name = $"p_";
        newObject.transform.parent = ParentPlanets;
        var sf = newObject.GetComponent<SplineFollower>();
        sf.spline = Spline;
        sf.enabled = true;
    }
}
