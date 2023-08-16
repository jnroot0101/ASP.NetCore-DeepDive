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
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthorAsync(Guid authorId)
    {
        if (authorId == null) throw new ArgumentNullException(nameof(authorId));

#pragma warning disable CS8603
        return await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
#pragma warning restore CS8603
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync(IEnumerable<Guid> authorIds)
    {
        if (authorIds == null) throw new ArgumentNullException(nameof(authorIds));

        return await _context.Authors.Where(a => authorIds.Contains(a.Id))
            .OrderBy(a => a.FirstName)
            .OrderBy(a => a.LastName)
            .ToListAsync();
    }

    public void AddAuthor(Author author)
    {
        if (author == null) throw new ArgumentNullException(nameof(author));

        // the repository fills the id (instead of using identity columns)
        author.Id = Guid.NewGuid();

        foreach (var course in author.Courses) course.Id = Guid.NewGuid();

        _context.Authors.Add(author);
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
        if (authorId == Guid.Empty) throw new NotImplementedException(nameof(authorId));

        return await _context.Authors.AnyAsync(a => a.Id == authorId);
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}