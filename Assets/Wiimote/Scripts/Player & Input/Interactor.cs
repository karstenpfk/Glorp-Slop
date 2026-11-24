using UnityEngine;

public class Interactor : MonoBehaviour
{
    GameManager gameManager;
    private void Start ()
    {
        FindFirstObjectByType<GameManager>();
    }
    private void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.CompareTag( "Stove" ) )
        {
            Debug.Log( "stove touched" );
            gameManager.stoveInteractUI.SetActive( true );
        }
    }
}