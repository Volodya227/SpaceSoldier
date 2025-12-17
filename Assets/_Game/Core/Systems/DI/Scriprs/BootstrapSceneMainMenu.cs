using UnityEngine;
namespace Systems.DI
{
    public class BootstrapSceneMainMenu : MonoBehaviour
    {
        [SerializeField] private UI.MainMenu.Core.MainMenuSystem _mainMenuSystemPrefab;
        private UI.MainMenu.Core.MainMenuSystem _mainMenuSystem;
        [SerializeField] private UI.Settings.UISettingsSystem _settingsSystemPrefab;
        private UI.Settings.UISettingsSystem _settingsSystem = null;
        private UI.MainMenu.IMainMenuActions _menuActions;
        private void Awake()
        {
            _mainMenuSystem = Instantiate(_mainMenuSystemPrefab);
            _menuActions = _mainMenuSystem.GetEvents;
            _menuActions.EventOnClickPlay += Play;
            _menuActions.EventOnClickQuit += Quit;
            _menuActions.EventOnClickSettings += OpenSettings;
        }
        private void OnDestroy()
        {
            _menuActions.EventOnClickPlay -= Play;
            _menuActions.EventOnClickQuit -= Quit;
            _menuActions.EventOnClickSettings -= OpenSettings;
            if (_settingsSystem != null)
            {
                _settingsSystem.EventDisable -= OpenMainMenu;
            }
        }
        private void Play()
        {
            if (ServiceEntryPointReadonly.GlobalContainerSystems == null) return;
            ServiceEntryPointReadonly.GlobalContainerSystems.BootstrapEvents.ActivateEventLoadScene(2);
        }
        private void OpenSettings()
        {
            if (_settingsSystem == null)
            {
                _settingsSystem = Instantiate(_settingsSystemPrefab);
                if (ServiceEntryPointReadonly.GlobalContainerSystems != null)
                {
                    _settingsSystem.SetData(ServiceEntryPointReadonly.GlobalContainerSystems.ApplicationData);
                }
                _settingsSystem.Init();
                _settingsSystem.EventDisable += OpenMainMenu;

            }
            _settingsSystem.Open();
        }
        private void OpenMainMenu()
        {
            _mainMenuSystem.OpenMainMenu();
        }
        private void Quit()
        {
            if (ServiceEntryPointReadonly.GlobalContainerSystems == null)
            {
                Application.Quit();
                return;
            }
            ServiceEntryPointReadonly.GlobalContainerSystems.BootstrapEvents.ActivateEventQuitApplication();
        }
    }
}