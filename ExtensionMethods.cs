namespace ConsoleDraughts
{
    //
    // Summary:
    //     Contains all extensions methods for this program.
    static class ExtensionMethods
    {
        //
        // Summary:
        //     Count the numer of trues in a two dimensional array of bool.
        //
        // Parameters:
        //   array:
        //     The two dimensional array who contains all booleans.
        //
        // Returns:
        //     The quantity of trues in the array.
        public static int CountTrues(this bool[,] array)
        {
            int i = new int();
            foreach (var boolean in array)
            {
                if (boolean)
                {
                    i++;
                }
            }
            return i;
        }
    }
}
