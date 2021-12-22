using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem
{
    public class Company
    {
        public Company()
        {
            Resources = new List<IPayable>();
        }

        public ICollection<IPayable> Resources { get; set; }

        public void Hire(IPayable payable)
        {
            Resources.Add(payable);
        }

        public void Terminate(IPayable payable)
        {
            Resources.Remove(payable);
        }

        public float Pay()
        {
            return Resources.Sum(p => p.Pay());
        }
    }
}