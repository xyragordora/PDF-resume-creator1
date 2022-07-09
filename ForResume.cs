using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace resume
{
    class Information
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string Highschool { get; set; }
        public string syHS { get; set; }
        public string Elementary { get; set; }
        public string syELEM { get; set; }
        public string College { get; set; }
        public string syCOL { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }
        public string Experiences { get; set; }

        public string Languages { get; set; }

        public string Skills { get; set; }
        public string Objectives { get; set; }

        public override string ToString()
        {
            return string.Format("\nName: {0} {1} {2} \nAddress: {3} \nEmail: {4} \nPhone Number: {5} \nElementary: {6} SY: {7} \nHigh School: {8} SY: {9} \nCollege: {10} SY: {11} \nDegree: {12} \nGPA: {13}  \n\nExperiences: {14} \nLanguages: {15} \nSkills: {16} \nObjectives: {17}",
                   Surname, FirstName, MiddleName, Address, Email, Phone, Elementary, syELEM, Highschool, syHS, College, syCOL, Degree, GPA, Experiences, Languages, Skills, Objectives);
        }
    }
}

