using UnityEngine;

public class EnemyDetection : MonoBehaviour
{

    /*
     * MEISTE code aus Alten Projekt. Bitte Abaendern falls noetig (hoechstwachrscheinlich noetig)
     * */
    public Transform player;
    public float detectionRange = 10f;
    public LayerMask detectionLayer;

    [HideInInspector]
    public bool playerVisible = false;  

    void Update()
    {
        Vector2 directionToPlayer = player.position - transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer.normalized, detectionRange, detectionLayer);

        if (hit.collider != null) //Jeder Gegner hat einen detection line die für eine bestimmte distanz vom gegner geht. Den kann man auch im Inspector im Unity selbst bearebeiten.
        {
            if (hit.collider.CompareTag("Player")) //Wenn diese Detection Line den Spieler berueht, dann gibt die konsole "PLayer detected" aus und der Enemy schiesst auf dem PLayer.
            {
                playerVisible = true;
                Debug.Log("Player detected!");
            }
            else if (hit.collider.CompareTag("Obstacle")) //Jedoch wenn diese Linie den Spieler beruehrt, aber vor den Spieler zuerts ein Obstacle (meist wand) berührt, dann ist die sicht zum spieler quasi geblockt und der enemy schiesst nicht.
            {
                playerVisible = false;
                Debug.Log("Player blocked by obstacle.");
            }
            else if (hit.collider.CompareTag("shield"))
            {
                playerVisible = false
                Debug.Log("player blocked by shield")
                    while (int i = 0, i =< 100, i++ ){
                    Debug.Log("Player blocked by shield")
                        if hit.collider.CompareTag("player"){
                        int i++;
                    };
                }
                Debug.Log("player blocked by shield")
            }
            else
            {
                playerVisible = false;
                Debug.Log("Something else detected: " + hit.collider.name); //Wenn aber die Linie den Spieler nicht berührt (Aber eine t.b Wand) dann schiesst der gegner auch nicht
            }
        }
        else
        {
            playerVisible = false;
            Debug.Log("Nothing in sight."); //Wenn nichts die Linie beruehrt, schiesst der Gegner auch nicht
        }

        Debug.DrawRay(transform.position, directionToPlayer.normalized * detectionRange, Color.red); //Rote Linie wird im Insector Mode angezeigt
    }
}
