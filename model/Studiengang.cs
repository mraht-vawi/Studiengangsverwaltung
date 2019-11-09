using System;
using System.ComponentModel.DataAnnotations;
using Universitätsverwaltung.model;

namespace Universitätsverwaltung
{
    [Serializable]
    public class Studiengang
    {
        [Required]
        [StringLength(42, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public Abschluss Abschluss { get; set; } = new Abschluss();
        [Required]
        [Range(1, 999)]
        public int ECTS { get; set; }
        public SemesterListe SemesterListe { get; set; } = new SemesterListe();
        public StudentListe StudentListe { get; set; } = new StudentListe();

        public Studiengang() { }

        public Studiengang(string name, Abschluss abschluss, int ects, SemesterListe semesterListe, StudentListe studentListe)
        {
            Name = name;
            Abschluss = abschluss;
            ECTS = ects;
            SemesterListe = semesterListe;
            StudentListe = studentListe;
        }

        public Studiengang(string name, Abschluss abschluss, string ects, SemesterListe semesterListe, StudentListe studentListe)
        {
            Name = name;
            Abschluss = abschluss;

            if (int.TryParse(ects, out int result))
            {
                ECTS = int.Parse(ects);
            }

            SemesterListe = semesterListe;
            StudentListe = studentListe;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            Studiengang studiengang = (Studiengang)obj;

            return Name.Equals(studiengang.Name);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}