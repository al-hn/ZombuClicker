
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 0;                       // Можно задать полям значения по умолчанию
        public bool baseShieldIsOwned = false;
        public bool healIsOwned = false;
        public bool fireAspectIsOwned = false;
        public bool autoclickerIsOwned = false;
        public bool damageDoublerIsOwned = false;
        public bool damageAdderIsOwned = false;
        public bool vampirismIsOwned = false;
        public int defaultZombuHealth = 100;
        public int MinCoin = 2;
        public int MaxCoin = 7;
        public int zwaHealth = 200;
        public int sZombie = 150;
        public int jnbHealth = 10000;
        public int jnzwaHealth = 500;
        public int jnszHealth = 600;
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
