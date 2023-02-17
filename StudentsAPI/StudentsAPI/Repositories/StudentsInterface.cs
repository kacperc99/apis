using StudentsAPI.Models;

namespace StudentsAPI.Repositories
{
    public class StudentsInterface
    {
        static List<Students> StudentsList { get; }
        static int nextId = 2;
        static StudentsInterface()
        {
            StudentsList = new List<Students>
            {
                new Students { Id=1, Name = "Mikołaj", Surname= "Kulanka", age = 21, data_urodzenia = new DateOnly(2000,6,9), obwod_bebzona_w_cm=666},
                new Students { Id=2, Name = "Kacper", Surname="Celary", age=22, data_urodzenia = new DateOnly(1999,9,21), obwod_bebzona_w_cm=6
                
                
                
                }
            };
        }
        public static List<Students> GetAll() => StudentsList;
        public static Students? Get(int id) => StudentsList.FirstOrDefault(p => p.Id ==id); 

        public static void add(Students students)
        {
            students.Id = nextId++;
            StudentsList.Add(students);
        }

        public static void Delete(int id)
        {
            var student = Get(id);
            if (student is null)
                return;

            StudentsList.Remove(student);
        }

        public static void Update(Students students)
        {
            var index = StudentsList.FindIndex(s => s.Id == students.Id);
            if (index == -1)
                return;
            StudentsList[index] = students;
        }







    }
}
