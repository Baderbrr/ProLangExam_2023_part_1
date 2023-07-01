using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.DataAccess;

namespace University.Controllers;

[Route("{controller}")]
public class TeacherController : Controller
{
    private readonly UniversityDbContext _universityDbContext;

    public TeacherController(UniversityDbContext universityDbContext) => _universityDbContext = universityDbContext;

	[HttpGet("/Teacher/All")]
	public IActionResult GetAllTeachers()
	{
		List<Teacher> teachers = _universityDbContext.Teachers.ToList();
		return Ok(teachers);
	}

	[HttpGet("/Teacher/{id}")]
	public IActionResult GetTeacher(int id)
	{
		Teacher teacher = _universityDbContext.Teachers.Include(t => t.Skills).FirstOrDefault(t => t.Id == id);

		if (teacher == null)
		{
			return NotFound();
		}

		return Ok(teacher);
	}

	[HttpPost("/Teacher")]
	public IActionResult CreateTeacher([FromBody] Teacher teacherData)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		Teacher teacher = new Teacher { FirstName = teacherData.FirstName, LastName = teacherData.LastName, Age = teacherData.Age, Skills = new List<Skill>() };

		foreach (Skill skill in teacherData.Skills)
		{
			Skill existSkill = _universityDbContext.Skills.FirstOrDefault(s => s.Name == skill.Name);
			if (existSkill != null)
			{
				teacher.Skills.Add(existSkill);
			}
			else
			{
				Skill newSkill = new Skill
				{
					Name = skill.Name
				};
				teacher.Skills.Add(newSkill);
			}
		}
		_universityDbContext.Teachers.Add(teacher);
		_universityDbContext.SaveChanges();

		return Created("/Teacher/" + teacher.Id, teacher);
	}
}