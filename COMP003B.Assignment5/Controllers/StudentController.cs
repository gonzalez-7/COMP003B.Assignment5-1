using COMP003B.Assignment5.Models;
using COMP003B.Assignment5.Data;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment5.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class StudentController : Controller
	{
		[HttpGet]
		public ActionResult<List<Student>> GetStudents()
		{
			return Ok(StudentStore.Students);
		}

		[HttpGet("{id}")]
		public ActionResult<Student> GetStudent(int id)
		{
			var student = StudentStore.Students.FirstOrDefault(s => s.Id == id);

			if (student == null)
				return NotFound();

			return Ok(student);
		}

		[HttpPost]
		public ActionResult<Student> CreateStudent(Student student)
		{
			student.Id = StudentStore.Students.Count > 0
				? StudentStore.Students.Max(s => s.Id) + 1
				: 1;

			StudentStore.Students.Add(student);

			return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateStudent(int id, Student updatedStudent)
		{
			if (id != updatedStudent.Id)
				return BadRequest();

			var existingStudent = StudentStore.Students.FirstOrDefault(s =>s.Id == id);

			if (existingStudent == null)
				return NotFound();

			existingStudent.FirstName = updatedStudent.FirstName;
			existingStudent.LastName = updatedStudent.LastName;
			existingStudent.Age = updatedStudent.Age;
			existingStudent.Major = updatedStudent.Major;

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteStudent(int id)
		{
			var student = StudentStore.Students.FirstOrDefault(s => s.Id == id);

			if (student == null)
				return NotFound();

			StudentStore.Students.Remove(student);

			return NoContent();
		}
	}
}
