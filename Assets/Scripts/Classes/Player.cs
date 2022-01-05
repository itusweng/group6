using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int _playerId;
    public string _playerName;
    public float _dollarAmount;
    public float _euroAmount;
    public float _liraAmount;
    public bool _hasGetOutOfJailFree;
    public int _position;  // My addition
    public int _isJailed = 0;
    public int targetZone;


    public List<Property> Properties { get; set; }



    public int PlayerId
    {
        get { return _playerId; }
        set 
        {
            if(value > 0 && value < 7)
            {
                _playerId = value;
            }
        }
    }


    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }


    public float DollarAmount
    {
        get { return _dollarAmount; }
        set
        {
            while(value < 0)
            {
                string selection = SelectIncomeMethod();
                switch (selection)
                {
                    case "Sell Property":
                        break;
                    case "Sell Building":
                        break;
                    case "Sell GOOTJF Card":
                        break;
                    case "Exchange Money":
                        break;
                    case "Mortgage":
                        break;
                    case "Declare Bankruptcy":
                        Bankruptcy();
                        return;
                }
            }
            _dollarAmount = value;
        }
    }


    public float EuroAmount
    {
        get { return _euroAmount; }
        set
        {
            if (value >= 0)
            {
                _euroAmount = value;
            }
        }
    }


    public float LiraAmount
    {
        get { return _liraAmount; }
        set
        {
            if (value >= 0)
            {
                _liraAmount = value;
            }
        }
    }


    public bool HasGetOutOfJailFree
    {
        get { return _hasGetOutOfJailFree; }
        set { _hasGetOutOfJailFree = value; }
    }


    public int Position
    {
        get { return _position; }
        set
        {
            if (_position > 0)
            {
                _position = value;
            }
        }
    }


    public int IsJailed
    {
        get { return _isJailed; }
        set { _isJailed = value; }
    }


    public int RollDice()
    {
        int roll = 0;
        // roll += dice1
        // roll += dice2
        return roll;
    }

    public void Move()
    {

    }

    public void UseJailFree()
    {
        if (HasGetOutOfJailFree && (IsJailed != 0))
        {
            // use
            HasGetOutOfJailFree = false;
        }
        else
        {
            // can't use
        }
    }

    public Card DrawCardChance()
    {
        Card cardDrawn = null;
        return cardDrawn;
    }

    public Card DrawCardCommunityChest()
    {
        Card cardDrawn = null;
        return cardDrawn;
    }

    public void PayRent()
    {

    }

    public void BuyProperty(ref Property property)
    {

    }

    public void SellProperty(ref Property property, ref Player player)
    {

    }

    public void BuildHouse(ref Property property)   // or can pass in an int which specifies a property in Properties List
    {

    }

    public void BuildHotel(ref Property property)   // or can pass in an int which specifies a property in Properties List
    {

    }

    public void Mortgage(ref Property property)   // or can pass in an int which specifies a property in Properties List
    {

    }

    public void GoToJail()
    {

    }

    public string SelectIncomeMethod()
    {
        return null;
    }

    public void Bankruptcy()    // Game over for this player
    {

    }

    public bool JoinLobby(int LobbyId)  // void on class diagrams
    {
        return true;
    }

    public bool CreateLobby()   // void on class diagrams
    {
        return true;
    }
}
