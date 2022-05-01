namespace CommonServices
{
    public static class FilesManagementService
    {
        public static void CheckCreateDirectory(string newDirectory)
        {
            DirectoryInfo dirUpd = new DirectoryInfo(newDirectory);
            if (!dirUpd.Exists)
            {
                Console.WriteLine("Create Directory " + dirUpd);
                dirUpd.Create();
            }
            else { Console.WriteLine("Directory " + dirUpd + " already exist."); }
        }

        public static string GetCurrentDateTimeString()
        {
            return DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss");
        }
    }
}
