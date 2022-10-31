using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    public float speed = .5f; // rýchlosť pohybu
    Renderer rend; // renderer zabezpečujúci vykresľovanie textúry
    // Start is called before the first frame update
    void Start()
    {
    rend = GetComponent<Renderer>(); // získame prístup k rendereru
    }

    // Update is called once per frame
    void Update()
    {
    // veľkosť posunu je závislá od času a rýchlosti rolovania textúry
    float offset = Time.time * speed; 
    // nastavi sa posun materialu o zadany vektor (dvojrozmerny - vyska, sirka)
    // _MainTex - sposob posunutia textury, ktory "posuva obraz"
    rend.material.SetTextureOffset("_MainTex", new Vector2(0,offset));    
    }
}
