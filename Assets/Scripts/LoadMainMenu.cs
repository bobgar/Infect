using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour {

	public void LoadLevelSelect()
  {
      SceneManager.LoadScene("levelSelect");
  }
}
