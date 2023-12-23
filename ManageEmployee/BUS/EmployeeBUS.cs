using System;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using ManageEmployee.DAO;
using ManageEmployee.DTO;

namespace ManageEmployee.BUS
{
    internal class EmployeeBUS
    {
        private EmployeeDAO _employeeDAO;

        public EmployeeBUS()
        {
            _employeeDAO = new EmployeeDAO();
        }

        public ObservableCollection<EmployeeDTO> getAll() { return _employeeDAO.getAll(); }

        public void delEmployee(int id)
        {
            _employeeDAO.deleteEmployeeById(id);
        }

        public int saveEmployee(EmployeeDTO employee)
        {
            int id = _employeeDAO.insertEmployee(employee);

            return id;
        }

        public void patchEmployee(EmployeeDTO employee)
        {
            _employeeDAO.updateEmployee(employee);
        }
     
        public EmployeeDTO findEmployeeById(int id)
        {
            return _employeeDAO.getEmployeeById(id);
        }

    }
}
