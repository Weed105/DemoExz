using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExz
{
    public class GetData
    {
        public readonly DbTechnoserviceContext _technoserviceContext;
        public GetData (DbTechnoserviceContext technoserviceContext)
        {
            _technoserviceContext = technoserviceContext;
        }
        public async Task<List<Application>> GetApplications()
        {
            List<Application> applications = new List<Application>();
            var applicationsDb = _technoserviceContext.Applications.ToList();
            await Task.Run(() =>
            {
                applications = applicationsDb;
            });
            return applications;
        }
    }
}
