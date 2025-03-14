using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    public List<RoadBlockPiece> roadBlockPieces;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ratball")
        {
            for (int i = 0; i < roadBlockPieces.Count; i++) 
            {
                roadBlockPieces[i].Activate(other.gameObject.GetComponent<Rigidbody>().linearVelocity.magnitude);
            }

            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySound(SoundManager.SoundEffect.RoadBlockSound);
            }

            EndGameMenu.Instance.roadBlocksPoints += 10;
        }
    }
}
