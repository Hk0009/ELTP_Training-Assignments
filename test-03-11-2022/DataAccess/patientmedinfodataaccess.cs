using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_03_11_2022.Models;
using Microsoft.EntityFrameworkCore;

namespace test_03_11_2022.DataAccess
{
    public class patientmedinfodataaccess : IDataAccess<PatientMedInfo, int>
    {
        ClinicManagementContext ctx;
        public patientmedinfodataaccess()
        {
            ctx = new ClinicManagementContext();
        }
        async Task<PatientMedInfo> IDataAccess<PatientMedInfo, int>.CreateAsync(PatientMedInfo entity)
        {
            try
            {
                var result = await ctx.PatientMedInfos.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
