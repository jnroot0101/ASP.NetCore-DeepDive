using CourseLibrary.API.DbContexts;
using CourseLibrary.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLibrary.API.Services;

public class CourseLibraryRepository : ICourseLibraryRepository
{
    private readonly CourseLibraryContext _context;

    public CourseLibraryRepository(CourseLibraryContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Course>> GetCoursesAsync(Guid authorId)
    {
        if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

        return await _context.Courses
            .Where(c => c.AuthorId == authorId)
            .OrderBy(c => c.Title)
            .ToListAsync();
    }

    public async Task<Course> GetCourseAsync(Guid authorId, Guid courseId)
    {
        if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

        if (courseId == Guid.Empty) throw new ArgumentNullException(nameof(courseId));

#pragma warning disable CS8603
        return await _context.Courses
            .Where(c => c.AuthorId == authorId && c.Id == courseId).FirstOrDefaultAsync();
#pragma warning restore CS8603
    }

    public void AddCourse(Guid authorId, Course course)
    {
        if (authorId == Guid.Empty) throw new ArgumentNullException(nameof(authorId));

        if (course == null) throw new ArgumentNullException(nameof(course));

        // Always set the AuthorId to the passed-in authorId
        course.AuthorId = authorId;
        _context.Courses.Add(course);
    }

    public void UpdateCourse(Course course)
    {
        throw new NotImplementedException();
    }

    public void DeleteCourse(Course course)
    {
        _context.Courses.Remove(course);
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Author> GetAuthorAsync(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync(IEnumerable<Guid> authorIds)
    {
        throw new NotImplementedException();
    }

    public void AddAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public void UpdateAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public void DeleteAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AuthorExistsAsync(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }
}