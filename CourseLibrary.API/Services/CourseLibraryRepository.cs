using CourseLibrary.API.Entities;

namespace CourseLibrary.API.Services;

public class CourseLibraryRepository: ICourseLibraryRepository
{
    public async Task<IEnumerable<Course>> GetCoursesAsync(Guid authorId)
    {
        throw new NotImplementedException();
    }

    public async Task<Course> GetCourseAsync(Guid authorId, Guid courseId)
    {
        throw new NotImplementedException();
    }

    public void AddCourse(Guid authorId, Course course)
    {
        throw new NotImplementedException();
    }

    public void UpdateCourse(Course course)
    {
        throw new NotImplementedException();
    }

    public void DeleteCourse(Course course)
    {
        throw new NotImplementedException();
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