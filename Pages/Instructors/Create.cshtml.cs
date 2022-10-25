using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Pages.Instructors
{
    public class CreateModel : InstructorCoursesPageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ContosoUniversity.Data.SchoolContext context, ILogger<CreateModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var instructor = new Instructor();
            instructor.Courses = new List<Course>();

            PopulateAssignedCourseData(_context, instructor);
            return Page();
        }

        [BindProperty]
        public Instructor Instructor { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newIntructor = new Instructor();

            if (selectedCourses.Length > 0)
            {
                newIntructor.Courses = new List<Course>();
                _context.Courses.Load();
            }

            foreach (var course in selectedCourses)
            {
                var foundCourse = await _context.Courses.FindAsync(int.Parse(course));

                if (foundCourse != null)
                {
                    newIntructor.Courses.Add(foundCourse);
                }
                else
                {
                    _logger.LogWarning("Course {course} not found", course);
                }
            }

            try
            {
                if (await TryUpdateModelAsync<Instructor>(newIntructor, "Instructor", i => i.FirstMidName, i => i.LastName, i => i.HireDate, i => i.OfficeAssignment))
                {
                    _context.Instructors.Add(newIntructor);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            PopulateAssignedCourseData(_context, newIntructor);
            return Page();
        }
    }
}
