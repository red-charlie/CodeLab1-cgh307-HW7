using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DirectionManager : MonoBehaviour
{

    public Text locationTitle; //the ui object that is the location title
    public Text description;  //the Description of the current slide/page

    //the same as matt's
    public Button nButton;  //north 
    public Button sButton;  //south
    public Button eButton;  //east
    public Button wButton;  //west

    //turning buttons
    public Button rightButton; //turn right
    public Button leftButton; // turn left

    //CompassLogic 
    public Image compass;//the image file for the compass

    public string[] compassDir; //the array of the cardinal directions

    public int numLocations; //number of locations

    public int currentFacing; //keeping track of the current facing

    public string facingDescription;

    public Location currentLocation; //the current location that you are in

    public Location[] locations; //array of all the locations

    string filePath = "/Files/Location<num>.json"; //default path to location files

   
    void Start()
    {
        filePath = Application.dataPath + filePath; //full path to the location files

        //the amounts of cardinal directions
        compassDir = new string[4];
        compassDir[0] = "n";
        compassDir[1] = "e";
        compassDir[2] = "s";
        compassDir[3] = "w";

        currentFacing = 0;//face north
        

        //the amount of locations in the location array
        locations = new Location[numLocations];

        for (int i = 0; i < locations.Length; i++) //for loop to go through each one
        {
            string locPath = filePath.Replace("<num>", "" + i); //replace <num> with the current i value and create that path string

            string fileContent = File.ReadAllText(locPath); //read that file
            Location l = JsonUtility.FromJson<Location>(fileContent);  // make that the location 

            locations[i] = l; //that is now i
        }
        
       

        UpdateLocation(0); // update the location
    }

    public void GoNorth()
    {
        UpdateLocation(currentLocation.nLocation);
    }

    public void GoSouth()
    {
        UpdateLocation(currentLocation.sLocation);
    }

    public void GoEast()
    {
        UpdateLocation(currentLocation.eLocation);
    }

    public void GoWest()
    {
        UpdateLocation(currentLocation.wLocation);
    }

    public void TurnRight()//turning everything to the right
    {
        compass.transform.Rotate(0, 0, 90);//turn the image right
        UpdateRotation(1);//send over the turn amount to the array of cardinals
    }

    public void TurnLeft()//turn everything to the left now y'all
    {
        compass.transform.Rotate(0, 0, -90);//turn the image left
        UpdateRotation(-1); //send over the turn amount
    }

    public void UpdateRotation(int turnAmt)
    {
        currentFacing = currentFacing + turnAmt;//add that to the current int
        if (currentFacing < 0)
        {
            currentFacing = 3;

        }
        else if (currentFacing > 3) //keep it in the array list
        {
            currentFacing = 0;
        }
        //change description depending on which facing we're using
        if (compassDir[currentFacing] == "n")
        {
            facingDescription = currentLocation.nDescription;
        }
        else if (compassDir[currentFacing] == "e")
        {
            facingDescription = currentLocation.eDescription;
        }
        else if (compassDir[currentFacing]== "s")
        {
            facingDescription = currentLocation.sDescription;
        }
        else if (compassDir[currentFacing] == "w")
        {
            facingDescription = currentLocation.wDescription;
        }
        facingDescription = facingDescription.Replace("<nline>", "\n") ; //replace <nline> with a new line because I was having string issues
        description.text = facingDescription;
    }
    public void UpdateLocation(int locNum)
    {
        if (locNum == 9)
        {
            GameManager.instance.powerOn();
        }

        if(locNum == 7)
        {
            GameManager.instance.keyGet();
        }

       currentLocation = locations[locNum];

        locationTitle.text = currentLocation.locationTitle;

        UpdateRotation(0);
        if (locNum == 8 && GameManager.instance.key == false) //make sure the key bool is working
        {
            currentLocation.wLocation = -1;
        }
        else if (locNum == 8 && GameManager.instance.key == true)
        {
            currentLocation.wLocation = 9;
        }

        if (locNum == 5 && GameManager.instance.power == false && currentFacing == 0) //make sure the power bool is working
        {

            facingDescription = "You stand inside the elevator facing north. The back wall seems to be made of black stone but you can't be sure, there are no lights. There is a small lever at waist height. [You cannot pull the lever without first turning on the power]";
            currentLocation.nLocation = -1;
        }
        else if (locNum == 5 && GameManager.instance.power == true && currentFacing == 0)
        {
            currentLocation.nLocation = 10;
            facingDescription = currentLocation.nDescription;
        }

      
        facingDescription = facingDescription.Replace("<nline>", "\n"); //replace <nline> with a new line because I was having string issues
        description.text = facingDescription;
       
        if (currentLocation.nLocation < 0)
        {
            nButton.gameObject.SetActive(false);
        }
        else
        {
            nButton.gameObject.SetActive(true);
        }

        if (currentLocation.sLocation < 0)
        {
            sButton.gameObject.SetActive(false);
        }
        else
        {
            sButton.gameObject.SetActive(true);
        }

        if (currentLocation.eLocation < 0)
        {
            eButton.gameObject.SetActive(false);
        }
        else
        {
            eButton.gameObject.SetActive(true);
        }

        if (currentLocation.wLocation < 0)
        {
            wButton.gameObject.SetActive(false);
        }
        else
        {
            wButton.gameObject.SetActive(true);
        }


    }
}
