using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabExam.Properties;
using LabExam.Repository;
using System.Data;
using LabExam.Model;

namespace LabExam.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public bool IsCodeExist(Customer customer)
        {
            return _customerRepository.IsCodeExist(customer);
        }

        public bool IsContactExist(Customer customer)
        {
            return _customerRepository.IsContactExist(customer);
        }
        public DataTable Display()
        {
            return _customerRepository.Display();
        }
        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }


        public DataTable Search(string name)
        {
            return _customerRepository.Search(name);
        }

        public DataTable districtCombo()
        {
            return _customerRepository.districtCombo();
        }

    }
}
