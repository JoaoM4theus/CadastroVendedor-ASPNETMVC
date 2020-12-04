using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasProjetoFbUni.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigátorio")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} tamanho do nome deve ser entre {2} e {1}")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        [Required(ErrorMessage = "{0} obrigátorio")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigátorio")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} obrigátorio")]
        [Range(100.0, 50000.0, ErrorMessage = "Salario base deve ser de 100,00 a 50,000")]
        [Display(Name = "Salario Base")]
        [DisplayFormat(DataFormatString = "R${0:F2}")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public int DepartmentId  { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, DateTime date, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Date = date;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }


    }
}
