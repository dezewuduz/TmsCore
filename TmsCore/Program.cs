//Console.WriteLine("Hello, World!");
//string region = null; //⚠ Compiler warning CS8600
//Console.WriteLine(region.ToUpper()); //⚠ Compiler warning CS8602
//string? region = null;
// Null-conditional operator '?.' — skip the call if null
// If region is null, ToUpper() never executes. No crash.
//string? upperRegion = region?.ToUpper();
//Console.WriteLine($"Region (conditional): {upperRegion}");
// Null-coalescing operator '??' — provide a fallback value
// If region is null, use "Unassigned" instead.
//string displayRegion = region ?? "Unassigned";
//Console.WriteLine($"Region (coalesced): {displayRegion}");
//Console.WriteLine($"Region (assigned): {region}");
//string studentName = "Abeba";
//string studentId = "STU-001";
//int enrollmentCount = 3;
//decimal grantAmount = 1999.99m; // 'm' suffix marks a decimal literal
//DateTime enrolledAt = DateTime.UtcNow;
//string? campusRegion = null;
//Console.WriteLine($"Student: {studentName} ({studentId})");
//Console.WriteLine($"Courses: {enrollmentCount}");
//Console.WriteLine($"Grant: {grantAmount:F2}");
//Console.WriteLine($"Enrolled: {enrolledAt:yyyy-MM-dd}");
//Console.WriteLine($"Campus: {campusRegion ?? "Not assigned"}");
//double grantPerStudent = 1999.99;
//double totalAllocation = grantPerStudent * 100_000;
//Console.WriteLine($"Total allocated (double): {totalAllocation}");
// Fixed implementation — exact financial math
//decimal grantPerStudent = 1999.99m;
//decimal totalAllocation = grantPerStudent * 100_000m;
//Console.WriteLine($"Total allocated (decimal): {totalAllocation}");
//Console.WriteLine($"Total allocated (formatted): {totalAllocation:F2}");
//var enrollment = new EnrollmentRecord("STU-001", "CS-401", DateTime.UtcNow);
//Console.WriteLine(enrollment);
// Try to mutate it — uncomment this line and see the compiler error:
// enrollment.CourseCode = "HACKED"; // ERROR: init-only property
// Non-destructive copy — creates a NEW record with one field changed
//var corrected = enrollment with { CourseCode = "CS-402" };
//Console.WriteLine(corrected);
// Value equality — two records with the same data are equal
//var duplicate = new EnrollmentRecord("STU-001", "CS-401", enrollment.EnrolledAt);
//Console.WriteLine($"Same data? {enrollment == duplicate}"); // True

// 1. መደበኛ መረጃ
//var course = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
//Console.WriteLine($"Course: {course.Title} (Capacity: {course.Capacity})");

// 2. የተሳሳተ Capacity ለመስጠት መሞከር (ይህ Exception መጣል አለበት)
//try
//{
//course.Capacity = -5;
//}
//catch (ArgumentOutOfRangeException ex)
//{
//    Console.WriteLine($"Caught: {ex.Message}");
//}

// 3. የተሳሳተ Title ለመስጠት መሞከር (ይህም Exception መጣል አለበት)
//try
//{
//course.Title = "";
//}
//catch (ArgumentException ex)
//{
//    Console.WriteLine($"Caught: {ex.Message}");
//}
//var s = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
//Console.WriteLine($"Student: {s.Name}, GPA: {s.GPA}");
//void PrintGradeReport(IEnumerable<IGradable> assessments)
//{
//Console.WriteLine("--- Grade Report ---");
//foreach (var item in assessments)
//{
//Console.WriteLine($"{item.Title}: {item.CalculateGrade():F2}%");
//}
//}
// Test it — one array holds two completely different types
//IGradable[] cohortAssessments = [
//new Quiz { Title = "C# Basics", CorrectAnswers = 18, TotalQuestions = 20 },
//new LabAssignment { Title = "Registration API", FunctionalityScore = 90m, CodeQualityScore =85m }];
//PrintGradeReport(cohortAssessments);
    // sensetion -2
