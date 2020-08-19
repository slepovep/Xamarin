// 16:38
using System;
using System.Collections.Generic;
using parusapp.Models;

namespace parusapp.Utils
{
    public static class DummyProfessionalData
    {
        public static List<Professional> GetProfessionals()
        {
            var data = new List<Professional>();
            var person1 = new Professional() {
                Id = 1,
                Name = "Giraffe",
                Desigination = "Developer",
                Domain = "Web",
                Experience = "3"
            };
            var person2 = new Professional()
            {
                Id = 2,
                Name = "Monkey",
                Desigination = "Developer",
                Domain = "Mobile",
                Experience = "1"
            };
            var person3 = new Professional() {
                Id = 3,
                Name = "Duck",
                Desigination = "Administrator",
                Domain = "Desktop",
                Experience = "2"
            };


            for (int i = 0; i < 10; i++)
            {
                data.Add(person1);
                data.Add(person2);
                data.Add(person3);
            }
            return data;
        }
    }
}