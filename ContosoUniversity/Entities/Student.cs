﻿using System;
using System.Collections.Generic;

namespace ContosoUniversity.Entities
{
    public class Student
    {
        public Student(ICollection<Enrollment> enrollments)
        {
            Enrollments = enrollments;
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}