//var service = new EnrollmentService();
// Test 1: Valid registration
//var validStudent = new Student { Id = "S1", Name = "Abeba", Age = 20, GPA = 3.8m };
//var validCourse = new Course { Code = "CS-401", Title = "Advanced C#", Capacity = 30 };
//var result = service.ProcessRegistration(validStudent, validCourse);
//Console.WriteLine($"Enrolled: {result.StudentId} in {result.CourseCode}");
// Test 2: Null student should throw
//try
//{
//service.ProcessRegistration(null, validCourse);
//}
//catch (ArgumentNullException ex)
//{
//Console.WriteLine($"Guard caught: {ex.ParamName}");
//}
// Test 3: Full course should throw
//var fullCourse = new Course { Code = "CS-402", Title = "Full Course", Capacity = 1 };
//fullCourse.EnrolledCount = 1;
//try
//{
//service.ProcessRegistration(validStudent, fullCourse);
//}
//catch (InvalidOperationException ex)
//{
//Console.WriteLine($"Business rule: {ex.Message}");
//}
// C# 12+ Collection Expressions the modern way to initialize lists
/*List<Student> students = [
new Student { Id = "S1", Name = "Abeba", Age = 22, GPA = 3.8m },
new Student { Id = "S2", Name = "Kidane", Age = 21, GPA = 2.4m },
new Student { Id = "S3", Name = "Dawit", Age = 20, GPA = 3.1m },
new Student { Id = "S4", Name = "Sara", Age = 23, GPA = 3.9m },
new Student { Id = "S5", Name = "Frehiwot", Age = 19, GPA = 2.0m },
new Student { Id = "S6", Name = "Yonas", Age = 24, GPA = 3.5m },
new Student { Id = "S7", Name = "Meron", Age = 22, GPA = 1.8m },
new Student { Id = "S8", Name = "Tesfaye", Age = 21, GPA = 2.9m }];
var leaderboard = students;
Console.WriteLine($"Found {leaderboard.Count} Honors Students:");
foreach (var name in leaderboard)
{
Console.WriteLine($"- {name}");
}
decimal averageGpa = students.Average(s => s.GPA);
// Stuck? Pattern: students.Average(s => s.SomeProperty)
Console.WriteLine($"\nClass Average GPA: {averageGpa:F2}");
// TODO 6: Use .GroupBy with a switch expression to classify each student.
// GPA >= 3.5 → "Honors", >= 2.5 → "Good Standing",
// >= 2.0 → "Probation", < 2.0 → "Academic Warning"
var standingGroups = students.GroupBy(s => s.GPA switch { >= 3.5m => "Honors", >= 2.5m => "Good Standing", >= 2.0m => "Probation", _ => "Academic Warning" });
// Stuck? Pattern: .GroupBy(s => s.GPA switch { >= X => "Label", ... })
Console.WriteLine("\n--- Academic Standing Report ---");
foreach (var group in standingGroups)
{
Console.WriteLine($"\n{group.Key} ({group.Count()}):");
foreach (var s in group)
{
Console.WriteLine($" {s.Name} GPA: {s.GPA}");
}
}
// TODO 7: Use the spread operator (..) to merge two arrays and append a value.
// Stuck? Pattern: string[] combined = [..array1, ..array2, "extra"];
string[] backendCourses = ["C#", "ASP.NET Core"];
string[] frontendCourses = ["TypeScript", "Angular"];
string[] allCourses = [..backendCourses, ..frontendCourses, "DevOps"];
Console.WriteLine($"\nFull curriculum: {string.Join(", ", allCourses)}");*/
// sensetion -----3
/*using System.Diagnostics;
// Simulate 5 database calls, each taking 300ms
// THE WRONG WAY: Blocking with Thread.Sleep
var sw = Stopwatch.StartNew();
for (int i = 0; i < 5; i++)
{
Thread.Sleep(300); // Thread is HELD for 300ms cannot serve anyone else
}
Console.WriteLine($"Blocking sequential: {sw.ElapsedMilliseconds}ms");
// ASYNC BUT STILL SEQUENTIAL: Thread released, but calls are one-at-a-time
sw.Restart();
for (int i = 0; i < 5; i++)
{
await Task.Delay(300); // Thread released while waiting but still sequential
}
Console.WriteLine($"Async sequential: {sw.ElapsedMilliseconds}ms");
// THE RIGHT WAY: Async parallel all 5 start simultaneously
sw.Restart();
var tasks = Enumerable.Range(0, 5).Select(_ => Task.Delay(300));
await Task.WhenAll(tasks);
Console.WriteLine($"Async parallel: {sw.ElapsedMilliseconds}ms");*/
/*async Task<Student> FetchStudentAsync(string id)
{
Console.WriteLine($" Fetching {id}...");
await Task.Delay(300); // Simulate database latency
return new Student
{
Id = id,
Name = $"Student-{id}",
Age = 20,
GPA = id switch
{
"S1" => 3.8m,
"S2" => 2.4m,
"S3" => 3.5m,
"S4" => 1.9m,
"S5" => 3.2m,
_ => 2.5m
}
};
}
Now add a second method that fetches a course:
async Task<Course> FetchCourseAsync(string code)
{
Console.WriteLine($" Fetching course {code}...");
await Task.Delay(200); // Simulate database latency
return new Course
{
Code = code,
Title = $"Course-{code}",
Capacity = code switch
{
"CRS-101" => 2,
"CRS-201" => 30,
"CRS-301" => 15,
_ => 25
}
};
sw.Restart();
// Start all fetches simultaneously students AND courses
string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
string[] courseCodes = ["CRS-101", "CRS-201", "CRS-301"];
var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
var courseTasks = courseCodes.Select(code => FetchCourseAsync(code));
// Both arrays load concurrently
Student[] students = await Task.WhenAll(studentTasks);
Course[] courses = await Task.WhenAll(courseTasks);
Console.WriteLine($"\nLoaded {students.Length} students and {courses.Length} courses in {sw.E
lapsedMilliseconds}ms");
foreach (var s in students)
{
Console.WriteLine($" {s.Name} GPA: {s.GPA}");
}*/
/*using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// 1. Initialize and start the stopwatch
Stopwatch sw = new Stopwatch();
sw.Start();

Console.WriteLine("--- Asynchronous Data Loading Started ---");

// 2. Start operations concurrently (In Parallel)
string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
string[] courseCodes = ["CRS-101", "CRS-201", "CRS-301"];

// The methods are invoked here, but they do not block execution because they are not awaited yet
var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
var courseTasks = courseCodes.Select(code => FetchCourseAsync(code));

// 3. Wait for all tasks to complete together using Task.WhenAll
Student[] students = await Task.WhenAll(studentTasks);
Course[] courses = await Task.WhenAll(courseTasks);

sw.Stop();

// 4. Display the execution results
Console.WriteLine($"\nLoaded {students.Length} students and {courses.Length} courses completed in {sw.ElapsedMilliseconds}ms!");

Console.WriteLine("\n--- Student List ---");
foreach (var s in students)
{
    Console.WriteLine($" {s.Name} | GPA: {s.GPA}");
}

// --- Simulated Database Methods ---

async Task<Student> FetchStudentAsync(string id)
{
    Console.WriteLine($" [Student] Database request sent for {id}...");
    await Task.Delay(300); // 300 milliseconds delay
    return new Student
    {
        Id = id,
        Name = $"Student-{id}",
        Age = 20,
        GPA = id switch
        {
            "S1" => 3.8m,
            "S2" => 2.4m,
            "S3" => 3.5m,
            "S4" => 1.9m,
            "S5" => 3.2m,
            _ => 2.5m
        }
    };
}

async Task<Course> FetchCourseAsync(string code)
{
    Console.WriteLine($" [Course] Database request sent for {code}...");
    await Task.Delay(200); // 200 milliseconds delay
    return new Course
    {
        Code = code,
        Title = $"Course-{code}",
        Capacity = code switch
        {
            "CRS-101" => 2,
            "CRS-201" => 30,
            "CRS-301" => 15,
            _ => 25
        }
    };
}

sw.Restart();

// Start all fetches simultaneously students AND courses
string[] studentIds2 = ["S1", "S2", "S3", "S4", "S5"];
string[] courseCodes2 = ["CRS-101", "CRS-201", "CRS-301"];

var studentTasks2 = studentIds2.Select(id => FetchStudentAsync(id));
var courseTasks2 = courseCodes2.Select(code => FetchCourseAsync(code));

// Both arrays load concurrently
Student[] students2 = await Task.WhenAll(studentTasks2);
Course[] courses2 = await Task.WhenAll(courseTasks2);

// FIX IS HERE: Brought onto a single line
Console.WriteLine($"\nLoaded {students2.Length} students and {courses2.Length} courses in {sw.ElapsedMilliseconds}ms");

foreach (var s in students2)
{
Console.WriteLine($" {s.Name} GPA: {s.GPA}");
}*/
// --- Your Existing Main Code Execution ---
/*async Task SendConfirmationAsync(Student student)
{
try
{
await Task.Delay(100); // Simulate sending email
Console.WriteLine($" Email sent to {student.Name}");
}
catch (Exception ex)
{
// Log the failure do NOT re-throw.
// This is intentional fire-and-forget.
Console.WriteLine($" Email failed for {student.Name}: {ex.Message}");
}
}*/
/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
Stopwatch sw = new Stopwatch();
sw.Start();

