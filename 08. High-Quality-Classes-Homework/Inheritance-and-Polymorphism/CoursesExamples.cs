﻿using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    class CoursesExamples
    {
        static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.AddStudent("Peter");
            localCourse.AddStudent("Maria");
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev", 
                new List<string>() { "Thomas", "Ani", "Steve" });
            offsiteCourse.Town = "Sofiq";

            Console.WriteLine(offsiteCourse);
        }
    }
}
