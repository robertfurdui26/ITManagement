

using ITManagement.Data;
using ITManagement.Models;
using ITManagement.Repository.IRepository;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;

namespace ITManagement.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationITDbContect _db;
        public EmployeeRepository(ApplicationITDbContect db) : base(db)
        {
            _db = db;
        }

        void IEmployeeRepository.Update(Employee obj)
        {
            var objFromDb = _db.Employees.FirstOrDefault(u => u.Id == obj.Id);

            if(objFromDb != null)
            {
                objFromDb.FirstName = obj.FirstName;
                objFromDb.LastName = obj.LastName;
                objFromDb.DateOfHire = obj.DateOfHire;
                objFromDb.DepartamentId = obj.DepartamentId;
                objFromDb.Salary = obj.Salary;
                objFromDb.DateOfBirth = obj.DateOfBirth;
                objFromDb.Email = obj.Email;
                objFromDb.StreetAdress = obj.StreetAdress;
                objFromDb.PhoneNumber  = obj.PhoneNumber;
                objFromDb.City = obj.City;
                obj.State = obj.State;
                obj.PostalCode = obj.PostalCode;
                objFromDb.Country = obj.Country;
                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
