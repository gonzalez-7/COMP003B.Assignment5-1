using COMP003B.Assignment5.Models;

namespace COMP003B.Assignment5.Data
{
	public static class StudentStore
	{
		public static List<Student> Students { get; set; } = new()
		{
			new Student
			{
				Id= 1,
				FirstName = "Antonio",
				LastName = "Gonzalez",
				Age = 19,
				Major = "Information Technology"
			},

			new Student
			{
				Id= 2,
				FirstName = "Jonathan",
				LastName = "Cruz",
				Age= 28,
				Major = "Business Administration"
			},
			new Student
			{
				Id= 3,
				FirstName = "Alex",
				LastName = "Lopez",
				Age = 24,
				Major = "Computer Science"

			}
		};
	}
}
