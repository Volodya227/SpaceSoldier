Space Soldier — FPS Prototype (Unity)
Прототип шутера для дослідження модульної архітектури ігрових систем на Unity.
Гравець керує персонажем від першої або третьої особи з можливістю перемикання між кількома персонажами в сцені.
Інпут повністю абстрагований — підтримуються Legacy Input, New Input System та Mobile UI joystick без змін в ігровій логіці.
Зброя реалізована як MVP з raycast стрільбою, перезарядкою та muzzle flash. Архітектура побудована на Bootstrap-контейнері та event-driven ContainerData для UI.

Архітектура
Bootstrap

Двошаровий контейнер без зовнішніх DI-фреймворків.
Bootstrap — синглтон що живе між сценами та зберігає глобальні системи.
BootstrapScene — локальний контейнер який ініціалізує системи конкретної сцени та отримує глобальні через ServiceEntryPointReadonly.

Input Layer

PlayerInput — абстрактний клас з трьома незалежними каналами: CharacterInput, WeaponInput, CameraViewInput.
PlayerInputOld (Legacy) та PlayerInputNew (New Input System) перемикаються без змін в ігровій логіці.
Mobile UI joystick передає дані в той самий CharacterInput.

Character

CharacterController — чиста C# логіка з CharacterMovement, CharacterRotation та CharacterAnimator.
CharacterControllerBehaviour — MonoBehaviour адаптер що реалізує ITakeDamageable.

UI

Головне меню, екран завантаження з прогрес-баром, геймплейний HUD — здоров'я, патрони, перезарядка.
Налаштування графіки (роздільна здатність, якість, fps) зберігаються між сесіями через Save систему.
UI підписується на події ContainerData і не залежить від ігрової логіки напряму.

Save

ISaveProvider абстракція з JSON реалізацією. Зберігає налаштування застосунку між сесіями.
Технології
Unity, C#
