using System;
using System.Collections.Generic;
using System.Text;
using Worker.Entities.Enums;

namespace Worker.Entities
{
    internal class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }//Enumeração
        public double BaseSalary { get; set; }
        public Department Department { get; set; }//Associação entre duas classes diferentes(Composição)
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //Um trabalhador tem varios contratos ai estamos usando uma lista para fazer essa representação

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract)
        {
            Contracts.Add(contract);
        }


        public void removeContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if(contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                } 
            }
            return sum;
        }
    }
}
