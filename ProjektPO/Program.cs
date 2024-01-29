using ProjektPO;

class Program
{
    static void Main(string[] args)
    {
        Database database = new Database();
        database.LoadStudentsFromJson("Studenci.json");
        database.LoadTeachersFromJson("Nauczyciele.json");
        database.LoadSubjectsFromJson("Przedmioty.json");
        database.LoadGradesFromJson("Oceny.json");
        database.LoadStudentCouncilMembersFromJson("Samorzad.json");
        database.LoadParentsFromJson("Rodzice.json");


        while (true)
        {
            Console.WriteLine("Wybierz operację:");
            Console.WriteLine("1. Wyświetl wszystkich uczniów");
            Console.WriteLine("2. Wyświetl wszystkich nauczycieli");
            Console.WriteLine("3. Wyświetl wszystkie przedmioty");
            Console.WriteLine("4. Wyświetl oceny danego studenta");
            Console.WriteLine("5. Dodaj ocenę");
            Console.WriteLine("6. Dodaj ucznia");
            Console.WriteLine("7. Dodaj nauczyciela");
            Console.WriteLine("8. Dodaj przedmiot");
            Console.WriteLine("9. Usuń ocenę");
            Console.WriteLine("10. Usuń ucznia");
            Console.WriteLine("11. Usuń nauczyciela");
            Console.WriteLine("12. Usuń przedmiot");
            Console.WriteLine("13. Aktualizuj dane ucznia");
            Console.WriteLine("14. Aktualizuj dane nauczyciela");
            Console.WriteLine("15. Aktualizuj przedmiot");
            Console.WriteLine("16. Aktualizuj ocenę");
            Console.WriteLine("17. Oblicz ocenę końcową ucznia");
            Console.WriteLine("18. Wyświetl członków samorządu");
            Console.WriteLine("19. Dodaj członka samorządu");
            Console.WriteLine("20. Usuń członka samorządu");
            Console.WriteLine("21. Aktualizuj członka samorządu");
            Console.WriteLine("22. Wyświetl rodziców danego studenta");
            Console.WriteLine("23. Dodaj rodzica");
            Console.WriteLine("24. Usuń rodzica");
            Console.WriteLine("25. Aktualizuj rodzica");
            Console.WriteLine("26. Wyjdź z aplikacji");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayStudents(database);
                    break;
                case "2":
                    DisplayTeachers(database);
                    break;
                case "3":
                    DisplaySubjects(database);
                    break;
                case "4":
                    DisplayStudentGrades(database);
                    break;
                case "5":
                    AddGrade(database);
                    break;
                case "6":
                    AddStudent(database);
                    break;
                case "7":
                    AddTeacher(database);
                    break;
                case "8":
                    AddSubject(database);
                    break;
                case "9":
                    RemoveGrade(database);
                    break;
                case "10":
                    RemoveStudent(database);
                    break;
                case "11":
                    RemoveTeacher(database);
                    break;
                case "12":
                    RemoveSubject(database);
                    break;
                case "13":
                    UpdateStudent(database);
                    break;
                case "14":
                    UpdateTeacher(database);
                    break;
                case "15":
                    UpdateSubject(database);
                    break;
                case "16":
                    UpdateGrade(database);
                    break;
                case "17":
                    CalculateFinalGrade(database);
                    break;
                case "18":
                    DisplayStudentCouncilMembers(database);
                    break;
                case "19":
                    AddStudentCouncilMember(database);
                    break;
                case "20":
                    RemoveStudentCouncilMember(database);
                    break;
                case "21":
                    UpdateStudentCouncilRole(database);
                    break;
                case "22":
                    DisplayStudentParents(database);
                    break;
                case "23":
                    AddParentForStudent(database);
                    break;
                case "24":
                    RemoveParent(database);
                    break;
                case "25":
                    UpdateParent(database);
                    break;
                case "26":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór.");
                    break;
            }
        }
    }

    static void DisplayStudents(Database database)
    {
        Console.WriteLine("Uczniowie:");
        List<Student> students = database.GetStudents();
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.IdP}, FirstName: {student.FirstName}, LastName: {student.LastName}, Numer albumu: {student.StudentId}");
        }
    }

    static void DisplayTeachers(Database database)
    {
        Console.WriteLine("Nauczyciele:");
        List<Teacher> teachers = database.GetTeachers();
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"ID: {teacher.IdP}, FirstName: {teacher.FirstName}, LastName: {teacher.LastName}, Numer nauczyciela: {teacher.TeacherId}");
        }
    }

    static void DisplaySubjects(Database database)
    {
        Console.WriteLine("Przedmioty:");
        List<Subject> subjects = database.GetSubjects();
        foreach (var subject in subjects)
        {
            Console.WriteLine($"ID: {subject.Id}, Name: {subject.Name}");
        }
    }

    static void DisplayStudentGrades(Database database)
    {
        Console.WriteLine("Podaj numer albumu studenta:");
        int studentId = int.Parse(Console.ReadLine());

        List<Grade> studentGrades = database.GetStudentGrades(studentId);
        if (studentGrades.Count > 0)
        {
            Console.WriteLine($"Oceny studenta o numerze albumu {studentId}:");
            foreach (var grade in studentGrades)
            {
                Console.WriteLine($"Subject ID: {grade.SubjectId}, ID oceny: {grade.Id}, Value: {grade.Value}");
            }
        }
        else
        {
            Console.WriteLine($"Brak ocen dla studenta o ID {studentId}.");
        }
    }

    static void DisplayStudentParents(Database database)
    {
        Console.WriteLine("Podaj ID studenta:");
        int studentId = int.Parse(Console.ReadLine());

        database.DisplayStudentParents(studentId);
    }

    static void AddParentForStudent(Database database)
    {
        Console.WriteLine("Podaj ID studenta:");
        int studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj imię rodzica:");
        string parentFirstName = Console.ReadLine();

        Console.WriteLine("Podaj nazwisko rodzica:");
        string parentLastName = Console.ReadLine();

        Console.WriteLine("Podaj numer telefonu rodzica:");
        string parentPhoneNumber = Console.ReadLine();

        Console.WriteLine("Podaj rolę rodzica (Matka/Ojciec):");
        string parentRole = Console.ReadLine();

        Console.WriteLine("Podaj ID rodzica");
        int IDP = int.Parse(Console.ReadLine());

        Parents parent = new Parents
        {
            IdP = IDP,
            FirstName = parentFirstName,
            LastName = parentLastName,
            PhoneNumber = parentPhoneNumber,
            Role = parentRole,
            KidID = studentId
        };

        database.AddParentForStudent(studentId, parent);
    }

    static void RemoveParent(Database database)
    {
        Console.WriteLine("Podaj ID rodzica:");
        int IdP = int.Parse(Console.ReadLine());

        database.RemoveParent(IdP);
    }


    static void UpdateParent(Database database)
    {
        Console.WriteLine("Podaj ID rodzica do zaktualizowania:");
        int parentId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nowe imię rodzica:");
        string parentFirstName = Console.ReadLine();

        Console.WriteLine("Podaj nowe nazwisko rodzica:");
        string parentLastName = Console.ReadLine();

        Console.WriteLine("Podaj nowy numer telefonu rodzica:");
        string parentPhoneNumber = Console.ReadLine();

        Console.WriteLine("Podaj nową rolę rodzica (Matka/Ojciec):");
        string parentRole = Console.ReadLine();

        Parents parent = new Parents
        {
            IdP = parentId,
            FirstName = parentFirstName,
            LastName = parentLastName,
            PhoneNumber = parentPhoneNumber,
            Role = parentRole
        };

        database.UpdateParent(parent);
    }


    static void AddGrade(Database database)
    {
        Console.WriteLine("Podaj numer albumu studenta:");
        int studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj ID przedmiotu:");
        int subjectId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj ID oceny:");
        int Id = int.Parse(Console.ReadLine());


        Console.WriteLine("Podaj nazwę przedmiotu:");
        string name = Console.ReadLine();

        Console.WriteLine("Podaj ocenę:");
        double value = double.Parse(Console.ReadLine());

        database.AddGrade(new Grade { StudentId = studentId, SubjectId = subjectId, Value = value, Id=Id });
        Console.WriteLine("Dodano ocenę.");
    }

    static void AddStudent(Database database)
    {
        Console.WriteLine("Podaj id ucznia:");
        int Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj imię ucznia:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Podaj nazwisko ucznia:");
        string lastName = Console.ReadLine();

        Console.WriteLine("Podaj numer albumu ucznia:");
        int album = int.Parse(Console.ReadLine());

        database.AddStudent(new Student {IdP = Id, FirstName = firstName, LastName = lastName, StudentId = album});
        Console.WriteLine("Dodano ucznia.");
    }

    static void AddTeacher(Database database)
    {
        Console.WriteLine("Podaj id nauczyciela:");
        int Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj imię nauczyciela:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Podaj nazwisko nauczyciela:");
        string lastName = Console.ReadLine();

        Console.WriteLine("Podaj numer nauczyciela:");
        int numer = int.Parse(Console.ReadLine());

        database.AddTeacher(new Teacher {IdP = Id,  FirstName = firstName, LastName = lastName, TeacherId = numer });
        Console.WriteLine("Dodano nauczyciela.");
    }

    static void RemoveGrade(Database database)
    {
        Console.WriteLine("Podaj numer oceny:");
        int Gradeid = int.Parse(Console.ReadLine());

        database.RemoveGrade(Gradeid);
        Console.WriteLine("Usunięto ocenę");
    }

    static void RemoveStudent(Database database)
    {
        Console.WriteLine("Podaj ID ucznia:");
        int studentId = int.Parse(Console.ReadLine());

        database.RemoveStudent(studentId);
        Console.WriteLine("Usunięto ucznia.");
    }

    static void RemoveTeacher(Database database)
    {
        Console.WriteLine("Podaj ID nauczyciela:");
        int teacherId = int.Parse(Console.ReadLine());

        database.RemoveTeacher(teacherId);
        Console.WriteLine("Usunięto nauczyciela.");
    }

    static void CalculateFinalGrade(Database database)
    {
        Console.WriteLine("Podaj numer ucznia:");
        int studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj numer przedmiotu:");
        int subjectId = int.Parse(Console.ReadLine());

        double finalGrade = database.CalculateFinalGrade(studentId, subjectId);
        Console.WriteLine($"Ocena końcowa ucznia o numerze {studentId} w przedmiocie o numerze {subjectId} wynosi: {finalGrade}");
    }

    static void AddSubject(Database database)
    {
        Console.WriteLine("Podaj ID przedmiotu:");
        int subjectId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nazwę przedmiotu:");
        string subjectName = Console.ReadLine();

        database.AddSubject(new Subject { Id = subjectId, Name = subjectName });

        Console.WriteLine("Przedmiot został dodany.");
    }


    static void RemoveSubject(Database database)
    {
        Console.WriteLine("Podaj ID przedmiotu do usunięcia:");
        int subjectId = int.Parse(Console.ReadLine());

        database.RemoveSubject(subjectId);

        Console.WriteLine("Przedmiot został usunięty.");
    }

    static void UpdateStudent(Database database)
    {
        Console.WriteLine("Podaj numer albumu ucznia do zaktualizowania:");
        int studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nowe imię ucznia:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Podaj nowe nazwisko ucznia:");
        string lastName = Console.ReadLine();

        Student updatedStudent = new Student { StudentId = studentId, FirstName = firstName, LastName = lastName };

        database.UpdateStudent(updatedStudent);
    }

    static void UpdateTeacher(Database database)
    {
        Console.WriteLine("Podaj ID nauczyciela do zaktualizowania:");
        int teacherId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nowe imię nauczyciela:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Podaj nowe nazwisko nauczyciela:");
        string lastName = Console.ReadLine();

        Teacher updatedTeacher = new Teacher { TeacherId = teacherId, FirstName = firstName, LastName = lastName };

        database.UpdateTeacher(updatedTeacher);
    }

    static void UpdateSubject(Database database)
    {
        Console.WriteLine("Podaj ID przedmiotu do aktualizacji:");
        int subjectId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nową nazwę przedmiotu:");
        string newName = Console.ReadLine();

        Subject updatedSubject = new Subject { Id = subjectId, Name = newName };

        database.UpdateSubject(updatedSubject);
    }
    static void UpdateGrade(Database database)
    {
        Console.WriteLine("Podaj ID oceny do aktualizacji:");
        int gradeId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nowe ID studenta:");
        int studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nowe ID przedmiotu:");
        int subjectId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nową wartość oceny:");
        double value = double.Parse(Console.ReadLine());

        Grade updatedGrade = new Grade
        {
            Id = gradeId,
            StudentId = studentId,
            SubjectId = subjectId,
            Value = value
        };

        database.UpdateGrade(updatedGrade);
    }

    static void AddStudentCouncilMember(Database database)
    {
        Console.WriteLine("Podaj ID studenta:");
        int studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj imię:");
        string firstName = Console.ReadLine();

        Console.WriteLine("Podaj nazwisko:");
        string lastName = Console.ReadLine();

        Console.WriteLine("Podaj rolę:");
        string role = Console.ReadLine();

        database.AddStudentCouncilMember(studentId, firstName, lastName, role);
    }


    static void DisplayStudentCouncilMembers(Database database)
    {
        List<StudentCouncil> studentCouncilMembers = database.GetStudentCouncilMembers();

        if (studentCouncilMembers.Count > 0)
        {
            Console.WriteLine("Członkowie samorządu:");

            foreach (var member in studentCouncilMembers)
            {
                Console.WriteLine($"Imię: {member.FirstName}, Nazwisko: {member.LastName}, Role: {member.Role}");
            }
        }
        else
        {
            Console.WriteLine("Brak członków samorządu.");
        }
    }

    static void RemoveStudentCouncilMember(Database database)
    {
        Console.WriteLine("Podaj ID członka samorządu do usunięcia:");
        int studentId = int.Parse(Console.ReadLine());

        database.RemoveStudentCouncilMember(studentId);
    }
    static void UpdateStudentCouncilRole(Database database)
    {
        Console.WriteLine("Podaj ID członka samorządu do zaktualizowania roli:");
        int studentId = int.Parse(Console.ReadLine());

        Console.WriteLine("Podaj nową rolę dla członka samorządu:");
        string newRole = Console.ReadLine();

        database.UpdateStudentCouncilRole(studentId, newRole);
    }
}
