using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationProperty : Property
{

    public int SetNumber
    {
        get
        {
            return 1; // implement
        }
    }

    public override float GetRentAmount()
    {
        return RentAmount[SetNumber];
    }

    StationProperty()
    {
        _rentAmount = new float[4];
    }

}