var enrollments = new List<EnrollmentRecord>();
var failures = new List<string>();
var enrollService = new EnrollmentService();

Console.WriteLine("--- Loading Data Simultaneously ---");

// Mocking a baseline course for testing capacity limits
var validCourse = new Course { Code = "CRS-201", Title = "Cloud Computing", Capacity = 2, EnrolledCount = 0 };

// Load students concurrently via Task.WhenAll
string[] studentIds = ["S1", "S2", "S3", "S4", "S5"];
var studentTasks = studentIds.Select(id => FetchStudentAsync(id));
Student[] students = await Task.WhenAll(studentTasks); 
Console.WriteLine("\n--- Processing Enrollments ---");
foreach (var s in students)
{
    try
    {
        // Attempt to register each student
        var record = enrollService.ProcessRegistration(s, validCourse);
        enrollments.Add(record);
        
        // Update the course count manually to simulate filling up the seats
        validCourse.EnrolledCount++; 
    }
    catch (Exception ex)
    {
        // Intercept and log failures securely without halting the application
        failures.Add($"Student {s.Name} failed: {ex.Message}");
    }
}/*
sw.Stop();

// Safe evaluation prevents division-by-zero crashes if array is unpopulated
decimal classAverage = students.Length > 0
    ? students.Average(s => s.GPA)
    : 0m;

// Render out structural breakdown metrics
Console.WriteLine("\n========== ENROLLMENT SUMMARY ==========");
Console.WriteLine($"Total students loaded: {students.Length}");
Console.WriteLine($"Successful enrollments: {enrollments.Count}");
Console.WriteLine($"Failed enrollments: {failures.Count}");
Console.WriteLine($"Class average GPA: {classAverage:F2}");
Console.WriteLine($"Total elapsed time: {sw.ElapsedMilliseconds}ms");

if (failures.Count > 0)
{
    Console.WriteLine("\n--- Failure Details ---");
    foreach (var failure in failures)
    {
        Console.WriteLine($" {failure}");
    }
}
Console.WriteLine("========================================");
async Task<Student> FetchStudentAsync(string id)
{
    await Task.Delay(300); // Emulating remote database latency
    return new Student
    {
        Id = id,
        Name = $"Student-{id}",
        Age = 21,
        GPA = id switch 
        { 
            "S1" => 3.8m, 
            "S2" => 2.4m, 
            "S3" => 3.5m, 
            "S4" => 1.9m, 
            _    => 3.2m 
        }
    };
}*/
//
var service = new EnrollmentService();
var sampleStudent = new Student { Id = "S1", Name = "Abeba", GPA = 3.8m };

// Assign a listener method using a lambda expression
service.EnrollmentListener = (student) => 
{
    Console.WriteLine($" Notification Triggered: Sending welcome email to {student.Name}!");
};

// This will persist to the database AND trigger your listener code automatically
service.FinalizeEnrollment(sampleStudent);