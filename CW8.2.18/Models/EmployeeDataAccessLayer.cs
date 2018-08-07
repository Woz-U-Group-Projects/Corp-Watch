
using CW8;
using CW8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW8.Models
{
    public class EmployeeDataAccessLayer
    {
        CorpWatchDbContext db = new CorpWatchDbContext();
        public IEnumerable<TblEmployee> GetAllEmployees()
        {
            try
            {
                return db.TblEmployee.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new employee record     
        public int AddEmployee(TblEmployee employee)
        {
            try
            {
                db.TblEmployee.Add(employee);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee    
        public int UpdateEmployee(TblEmployee employee)
        {
            try
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee    
        public TblEmployee GetEmployeeData(int id)
        {
            try
            {
                TblEmployee employee = db.TblEmployee.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular employee    
        public int DeleteEmployee(int id)
        {
            try
            {
                TblEmployee emp = db.TblEmployee.Find(id);
                db.TblEmployee.Remove(emp);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Get the list of Jobs    
        public List<TblJob> GetJob()
        {
            List<TblJob> lstJob = new List<TblJob>();
            lstJob = (from JobList in db.TblJob select JobList).ToList();
            return lstJob;
        }
    }
}
