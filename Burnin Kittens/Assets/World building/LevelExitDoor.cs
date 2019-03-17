using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExitDoor : MonoBehaviour, IInteractible {
    public void AcceptBob(Bob source)
    {
        SceneManager.LoadScene("WonGame");
    }
}
