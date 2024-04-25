namespace RPG_GameLogic.Helpers
{
    internal class EnemyGenerator
    {
        public EnemyGenerator() { }

        public string? GetEnemyName(int enemyPicker)
        {
            return enemyPicker switch
            {
                0 => "Slime",
                1 => "Goblin",
                2 => "Orc",
                3 => "Imp",
                4 => "Spider",
                _ => "Slime",
            };
        }

        public string? GetEnemyAction(int action) 
        {
            return action switch
            {
                0 => "bow",
                1 => "sword",
                2 => "shield",
                _ => "sword"
            };
        }
    }
}
