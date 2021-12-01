﻿using HealthInspector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class Search
    {
        public Search()
        {
            Specialities= new List<SelectListItem>()
            { new SelectListItem{Text="Family Physician",Value="Family Physician"},
            new SelectListItem{Text="Internal Medicine Physician",Value="Internal Medicine Physician"},
            new SelectListItem{Text="Pediatrician",Value="Pediatrician"},
             new SelectListItem{Text="Obstetrician/Gynecologist (OB/GYN)",Value="Obstetrician/Gynecologist (OB/GYN)"},
             new SelectListItem{Text="Surgeon",Value="Surgeon"},
             new SelectListItem{Text="Psychiatrist",Value="Psychiatrist"},
             new SelectListItem{Text="Cardiologist",Value="Cardiologist"},
             new SelectListItem{Text="Dermatologist",Value="Dermatologist"},
             new SelectListItem{Text="Endocrinologist",Value="Endocrinologist"},
             new SelectListItem{Text="Gastroenterologist",Value="Gastroenterologist"},
             new SelectListItem{Text="Infectious Disease Physician",Value="Infectious Disease Physician"},
             new SelectListItem{Text="Nephrologist",Value="Nephrologist"},
             new SelectListItem{Text="Ophthalmologist",Value="Ophthalmologist"},
             new SelectListItem{Text="Pulmonologist",Value="Pulmonologist"},
             new SelectListItem{Text="Neurologist",Value="Neurologist"},
             new SelectListItem{Text="Physician Executive",Value="Physician Executive"}
            };
        }
        public string Speciality { get; set; }
        public string Locality{ get; set; }
        public List<SelectListItem> Specialities { get; set; }
        public List<Locality> Localities { get; set; }
    }
}
