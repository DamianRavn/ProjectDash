using UnityEngine;

public class PauseMenu : UIBase
{
    [SerializeField]
    private GameObject pauseMenuUI;

    public override void Resume()
    {
        base.Resume();
        pauseMenuUI.SetActive(false);
    }

    public override void Pause()
    {
        base.Pause();
        pauseMenuUI.SetActive(true);
    }
}
