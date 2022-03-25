using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_03_11_2022.Models;
using Microsoft.EntityFrameworkCore;

namespace test_03_11_2022.DataAccess
{
    public  class report
    {
        ClinicManagementContext ctx;
        public report()
        {
            ctx = new ClinicManagementContext();
        }
        public  async Task patientwisereport( Patient pt,PatientMedInfo Pm, int id)
        {

            var resPatien = await ctx.Patients.ToListAsync();
            var patientMedInfos = await ctx.PatientMedInfos.ToListAsync();
            foreach (var patientInfo in resPatien)
            {
                Console.WriteLine($"{resPatien}");
            }
        }
    }
}
