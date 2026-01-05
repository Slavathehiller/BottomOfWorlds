using System.Reflection;

namespace Assets.Scripts.PlayerStorage
{
    public class PlayerResources
    {
        public int Gold {  get; set; }
        public int Wood {  get; set; }
        public int Stone {  get; set; }
        public int IronOre {  get; set; }
        public int Coal { get; set; }

        public static PlayerResources operator +(PlayerResources resources1, PlayerResources resources2)
        {
            PlayerResources result = new PlayerResources();
            PropertyInfo[] properties = typeof(PlayerResources).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(int))
                {
                    int value1 = (int)property.GetValue(resources1);
                    int value2 = (int)property.GetValue(resources2);

                    property.SetValue(result, value1 + value2);

                }
            }

            return result;
        }

        public static PlayerResources operator -(PlayerResources resources1, PlayerResources resources2)
        {
            PlayerResources result = new PlayerResources();
            PropertyInfo[] properties = typeof(PlayerResources).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(int))
                {
                    int value1 = (int)property.GetValue(resources1);
                    int value2 = (int)property.GetValue(resources2);

                    property.SetValue(result, value1 - value2);
                }
            }

            return result;
        }

        public bool IsEnought(PlayerResources resources)
        {
            PropertyInfo[] properties = typeof(PlayerResources).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == typeof(int))
                {
                    int ourResource = (int)property.GetValue(this);
                    int demandResource = (int)property.GetValue(resources);

                    if (ourResource < demandResource)
                        return false;
                }
            }
            return true;
        }
    }
}
