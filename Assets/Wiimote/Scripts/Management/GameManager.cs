using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> burgerIngredients;
    public GameObject stoveInteractUI;
    private void Start ()
    {
        stoveInteractUI.SetActive( false );
    }
}
