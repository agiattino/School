using System;
using System.Collections.Generic;

namespace App
{

    public class Student
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public enum Classification { 
            Freshman, 
            Sophomore, 
            Junior, 
            Senior }

        public Classification ClassOf { get; set; }
        public IList<Grade> classGrade { get; set; }
    }
}
