namespace StudentsAPI.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int age { get; set;}
        public int obwod_bebzona_w_cm { get; set; }
        public DateOnly data_urodzenia { get; set; }
    }
}
