using FormularioExamen.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioExamen.model
{
    class ApiObject
    {
        private ApiManage am;

        public ApiObject()
        {
            am = new ApiManage();
        }

        public string name { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string type { get; set; }

        public Task<List<ApiObject>> getFestivos()
        {
            return am.obtenerFestivos();
        }
    }
}
