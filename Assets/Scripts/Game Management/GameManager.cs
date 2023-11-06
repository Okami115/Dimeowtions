using Menu;
using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public enum Aesthetic
    {
        Noir,
        Synthwave,
        Scifi,
        end
    }

    public class GameManager : MonoBehaviour
    {
        [SerializeField] public PlayerStats playerStats;

        [SerializeField] private PauseState pauseScript;
        [SerializeField] public UIManager uiManager;
        [SerializeField] private GameObject pauseManager;

        [SerializeField] private StateMachine stateMachine;

        public event Action nextLevel;

        private bool inTutorial;
        public bool InTutorial { get => inTutorial; set => inTutorial = value; }

        private Aesthetic currentAesthetic;
        internal Aesthetic CurrentAesthetic { get => currentAesthetic; set => currentAesthetic = value; }

        private void Start()
        {
            playerStats.collectedObjects = 0;

            stateMachine = new StateMachine();
            stateMachine.AddState<TutorialState>(new TutorialState(stateMachine, this, 5000));
            stateMachine.AddState<NoirState>(new NoirState(stateMachine, this, 5000));
            stateMachine.AddState<SynthwaveState>(new SynthwaveState(stateMachine, this, 10000));
            stateMachine.AddState<SciFiState>(new SciFiState(stateMachine, this, 15000));

            stateMachine.ChangeState<TutorialState>();
            stateMachine.onTransition += HandleTransition;
        }

        private void HandleTransition(Aesthetic nextAesthetic)
        {

            Color color = new Color(1, 1, 1, 1);
            uiManager.portalImage.enabled = true;
            uiManager.portalImage.color = color;
            uiManager.portal.Play();
        }
        private void Update()
        {
            stateMachine.Update();
        }

        public void ReloadScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(currentSceneIndex);
        }

        public void CallNextLevel()
        {
            nextLevel.Invoke();
        }

    }
}