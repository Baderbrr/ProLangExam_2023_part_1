using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.DataAccess;

namespace University.Controllers;

[Route("{controller}")]
public class TestController
{
    private readonly UniversityDbContext _universityDbContext;

    public TestController(UniversityDbContext universityDbContext) => _universityDbContext = universityDbContext;

}