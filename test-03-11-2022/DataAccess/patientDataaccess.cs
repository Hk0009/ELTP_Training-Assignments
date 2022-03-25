using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using test_03_11_2022.Models;
using Microsoft.EntityFrameworkCore;

namespace test_03_11_2022.DataAccess
{
    public  class patientDataaccess : IDataAccess<Patient, int>
    {
        ClinicManagementContext ctx;
        public patientDataaccess()
        {
            ctx = new ClinicManagementContext();
        }
        async Task<Patient> IDataAccess<Patient, int>.CreateAsync(Patient entity)
        {
            try
            {
                var result = await ctx.Patients.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
     //   async Task<Patient?> IDataAccess<Patient, int>.UpdateAsync(Patient entity, int id)
       /* {
     
            
            
                var PatientUpdate = await ctx.Patients.FindAsync(id);

                if (PatientUpdate == null)
                {
                    return null;

                }
                PatientUpdate.Amount = entity.Amount;


                await ctx.SaveChangesAsync();
                return PatientUpdate;

            
        }*/
    }
}
