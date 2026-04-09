using System.Collections.Generic;
using cs330_proj1;

namespace courseproject.tests;

public class CourseServicesTests
{
    private CourseServices _courseServices;

    public CourseServicesTests()
    {
        _courseServices = new CourseServices();
    }

    // User Story 2: As a student, I want to see all available courses so that I know what my options are.
    [Fact]
    public void GetCourses_ReturnsAllCourses()
    {
        // Arrange
        // Act
        List<Course> courses = _courseServices.getCourses();

        // Assert
        Assert.Equal(5, courses.Count);
        Assert.Contains(courses, c => c.Name == "ARTD 201");
        Assert.Contains(courses, c => c.Name == "ARTS 101");
        Assert.Contains(courses, c => c.Name == "STAT 201");
        Assert.Contains(courses, c => c.Name == "ENGL 302");
        Assert.Contains(courses, c => c.Name == "CSCI 320");
    }

    [Fact]
    public void GetCourses_ReturnsNonEmptyList()
    {
        // Arrange
        // Act
        List<Course> courses = _courseServices.getCourses();

        // Assert
        Assert.NotNull(courses);
        Assert.NotEmpty(courses);
    }

    // User Story 3: As a student, I want to see all course offerings by semester, so that I can choose from what's available to register for next semester.
    [Fact]
    public void GetCourseOfferingsBySemester_ReturnsCorrectForSpring2021()
    {
        // Arrange
        string semester = "Spring 2021";

        // Act
        List<CourseOffering> offerings = _courseServices.getCourseOfferingsBySemester(semester);

        // Assert
        Assert.Equal(2, offerings.Count);
        Assert.Contains(offerings, o => o.TheCourse.Name == "ARTD 201" && o.Section == "D1");
        Assert.Contains(offerings, o => o.TheCourse.Name == "STAT 201" && o.Section == "01");
    }

    [Fact]
    public void GetCourseOfferingsBySemester_ReturnsCorrectForSpring2022()
    {
        // Arrange
        string semester = "Spring 2022";

        // Act
        List<CourseOffering> offerings = _courseServices.getCourseOfferingsBySemester(semester);

        // Assert
        Assert.Single(offerings);
        Assert.Contains(offerings, o => o.TheCourse.Name == "ARTS 101" && o.Section == "01");
    }

    [Fact]
    public void GetCourseOfferingsBySemester_ReturnsCorrectForFall2020()
    {
        // Arrange
        string semester = "Fall 2020";

        // Act
        List<CourseOffering> offerings = _courseServices.getCourseOfferingsBySemester(semester);

        // Assert
        Assert.Equal(2, offerings.Count);
        Assert.Contains(offerings, o => o.TheCourse.Name == "CSCI 320" && o.Section == "01");
        Assert.Contains(offerings, o => o.TheCourse.Name == "ARTS 101" && o.Section == "02");
    }

    [Fact]
    public void GetCourseOfferingsBySemester_ReturnsEmptyForNonExistentSemester()
    {
        // Arrange
        string semester = "Summer 2021";

        // Act
        List<CourseOffering> offerings = _courseServices.getCourseOfferingsBySemester(semester);

        // Assert
        Assert.Empty(offerings);
    }

    // User Story 4: As a student I want to see all course offerings by semester and department so that I can choose major courses to register for.
    [Fact]
    public void GetCourseOfferingsBySemesterAndDept_ReturnsCorrectForSpring2021ARTD()
    {
        // Arrange
        string semester = "Spring 2021";
        string department = "ARTD";

        // Act
        List<CourseOffering> offerings = _courseServices.getCourseOfferingsBySemesterAndDept(semester, department);

        // Assert
        Assert.Single(offerings);
        Assert.Contains(offerings, o => o.TheCourse.Name == "ARTD 201" && o.Section == "D1");
    }

    [Fact]
    public void GetCourseOfferingsBySemesterAndDept_ReturnsCorrectForFall2020ARTS()
    {
        // Arrange
        string semester = "Fall 2020";
        string department = "ARTS";

        // Act
        List<CourseOffering> offerings = _courseServices.getCourseOfferingsBySemesterAndDept(semester, department);

        // Assert
        Assert.Single(offerings);
        Assert.Contains(offerings, o => o.TheCourse.Name == "ARTS 101" && o.Section == "02");
    }

    [Fact]
    public void GetCourseOfferingsBySemesterAndDept_ReturnsCorrectForSpring2021STAT()
    {
        // Arrange
        string semester = "Spring 2021";
        string department = "STAT";

        // Act
        List<CourseOffering> offerings = _courseServices.getCourseOfferingsBySemesterAndDept(semester, department);

        // Assert
        Assert.Single(offerings);
        Assert.Contains(offerings, o => o.TheCourse.Name == "STAT 201" && o.Section == "01");
    }

    [Fact]
    public void GetCourseOfferingsBySemesterAndDept_ReturnsEmptyForNonExistentCombination()
    {
        // Arrange
        string semester = "Spring 2021";
        string department = "CSCI";

        // Act
        List<CourseOffering> offerings = _courseServices.getCourseOfferingsBySemesterAndDept(semester, department);

        // Assert
        Assert.Empty(offerings);
    }
}
