using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using ProjektPO;

public class Database
{
    private List<Student> students;
    private List<Teacher> teachers;
    private List<Grade> grades;
    private List<Subject> subjects;
    private List<StudentCouncil> studentCouncilMembers;
    private List<Parents> parents;


    public Database()
    {
        students = new List<Student>();
        teachers = new List<Teacher>();
        grades = new List<Grade>();
        subjects = new List<Subject>();
        studentCouncilMembers = new List<StudentCouncil>();
        parents = new List<Parents>();
    }
    public void LoadStudentsFromJson(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            students = JsonConvert.DeserializeObject<List<Student>>(json);
            Console.WriteLine("Dane uczniów zostały wczytane z pliku JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych uczniów: {ex.Message}");
        }
    }

    public void LoadTeachersFromJson(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);
            Console.WriteLine("Dane nauczycieli zostały wczytane z pliku JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych nauczycieli: {ex.Message}");
        }
    }
    public void LoadSubjectsFromJson(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            subjects = JsonConvert.DeserializeObject<List<Subject>>(json);
            Console.WriteLine("Dane przedmiotów zostały wczytane z pliku JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych przedmiotów: {ex.Message}");
        }
    }

    public void LoadGradesFromJson(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            grades = JsonConvert.DeserializeObject<List<Grade>>(json);
            Console.WriteLine("Dane ocen zostały wczytane z pliku JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych ocen: {ex.Message}");
        }
    }
    public void LoadStudentCouncilMembersFromJson(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            studentCouncilMembers = JsonConvert.DeserializeObject<List<StudentCouncil>>(json);
            Console.WriteLine("Dane członków samorządu zostały wczytane z pliku JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych członków samorządu: {ex.Message}");
        }
    }


    private void SaveStudentCouncilMembersToJson(string fileName)
    {
        string json = JsonConvert.SerializeObject(studentCouncilMembers);
        File.WriteAllText(fileName, json);
    }


    private void SaveDatabase()
    {
        string json = JsonConvert.SerializeObject(Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText("database.json", json);
    }


    public void AddGrade(Grade grade)
    {
        grades.Add(grade);
        SaveGradesToJson("Oceny.json");
        Console.WriteLine("Ocena została dodana.");
    }


    public List<Student> GetStudents()
    {
        return students;
    }

    public List<Teacher> GetTeachers()
    {
        return teachers;
    }
    public List<Grade> GetGrades()
    {
        return grades;
    }
    public List<Grade> GetStudentGrades(int studentId)
    {
        List<Grade> studentGrades = grades.Where(g => g.StudentId == studentId).ToList();
        return studentGrades;
    }

    public List<FinalGrade> GetFinalGrades()
    {
        List<FinalGrade> finalGrades = new List<FinalGrade>();

        foreach (Grade grade in grades)
        {
            finalGrades.Add(new FinalGrade { StudentId = grade.StudentId, Value = grade.Value });
        }

        return finalGrades;
    }
    public List<Subject> GetSubjects()
    {
        return subjects;
    }

    public List<StudentCouncil> GetStudentCouncilMembers()
    {
        try
        {
            string json = File.ReadAllText("Samorzad.json");
            List<StudentCouncil> studentCouncilMembers = JsonConvert.DeserializeObject<List<StudentCouncil>>(json);
            Console.WriteLine("Dane członków samorządu zostały wczytane z pliku JSON.");
            return studentCouncilMembers;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych członków samorządu: {ex.Message}");
            return new List<StudentCouncil>();
        }
    }

    public List<Parents> GetParents()
    {
        try
        {
            string json = File.ReadAllText("Rodzice.json");
            List<Parents> parents = JsonConvert.DeserializeObject<List<Parents>>(json);
            Console.WriteLine("Dane rodziców zostały wczytane z pliku JSON.");
            return parents;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych rodziców: {ex.Message}");
            return new List<Parents>();
        }
    }


    public void RemoveGrade(int Gradeid)
    {
        Grade gradeToRemove = grades.Find(g => g.Id == Gradeid);
        if (gradeToRemove != null)
        {
            grades.Remove(gradeToRemove);
            SaveGradesToJson("Oceny.json");
            Console.WriteLine("Ocena została usunięta.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono oceny o podanym identyfikatorze.");
        }
    }

    public void RemoveStudent(int studentId)
    {
        Student studentToRemove = students.Find(s => s.IdP == studentId);
        if (studentToRemove != null)
        {
            students.Remove(studentToRemove);
            SaveStudentsToJson("Studenci.json");
            Console.WriteLine("Uczeń został usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono ucznia o podanym identyfikatorze.");
        }
    }

    public void AddStudent(Student student)
    {
        students.Add(student);
        SaveStudentsToJson("Studenci.json");
        Console.WriteLine("Uczeń został dodany.");
    }

    public void RemoveTeacher(int teacherId)
    {
        Teacher teacherToRemove = teachers.Find(t => t.IdP == teacherId);
        if (teacherToRemove != null)
        {
            teachers.Remove(teacherToRemove);
            SaveTeachersToJson("Nauczyciele.json");
            Console.WriteLine("Nauczyciel został usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono nauczyciela o podanym identyfikatorze.");
        }
    }


    public void AddTeacher(Teacher teacher)
    {
        teachers.Add(teacher);
        SaveTeachersToJson("Nauczyciele.json");
        Console.WriteLine("Nauczyciel został dodany.");
    }


    public double CalculateFinalGrade(int studentId, int subjectId)
    {
        List<Grade> studentGrades = grades.Where(g => g.StudentId == studentId && g.SubjectId == subjectId).ToList();

        if (studentGrades.Count > 0)
        {
            double sumOfGrades = studentGrades.Sum(g => g.Value);
            double finalGrade = sumOfGrades / studentGrades.Count;
            return finalGrade;
        }
        else
        {
            Console.WriteLine("Brak ocen dla danego ucznia i przedmiotu.");
            return 0;
        }

    }

    public void RemoveSubject(int subjectId)
    {
        Subject subjectToRemove = subjects.Find(s => s.Id == subjectId);
        if (subjectToRemove != null)
        {
            subjects.Remove(subjectToRemove);
            SaveSubjectsToJson("Przedmioty.json");
            Console.WriteLine("Przedmiot został usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono przedmiotu o podanym identyfikatorze.");
        }
    }

    public void AddSubject(Subject subject)
    {
        subjects.Add(subject);
        SaveSubjectsToJson("Przedmioty.json");
        Console.WriteLine("Przedmiot został dodany.");
    }

    public void UpdateStudent(Student updatedStudent)
    {
        Student existingStudent = students.FirstOrDefault(s => s.StudentId == updatedStudent.StudentId);
        if (existingStudent != null)
        {
            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;
            SaveStudentsToJson("Studenci.json");
            Console.WriteLine("Dane ucznia zostały zaktualizowane.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono ucznia o podanym numerze albumu.");
        }
    }

    public void UpdateTeacher(Teacher updatedTeacher)
    {
        Teacher existingTeacher = teachers.Find(t => t.TeacherId == updatedTeacher.TeacherId);

        if (existingTeacher != null)
        {
            existingTeacher.FirstName = updatedTeacher.FirstName;
            existingTeacher.LastName = updatedTeacher.LastName;
            SaveTeachersToJson("Nauczyciele.json");
            Console.WriteLine("Dane nauczyciela zostały zaktualizowane.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono nauczyciela o podanym identyfikatorze.");
        }
    }

    public void UpdateSubject(Subject updatedSubject)
    {
        Subject existingSubject = subjects.Find(s => s.Id == updatedSubject.Id);

        if (existingSubject != null)
        {
            existingSubject.Name = updatedSubject.Name;
            SaveSubjectsToJson("Przedmioty.json");
            Console.WriteLine("Dane przedmiotu zostały zaktualizowane.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono przedmiotu o podanym identyfikatorze.");
        }
    }

    public void UpdateGrade(Grade updatedGrade)
    {
        Grade gradeToUpdate = grades.Find(g => g.Id == updatedGrade.Id);

        if (gradeToUpdate != null)
        {
            gradeToUpdate.StudentId = updatedGrade.StudentId;
            gradeToUpdate.SubjectId = updatedGrade.SubjectId;
            gradeToUpdate.Value = updatedGrade.Value;

            SaveGradesToJson("Oceny.json");
            Console.WriteLine("Ocena została zaktualizowana.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono oceny o podanym identyfikatorze.");
        }
    }

    public void AddStudentCouncilMember(int studentId, string firstName, string lastName, string role)
    {
        try
        {
            List<StudentCouncil> studentCouncilMembers = GetStudentCouncilMembers();
            StudentCouncil newMember = new StudentCouncil(studentId, firstName, lastName, role);
            studentCouncilMembers.Add(newMember);
            string json = JsonConvert.SerializeObject(studentCouncilMembers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Samorzad.json", json);
            Console.WriteLine("Członek samorządu został dodany.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas dodawania członka samorządu: {ex.Message}");
        }
    }
    public void RemoveStudentCouncilMember(int studentId)
    {
        StudentCouncil memberToRemove = studentCouncilMembers.FirstOrDefault(m => m.StudentId == studentId);
        if (memberToRemove != null)
        {
            studentCouncilMembers.Remove(memberToRemove);
            SaveStudentCouncilToJson("Samorzad.json");
            Console.WriteLine("Członek samorządu został usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono członka samorządu o podanym identyfikatorze studenta.");
        }
    }

    public void UpdateStudentCouncilRole(int studentId, string newRole)
    {
        StudentCouncil memberToUpdate = studentCouncilMembers.Find(s => s.StudentId == studentId);
        if (memberToUpdate != null)
        {
            memberToUpdate.Role = newRole;
            SaveStudentCouncilMembersToJson("Samorzad.json");
            Console.WriteLine("Rola członka samorządu została zaktualizowana.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono członka samorządu o podanym identyfikatorze.");
        }
    }
    public void LoadParentsFromJson(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            parents = JsonConvert.DeserializeObject<List<Parents>>(json);
            Console.WriteLine("Dane rodziców zostały wczytane z pliku JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas wczytywania danych rodziców: {ex.Message}");
        }
    }

    public void DisplayStudentParents(int studentId)
    {
        List<Parents> studentParents = parents.Where(p => p.KidID == studentId).ToList();

        if (studentParents.Count > 0)
        {
            Console.WriteLine($"Rodzice studenta o ID {studentId}:");
            foreach (var parent in studentParents)
            {
                Console.WriteLine($"ID: {parent.IdP}, Imię: {parent.FirstName}, Nazwisko: {parent.LastName}, Numer telefonu: {parent.PhoneNumber}, Rola: {parent.Role}");
            }
        }
        else
        {
            Console.WriteLine($"Brak rodziców przypisanych do studenta o ID {studentId}.");
        }
    }
    public void AddParentForStudent(int studentId, Parents parent)
    {
        Student student = students.FirstOrDefault(s => s.IdP == studentId);
        if (student != null)
        {
            parent.KidID = studentId;
            parents.Add(parent);
            SaveParentsToJson("Rodzice.json");
            Console.WriteLine("Dodano rodzica dla studenta.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono studenta o podanym ID.");
        }
    }
    public void RemoveParent(int parentId)
    {
        Parents parentToRemove = parents.FirstOrDefault(p => p.IdP == parentId);
        if (parentToRemove != null)
        {
            parents.Remove(parentToRemove);
            SaveParentsToJson("Rodzice.json");
            Console.WriteLine("Rodzic został usunięty.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono rodzica o podanym identyfikatorze.");
        }
    }

    public void UpdateParent(Parents parent)
    {
        Parents parentToUpdate = parents.Find(p => p.IdP == parent.IdP);
        if (parentToUpdate != null)
        {
            parentToUpdate.FirstName = parent.FirstName;
            parentToUpdate.LastName = parent.LastName;
            parentToUpdate.PhoneNumber = parent.PhoneNumber;
            parentToUpdate.Role = parent.Role;
            SaveParentsToJson("Rodzice.json");
            Console.WriteLine("Rodzic został zaktualizowany.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono rodzica o podanym identyfikatorze.");
        }
    }

    private void SaveSubjectsToJson(string fileName)
    {
        string json = JsonConvert.SerializeObject(subjects);
        File.WriteAllText(fileName, json);
    }


    private void SaveStudentsToJson(string fileName)
    {
        string json = JsonConvert.SerializeObject(students);
        File.WriteAllText(fileName, json);
    }

    private void SaveTeachersToJson(string fileName)
    {
        string json = JsonConvert.SerializeObject(teachers);
        File.WriteAllText(fileName, json);
    }

    private void SaveGradesToJson(string fileName)
    {
        string json = JsonConvert.SerializeObject(grades);
        File.WriteAllText(fileName, json);
    }
    private void SaveStudentCouncilToJson(string fileName)
    {
        string json = JsonConvert.SerializeObject(studentCouncilMembers);
        File.WriteAllText(fileName, json);
    }
    private void SaveParentsToJson(string fileName)
    {
        string json = JsonConvert.SerializeObject(parents, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(fileName, json);
    }
}
