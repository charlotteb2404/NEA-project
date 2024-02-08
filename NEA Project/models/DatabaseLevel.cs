namespace NEA_Project.models
{
    public class DatabaseLevel
    {
        public int  id { get; set; }
        public int LevelNumber { get; set; }
        public string MapSource { get; set; }
        public int NumberOfPolice { get; set; }
        public int Difficulty { get; set; }
        public int NumberOfCoins { get; set; }
        public int NumberOfPoliceOfficers { get; set; }
        public int NumberOfPotions { get; set; }
        //getting and setting values from the database table
    }
}
