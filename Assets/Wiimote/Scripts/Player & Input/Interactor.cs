using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter ( Collider other )
    {
        if ( other.gameObject.CompareTag( "Stove" ) )
        {
            Debug.Log( "stove touched" );
            gameManager.stoveInteractUI.SetActive( true );
        }
    }
    private void OnTriggerExit ( Collider other )
    {
        gameManager.stoveInteractUI.SetActive( false );
    }
}