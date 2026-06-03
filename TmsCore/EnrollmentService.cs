/*using System;

public class EnrollmentService
{
    public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
    {
        // TODO 1: Add guard clauses (Fail fast)
        if (student is null) 
        {
            throw new ArgumentNullException(nameof(student));
        }
        
        if (course is null) 
        {
            throw new ArgumentNullException(nameof(course));
        }
        
        if (course.Capacity <= 0 || course.EnrolledCount >= course.Capacity)
        {
            throw new InvalidOperationException("Course is full or has an invalid capacity.");
        }

        // TODO 2: Use a switch expression on student.GPA to classify academic standing
        string standing = student.GPA switch
        {
            >= 3.5m => "Honors",
            >= 2.5m => "Good Standing",
            _       => "Academic Warning" // The discard '_' handles everything < 2.5
        };

        Console.WriteLine($"{student.Name} is in {standing}.");

        // TODO 3: Return a new EnrollmentRecord (Fixes the CS0161 error!)
        return new EnrollmentRecord(student.Id, course.Code, DateTime.UtcNow);
    }
}*/
/*public class EnrollmentService
{
public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
{
if (student is null)
throw new ArgumentNullException(nameof(student));
if (course is null)
throw new ArgumentNullException(nameof(course));
if (course.EnrolledCount >= course.Capacity)
throw new CapacityReachedException(course.Code);
string standing = student.GPA switch
{
>= 3.5m => "Honors",
>= 2.5m => "Good Standing",
_ => "Academic Warning"
};
Console.WriteLine($" {student.Name} is in {standing}.");
return new EnrollmentRecord(student.Id, course.Code, DateTime.UtcNow);
}
}*/
using System;

public class EnrollmentService
{
    // TODO 2: Create a property that holds the delegate 'listener'
    // Using Action<Student> allows any method that takes a Student to listen to this event.
    public Action<Student>? EnrollmentListener { get; set; }

    public void FinalizeEnrollment(Student s)
    {
        Console.WriteLine("Persisting to database...");

        // TODO 3: Check if the delegate listener is 'not null' and invoke it.
        // The '?.' operator (Null-conditional) cleanly checks for null before invoking.
        EnrollmentListener?.Invoke(s);
    }
}