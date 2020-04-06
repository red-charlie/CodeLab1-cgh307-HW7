using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location //forgot about that mono behavoir thing
{
    public string locationTitle;   //the place you currently ar
    public string nDescription;  //var for north description
    public string sDescription; // var for south description
    public string eDescription; // car for east description
    public string wDescription; // var for the west description

    public int nLocation = -1; //the location of the current location
    public int sLocation = -1;
    public int eLocation = -1;
    public int wLocation = -1;


    //Constructor for title description, direction, and location vars
    public Location(string placeTitle, string NorthDescription, string SouthDescription, string EastDescription, string WestDescription,
                     int n, int s, int e, int w)
    {
        this.locationTitle = placeTitle; //setting the parameter for this particular version of Location
        this.nDescription = NorthDescription;
        this.sDescription = SouthDescription;
        this.eDescription = EastDescription;
        this.wDescription = WestDescription;

        nLocation = n;
        sLocation = s;
        eLocation = e;
        wLocation = w;


    }
}

    
